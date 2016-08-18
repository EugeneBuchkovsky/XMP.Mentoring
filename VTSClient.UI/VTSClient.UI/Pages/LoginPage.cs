using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VTSClient.UI.Pages
{
    public class LoginPage : ContentPage
    {
        public LoginPage()
        {

            //Uri ur = new Uri("http://localhost:63375/api/Vacations/3");
            WebView wb = new WebView
            {
                //Source = new UrlWebViewSource { Url = "http://localhost:63375/api/Vacations/3" },
                Source = new UrlWebViewSource { Url = "http://10.6.106.21/test/api/Vacations/3" },

                //Source = new UrlWebViewSource { Url = "http://google.com" },

                VerticalOptions = LayoutOptions.FillAndExpand

            };



            //Image img = new Image
            //{
            //    Source = "Index_Page_Background.jpg",
            //    Aspect = Aspect.AspectFill
            //};

            StackLayout mainLayout;
            Title = "Login";
            BackgroundImage = "VTS_Main_Theme.jpg";
            Entry login = new Entry
            {
                Placeholder = "Login"
            };

            Entry password = new Entry
            {
                Placeholder = "Password",
                IsPassword = true
            };

            Button enterbutton = new Button
            {
                Text = "Enter",
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

            mainLayout.Children.Add(wb);

            //mainLayout.Children.Add(title);
            //mainLayout.Children.Add(img);


            mainLayout.Children.Add(login);
            mainLayout.Children.Add(password);
            mainLayout.Children.Add(enterbutton);
            mainLayout.Children.Add(errorMessage);
            //mainLayout.Children.Add(wb);


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
