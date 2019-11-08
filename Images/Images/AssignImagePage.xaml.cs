
using System;
using System.Collections.Generic;
using System.Reflection;
using Xamarin.Forms;

namespace Images
{
    public partial class AssignImagePage : ContentPage
    {
        public AssignImagePage()
        {
            InitializeComponent();

            //Assigning image from Resource
            resourceImage.Source = ImageSource.FromResource("Images.Assets.Images.NormalProfile.png");

            //Assigning image from File
            fileImage.Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("FavoriteProfile.png") : ImageSource.FromFile("Images/sports.jpg");
        }
    }
}
