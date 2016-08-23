using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using VTSClient.UI.Resources;


namespace VTSClient.UI.Pages
{
    public class VacationsPage : ContentPage
    {
        public VacationsPage()
        {
            Title = Resource.VacationsPageTitle;

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
                BackgroundColor = Color.White
            };
            
            vocationsListView.SetBinding(ListView.ItemsSourceProperty, new Binding("VocationList", BindingMode.TwoWay));
            vocationsListView.SetBinding(ListView.SelectedItemProperty, new Binding("SelectedVocation", BindingMode.TwoWay));
            vocationsListView.ItemTemplate.SetBinding(ImageCell.TextProperty, new Binding("ApproverFullName"));
            vocationsListView.ItemTemplate.SetBinding(ImageCell.DetailProperty, new Binding("StartDate"));

            mainLayout.Children.Add(vocationsListView);

            ScrollView mainView = new ScrollView();
            mainView.Content = mainLayout;
            Content = mainView;
        }
    }
}
