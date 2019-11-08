using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ContactsBook.Models;
using ContactsBook.Views;
using Xamarin.Forms;

namespace ContactsBook.ViewModels
{
    public class ContactsPageViewModel : BaseViewModel
    {
        private ContactViewModel _selectedContact;
        private IContactStore _contactStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<ContactViewModel> Contacts { get; private set; }
            = new ObservableCollection<ContactViewModel>();

        public ContactViewModel SelectedContact
        {
            get { return _selectedContact; }
            set { SetValue(ref _selectedContact, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddContactCommand { get; private set; }
        public ICommand SelectContactCommand { get; private set; }
        public ICommand DeleteContactCommand { get; private set; }
        public ICommand CallContactCommand { get; private set; }

        public ContactsPageViewModel(IContactStore contactStore, IPageService pageService)
        {
            _contactStore = contactStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddContactCommand = new Command(async () => await AddContact());
            SelectContactCommand = new Command<ContactViewModel>(async c => await SelectContact(c));
            DeleteContactCommand = new Command<ContactViewModel>(async c => await DeleteContact(c));
            CallContactCommand = new Command<ContactViewModel>(async c => await CallContact(c));

            MessagingCenter.Subscribe<ContactsDetailViewModel, Contact>
                (this, Events.ContactAdded, OnContactAdded);

            MessagingCenter.Subscribe<ContactsDetailViewModel, Contact>
            (this, Events.ContactUpdated, OnContactUpdated);
        }

        private void OnContactAdded(ContactsDetailViewModel source, Contact contact)
        {
            Contacts.Add(new ContactViewModel(contact));
        }

        private void OnContactUpdated(ContactsDetailViewModel source, Contact contact)
        {
            var contactInList = Contacts.Single(c => c.Id == contact.Id);

            contactInList.Id = contact.Id;
            contactInList.FirstName = contact.FirstName;
            contactInList.LastName = contact.LastName;
            contactInList.Phone = contact.Phone;
            contactInList.Email = contact.Email;
            contactInList.IsFavorite = contact.IsFavorite;
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var contacts = await _contactStore.GetContactsAsync();
            foreach (var contact in contacts)
                Contacts.Add(new ContactViewModel(contact));
        }

        private async Task AddContact()
        {
            await _pageService.PushAsync(new ContactsDetailPage(new ContactViewModel()));
        }

        private async Task SelectContact(ContactViewModel contact)
        {
            if (contact == null)
                return;

            SelectedContact = null;
            await _pageService.PushAsync(new ContactsDetailPage(contact));
        }

        private async Task DeleteContact(ContactViewModel contactViewModel)
        {
            if (await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {contactViewModel.FullName}?", "Yes", "No"))
            {
                Contacts.Remove(contactViewModel);

                var contact = await _contactStore.GetContact(contactViewModel.Id);
                await _contactStore.DeleteContact(contact);
            }
        }

        private async Task CallContact(ContactViewModel contactViewModel)
        {
            if (contactViewModel != null)
            {
                var message = contactViewModel.FullName + "\n" + contactViewModel.Phone;
                bool isCall = await _pageService.DisplayAlert("Do you really want to Call?", message, "Call", "Cancel");
                if (isCall)
                {
                    //Go to Contacts App
                    Device.OpenUri(new Uri("tel:" + contactViewModel.Phone));
                }
            }
        }
    }
}
