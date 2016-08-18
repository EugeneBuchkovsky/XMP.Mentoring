using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VTSClient.UI.Pages
{
    public class VacationsPage : ContentPage
    {
        public VacationsPage()
        {
            Title = "Vocations";

            StackLayout mainLayout;

            var vocationsListView = new ListView
            {
                ItemTemplate = new DataTemplate(typeof(ImageCell))
            };

            mainLayout = new StackLayout
            {
                Padding = new Thickness(10),
                Spacing = 1,
                Orientation = StackOrientation.Vertical,
            };

            vocationsListView.SetBinding(ListView.ItemsSourceProperty, new Binding("VocationList", BindingMode.TwoWay));
            vocationsListView.ItemTemplate.SetBinding(ImageCell.TextProperty, new Binding("NameEmployee"));
            vocationsListView.ItemTemplate.SetBinding(ImageCell.DetailProperty, new Binding("NameAprover"));

            mainLayout.Children.Add(vocationsListView);

            ScrollView mainView = new ScrollView();
            mainView.Content = mainLayout;
            Content = mainView;
        }
    }
}
