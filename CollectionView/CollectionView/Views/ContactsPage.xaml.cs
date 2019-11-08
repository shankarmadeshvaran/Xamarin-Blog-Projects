using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CollectionView.Models;
using CollectionView.Service;
using Xamarin.Forms;

namespace CollectionView.Views
{
    public partial class ContactsPage : ContentPage
    {
        public List<Contact> AllContacts { get; set; }

        public ContactsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AllContacts = new List<Contact>(Contacts.Get());
            collectionViewListHorizontal.ItemsSource = AllContacts;
            collectionViewListVertical.ItemsSource = AllContacts;
        }

        void CollectionViewListSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateSelectionData(e.PreviousSelection, e.CurrentSelection);
        }

        void UpdateSelectionData(IEnumerable<object> previousSelectedContact, IEnumerable<object> currentSelectedContact)
        {
            var selectedContact = currentSelectedContact.FirstOrDefault() as Contact;
            Debug.WriteLine("FullName: " + selectedContact.FullName);
            Debug.WriteLine("Email: " + selectedContact.Email);
            Debug.WriteLine("Phone: " + selectedContact.Phone);
            Debug.WriteLine("Country: " + selectedContact.Country);
        }
    }
}
