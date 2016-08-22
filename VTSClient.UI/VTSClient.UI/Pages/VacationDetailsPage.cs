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
            Title = "Login";

            Entry login = new Entry
            {
                HorizontalOptions = LayoutOptions.Center,
            };

            Entry password = new Entry
            {
                HorizontalOptions = LayoutOptions.Center,
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
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            Content = mainLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Spacing = 10,
                Orientation = StackOrientation.Vertical
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
