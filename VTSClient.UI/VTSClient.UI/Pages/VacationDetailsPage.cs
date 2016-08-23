using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VTSClient.UI.Pages
{
    public class VacationDetailsPage : ContentPage
    {
        public VacationDetailsPage()
        {

            StackLayout mainLayout;
            Title = "Vacation details";

            Entry login = new Entry
            {
                TextColor = Color.FromHex("878d8f"),
                BackgroundColor = Color.FromHex("ccc")
            };

            Entry password = new Entry
            {
                TextColor = Color.FromHex("878d8f"),
                BackgroundColor = Color.FromHex("ccc")
            };

            var title = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
            };

            var title1 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
            };

            var title2 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
            };

            var saveButton = new Button
            {
                Text = "Save changes",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("8CAD35"),
                BorderRadius = 0
            };

            Content = mainLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White
                //BackgroundColor = new Color(0.1, 0.5, 0.2, 0.1)
            };



            mainLayout.Children.Add(login);
            mainLayout.Children.Add(password);
            mainLayout.Children.Add(title);
            mainLayout.Children.Add(title1);
            mainLayout.Children.Add(title2);
            mainLayout.Children.Add(saveButton);

            login.SetBinding(Entry.TextProperty, new Binding("Name"));
            password.SetBinding(Entry.TextProperty, new Binding("Name1"));
            title.SetBinding(Label.TextProperty, new Binding("Name2"));
            title1.SetBinding(Label.TextProperty, new Binding("Name3"));
            title2.SetBinding(Label.TextProperty, new Binding("Name4"));
            saveButton.SetBinding(Button.CommandProperty, new Binding("Save"));
        }
    }
}
