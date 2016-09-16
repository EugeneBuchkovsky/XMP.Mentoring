using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using VTSClient.BusinessLogic.ViewModels;
using ObjCRuntime;
using MvvmCross.Core.ViewModels;

namespace VTSClient.UI.iOSNative.Views
{
    [Register("CreateVacationTabsView")]
    public class CreateVacationTabsView : MvxTabBarViewController
    {
        public CreateVacationTabsView()
        {
            ViewDidLoad();
        }

        protected CreateVacationViewModel CreateVacationViewModel
        {
            get { return ViewModel as CreateVacationViewModel; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            //if (ViewModel == null)
            //    return;


        }

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);

            var viewControllers = new UIViewController[]
            {
                CreateTabFor("Regular", CreateVacationViewModel.RegularVacation),
                CreateTabFor("Sick", CreateVacationViewModel.SickLeave)
            };

            ViewControllers = viewControllers;
            CustomizableViewControllers = new UIViewController[] { };
            SelectedViewController = ViewControllers[0];
        }

        private int _createdSoFarCount = 0;

        private UIViewController CreateTabFor(string title, IMvxViewModel viewModel)
        {
            var controller = new UINavigationController();
            var screen = this.CreateViewControllerFor(viewModel) as UIViewController;
            screen.Title = title;
            _createdSoFarCount++;
            controller.PushViewController(screen, false);
            return controller;
        }


    }
}