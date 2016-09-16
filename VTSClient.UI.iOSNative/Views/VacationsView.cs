using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using ObjCRuntime;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using VTSClient.BusinessLogic.ViewModels;
using FlyoutNavigation;
using MvvmCross.Plugins.Messenger;
using MvvmCross.Platform;
using MvvmCross.Core.ViewModels;
using MonoTouch.Dialog;
using System.Collections.Generic;

namespace VTSClient.UI.iOSNative.Views
{
    [Register("VacationsView")]
    public class VacationsView : MvxTableViewController
    {
        FlyoutNavigationController navigation;
        private MvxSubscriptionToken navigationMenuToggleToken;
        private MvxSubscriptionToken navigationBarHiddenToken;

        //public override void ViewWillAppear(bool animated)
        //{
        //    base.ViewWillAppear(animated);
        //    navigation.View.Frame = UIScreen.MainScreen.Bounds;
        //    navigation.View.Bounds = UIScreen.MainScreen.Bounds;
        //}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            
            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var source = new MvxSimpleTableViewSource(TableView, typeof(VacationItemView), VacationItemView.Key);
            TableView.RowHeight = 100;
            //var source = new MvxStandardTableViewSource(TableView, "TitleText Type");
            TableView.Source = source;

            var set = this.CreateBindingSet<VacationsView, VacationsViewModel>();
            //set.Bind(source.SelectedItem).To(vm => vm.SelectedVocation);
            set.Bind(source).To(vm => vm.VocationList);
            set.Bind(source).For((qwe) => qwe.SelectedItem).To(vm => vm.SelectedVocation);
            set.Apply();

            TableView.ReloadData();




            // SIDE MENU

            //NavigationController.NavigationBarHidden = true;
            //Title = "Home";
            //this.View = new UIView { BackgroundColor = UIColor.White };

            //navigation = new FlyoutNavigationController();

            //View.AddSubview(navigation.View);
            //this.AddChildViewController(navigation);


            ////names of the views shown in the flyout
            //var flyoutMenuElements = new Section();
            ////views that will be shown when a menu item is selected
            //var flyoutViewControllers = new List<UIViewController>();
            //var vacationsViewModel = ViewModel as VacationsViewModel;
            //if (vacationsViewModel != null)
            //{
            //    //create the ViewModels
            //    foreach (var viewModel in vacationsViewModel.MenuItems)
            //    {
            //        var viewModelRequest = new MvxViewModelRequest
            //        {
            //            ViewModelType = viewModel.ViewModelType
            //        };

            //        flyoutViewControllers.Add(CreateMenuItemController(viewModelRequest));
            //        flyoutMenuElements.Add(new StringElement(viewModel.Title));
            //    }
            //    navigation.ViewControllers = flyoutViewControllers.ToArray();

            //    //add the menu elements
            //    var rootElement = new RootElement("")
            //{
            //    flyoutMenuElements
            //};
            //    navigation.NavigationRoot = rootElement;
            //}


            //var messenger = Mvx.Resolve<IMvxMessenger>();
            //navigationMenuToggleToken = messenger.SubscribeOnMainThread<ToggleFlyoutMenuMessage>(message => navigation.ToggleMenu());
            //navigationBarHiddenToken = messenger.SubscribeOnMainThread<NavigationBarHiddenMessage>(message => NavigationController.NavigationBarHidden = message.NavigationBarHidden);

        }

        private UIViewController CreateMenuItemController(MvxViewModelRequest viewModelRequest)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(viewModelRequest) as UIViewController;
            controller.PushViewController(screen, false);
            return controller;
        }
    }
}