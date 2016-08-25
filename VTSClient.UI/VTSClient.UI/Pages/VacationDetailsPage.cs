using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using VTSClient.UI.Resources;

namespace VTSClient.UI.Pages
{
    public class VacationDetailsPage : ContentPage
    {
        public VacationDetailsPage()
        {

            StackLayout mainLayout;


            Title = Resource.VacationDetailsPage;

            var approverTitle = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = Resource.Approver,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };

            Label login = new Label
            {
                TextColor = Color.FromHex("878d8f"),
                BackgroundColor = Color.FromHex("f4f4f4")
            };

            var StatusTitle = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = Resource.VacationStatus,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };

            Label password = new Label
            {
                TextColor = Color.FromHex("878d8f"),
                BackgroundColor = Color.FromHex("f4f4f4")
            };

            var formTitle = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = Resource.VacationForm,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };

            

            var title = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
            };

            var startDate = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = Resource.VacationStartDate,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };
            

            var title1 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
            };


            var endDate = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = Resource.VacationEndDate,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };


            var title2 = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
            };

            var commentTitle = new Label
            {
                HorizontalOptions = LayoutOptions.Start,
                Text = Resource.Comment,
                Font = Font.SystemFontOfSize(NamedSize.Micro)
            };

            var comment = new Editor
            {
                BackgroundColor = Color.FromHex("f4f4f4"),
                TextColor = Color.FromHex("666"),
                IsEnabled = true
            };

            var vacationType = new Label
            {
                HorizontalOptions = LayoutOptions.Center,
            };

            var saveButton = new Button
            {
                Text = Resource.SaveChangesButton,
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("8CAD35"),
                BorderRadius = 0
            };

            mainLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Spacing = 10,
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.White
                //BackgroundColor = new Color(0.1, 0.5, 0.2, 0.1)
            };


            mainLayout.Children.Add(approverTitle);

            mainLayout.Children.Add(login);
            mainLayout.Children.Add(StatusTitle);

            mainLayout.Children.Add(password);
            mainLayout.Children.Add(formTitle);

            mainLayout.Children.Add(title);
            mainLayout.Children.Add(startDate);

            mainLayout.Children.Add(title1);
            mainLayout.Children.Add(endDate);

            mainLayout.Children.Add(title2);

            mainLayout.Children.Add(commentTitle);
            mainLayout.Children.Add(comment);
            mainLayout.Children.Add(vacationType);
            mainLayout.Children.Add(saveButton);
            


            login.SetBinding(Label.TextProperty, new Binding("Name"));
            password.SetBinding(Label.TextProperty, new Binding("Name1"));
            title.SetBinding(Label.TextProperty, new Binding("Name2"));
            title1.SetBinding(Label.TextProperty, new Binding("Name3"));
            title2.SetBinding(Label.TextProperty, new Binding("Name4"));
            comment.SetBinding(Editor.TextProperty, new Binding("Comment", BindingMode.TwoWay));
            vacationType.SetBinding(Label.TextProperty, new Binding("Type"));
            saveButton.SetBinding(Button.CommandProperty, new Binding("Save"));

            ScrollView mainBackground = new ScrollView
            {
                Content = mainLayout
            };
            Content = mainBackground;
        }
    }
}
