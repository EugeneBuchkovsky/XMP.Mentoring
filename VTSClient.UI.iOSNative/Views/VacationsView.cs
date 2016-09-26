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
    public class MyTableController : MvxSimpleTableViewSource
    {
        public MyTableController(UITableView tableView, Type cellType, string cellIdentifier = null)
            : base(tableView, cellType, cellIdentifier)
        { }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            base.RowSelected(tableView, indexPath);

            //var item = this.GetItemAt(indexPath);

            //var command = this.SelectionChangedCommand;
            //if (command != null && command.CanExecute(item))
            //    command.Execute(item);

            //this.SelectedItem = item;
            tableView.DeselectRow(indexPath, true);
            this.SelectedItem = null;
        }
    }

    [Register("VacationsView")]
    public class VacationsView : MvxTableViewController
    {
        private MenuView menuScreen;
        public MenuView MenuScreen
        {
            get { return menuScreen; }
            set
            {
                if (menuScreen != null)
                    menuScreen.RemoveFromSuperview();
                menuScreen = value;

                if (menuScreen != null)
                    View.AddSubview(menuScreen);

                UpdateSlide();
            }
        }

        private UITableView tableScreen;
        public UITableView TableScreen
        {
            get { return tableScreen; }
            set
            {
                if (tableScreen != null)
                    tableScreen.RemoveFromSuperview();
                tableScreen = value;

                if (tableScreen != null)
                    View.AddSubview(tableScreen);

                UpdateSlide();
            }
        }

        private void UpdateSlide()
        {
            if (MenuScreen != null)
                View.BringSubviewToFront(MenuScreen);
        }

        private bool isOpen;
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                UpdateState();
            }
        }

        public void UpdateState()
        {
            UIView.Animate(0.2, () =>
            {
                if (IsOpen)
                {
                    MenuScreen.Frame = new CoreGraphics.CGRect(0, 0, 250, View.Frame.Height);
                }
                else
                    MenuScreen.Frame = new CoreGraphics.CGRect(-250, 0, 250, View.Frame.Height);
            });
        }
        
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            isOpen = false;
            NavigationController.NavigationBarHidden = false;
        }

        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            //this.NavigationItem.SetRightBarButtonItem(
            //    new UIBarButtonItem(UIBarButtonSystemItem.Action, (sender, args) =>
            //    {
            //        // button was clicked
            //        IsOpen = !IsOpen;
            //    }), true);

            

            this.Title = "Vacations";
            this.NavigationItem.SetLeftBarButtonItem(
                new UIBarButtonItem(UIBarButtonSystemItem.Bookmarks, (sender, args) =>
                {
                    // button was clicked
                    IsOpen = !IsOpen;
                }), true);

            //View.AddGestureRecognizer(new UITapGestureRecognizer(() =>
            //{
            //    if(IsOpen)
            //        IsOpen = !IsOpen;
            //}));

            TableScreen.Frame = View.Bounds;

            if (IsOpen)
            {
                MenuScreen.Frame = new CoreGraphics.CGRect(0, 0, 250, View.Frame.Height);
            }
            else
                MenuScreen.Frame = new CoreGraphics.CGRect(-250, 0, 250, View.Frame.Height);
        }

        public override void ViewDidLoad()
        {

            base.ViewDidLoad();

            MenuScreen = new MenuView();
            //TableView = TableScreen = new UITableView();
            TableScreen = new UITableView();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            var source = new MyTableController(TableScreen, typeof(VacationItemView), VacationItemView.Key);
            //source.DeselectAutomatically = true;
            TableScreen.RowHeight = 100;
            //var source = new MvxStandardTableViewSource(TableView, "TitleText Type");
            TableScreen.Source = source;

            //_____Menu___________
            var menuSource = new MyTableController(MenuScreen, typeof(MenuItemView), MenuItemView.Key);
            MenuScreen.RowHeight = 50;
            MenuScreen.Source = menuSource;
            //____________________

            var uinavRightButton = new UIBarButtonItem(UIBarButtonSystemItem.Add);

            this.NavigationItem.SetRightBarButtonItem(uinavRightButton, true);

            var set = this.CreateBindingSet<VacationsView, VacationsViewModel>();
            //set.Bind(source.SelectedItem).To(vm => vm.SelectedVocation);
            set.Bind(source).To(vm => vm.VocationList);
            set.Bind(source).For((qwe) => qwe.SelectedItem).To(vm => vm.SelectedVocation);

            set.Bind(menuSource).To(vm => vm.MenuItems);
            set.Bind(menuSource).For(si=>si.SelectedItem).To(vm => vm.SelectedItem);
            set.Bind(uinavRightButton).To(vm => vm.AddCommand);

            set.Apply();

            TableScreen.ReloadData();

        }
    }
}