using System;
using Xamarin.Forms;

namespace Images
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            Label headerLabel = new Label
            {
                Text = "Accessing Images in Xamarin Forms",
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                FontSize = 24
            };

            TableView tableViewImages = new TableView
            {
                HasUnevenRows = true,
                Intent = TableIntent.Form,
                Root = new TableRoot
                {
                    new TableSection
                    {
                        //Assigning image to ImageCell from File
                        new ImageCell
                        {
                            ImageSource = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("FavoriteProfile.png") : ImageSource.FromFile("Images/sports.jpg"),
                            Text = "ImageSource from File",
                            Detail = "Image is accessed using ImageSource.FromFile",
                        },
                         //Assigning image to ImageCell from Source
                         new ImageCell
                        {
                            ImageSource = "icon.png",
                            Text = "Image from Source",
                            Detail = "Image is accessed from Source",
                        },
                        //Assigning image to ImageCell from Resource
                          new ImageCell
                        {
                            ImageSource = ImageSource.FromResource("Images.Assets.Images.NormalProfile.png"),
                            Text = "ImageSource from Resource",
                            Detail = "Image is accessed using ImageSource.FromResource",
                        },
                          //Assigning image to ImageCell from Uri
                          new ImageCell
                        {
                            ImageSource = ImageSource.FromUri(new Uri("https://image.shutterstock.com/image-photo/bright-spring-view-cameo-island-600w-1048185397.jpg")),
                            Text = "ImageSource from Uri",
                            Detail = "Image is accessed using ImageSource.FromUri",
                        },
                          new CustomViewCell
                         {
                          // Custom View Cell - Assign image to Image from File,Resource,Source and Uri 
                         }
                    }
                }
            };

            this.Padding = new Thickness(10);

            this.Content = new StackLayout
            {
                Children =
                {
                    headerLabel,
                    tableViewImages,
                }
            };
        }
    }
}

//Custom View Cell - Assign image to Image from File,Resource,Source and Uri
class CustomViewCell : ViewCell
{
    public CustomViewCell()
    {
        //Assigning image to ImageCell from File
        Image assignImageFromFile = new Image
        {
            Source = (Device.RuntimePlatform == Device.Android) ? ImageSource.FromFile("FavoriteProfile.png") : ImageSource.FromFile("Images/sports.jpg"),
            Aspect = Aspect.AspectFit,
            HeightRequest = 50,
            WidthRequest = 60
        };

        //Assigning image to ImageCell from Source
        Image assignImageFromSource = new Image
        {
            Source = "icon.png",
            Aspect = Aspect.AspectFit,
            HeightRequest = 50,
            WidthRequest = 60
        };

        //Assigning image to ImageCell from Resource
        Image assignImageFromResource = new Image
        {
            Source = ImageSource.FromResource("Images.Assets.Images.NormalProfile.png"),
            Aspect = Aspect.AspectFit,
            HeightRequest = 50,
            WidthRequest = 60
        };

        //Assigning image to ImageCell from Uri
        Image assignImageFromUri = new Image
        {
            Source = ImageSource.FromUri(new Uri("https://image.shutterstock.com/image-photo/bright-spring-view-cameo-island-600w-1048185397.jpg")),
            Aspect = Aspect.AspectFit,
            HeightRequest = 50,
            WidthRequest = 60
        };

        StackLayout imageStack = new StackLayout
        {
            Children =
            {
                assignImageFromFile,
                assignImageFromSource,
                assignImageFromResource,
                assignImageFromUri
            },
            Orientation = StackOrientation.Horizontal,
            Spacing = 40
        };

        //CustomViewCell View contains imageStack
        View = imageStack;
    }
}