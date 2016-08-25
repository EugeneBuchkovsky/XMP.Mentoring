using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using VTSClient.UI.Resources;

namespace VTSClient.UI.Pages
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {

            //Uri ur = new Uri("http://localhost:63375/api/Vacations/3");
            //WebView wb = new WebView
            //{
            //    //Source = new UrlWebViewSource { Url = "http://localhost:63375/api/Vacations/3" },
            //    Source = new UrlWebViewSource { Url = "http://10.6.106.21/test/api/Vacations/3" },

            //    //Source = new UrlWebViewSource { Url = "http://google.com" },

            //    VerticalOptions = LayoutOptions.FillAndExpand

            //};



            //Image img = new Image
            //{
            //    Source = "Index_Page_Background.jpg",
            //    Aspect = Aspect.AspectFill
            //};

            StackLayout mainLayout;
            Title = Resource.LoginName;
            BackgroundImage = "VTS_Main_Theme.jpg";
            Entry login = new Entry
            {
                Placeholder = Resource.EntryLogin,
                BackgroundColor = new Color(0.99, 0.99, 0.99, 0.9),
                TextColor = Color.FromHex("666")
                //FontFamily = "DB LCD Temp"
            };


            Entry password = new Entry
            {
                Placeholder = Resource.EntryPassword,
                IsPassword = true,
                BackgroundColor = new Color(0.99, 0.99, 0.99, 0.9),
                TextColor = Color.FromHex("666")
            };

            Button enterbutton = new Button
            {
                Text = Resource.LoginButton,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("8CAD35"),
                BorderRadius = 0
                //VerticalOptions = LayoutOptions.Fill,
                //HorizontalOptions = LayoutOptions.Center

            };

            var title = new Label
            {
                Text = "Hello !!!",
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = new Color(1, 1, 1, 1),
                FontFamily = "Arial"
            };

            var errorMessage = new Label
            {
                Font = Font.SystemFontOfSize(NamedSize.Micro),
                TextColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center,
                FontFamily = "Colibri"
            };

            Content = mainLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Spacing = 10,
                Orientation = StackOrientation.Vertical
                //BackgroundColor = new Color(0.1, 0.5, 0.2, 0.1)
            };

            //mainLayout.Children.Add(wb);

            //mainLayout.Children.Add(title);
            //mainLayout.Children.Add(img);

            StackLayout sl = new StackLayout();
            sl.Children.Add(login);
            sl.Children.Add(password);
            sl.Children.Add(enterbutton);
            sl.Children.Add(errorMessage);

            Frame logFrame = new Frame
            {
                  Content = sl,
                  BackgroundColor = new Color (0.99,0.99,0.99,0.8),
                  VerticalOptions = LayoutOptions.CenterAndExpand
            };


            var image = new Image
            {
                Source = "Logo_Epam_Color.png",
                VerticalOptions = LayoutOptions.End,
                HorizontalOptions = LayoutOptions.Center
            };
            //mainLayout.Children.Add(login);
            //mainLayout.Children.Add(password);
            //mainLayout.Children.Add(enterbutton);
            //mainLayout.Children.Add(errorMessage);
            //mainLayout.Children.Add(wb);
            mainLayout.Children.Add(logFrame);
            mainLayout.Children.Add(image);

            enterbutton.SetBinding(Button.CommandProperty, new Binding("Logon"));
            login.SetBinding(Entry.TextProperty, new Binding("Login"));
            password.SetBinding(Entry.TextProperty, new Binding("Password"));
            errorMessage.SetBinding(Label.TextProperty, new Binding("ErrorMessage"));
        }

        //protected override void OnBindingContextChanged()
        //{
        //    base.OnBindingContextChanged();
        //}
    }
}
