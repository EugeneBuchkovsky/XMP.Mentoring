using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using VTSClient.BusinessLogic.ViewModels;
using MvvmCross.Binding.BindingContext;
using ObjCRuntime;

namespace VTSClient.UI.iOSNative.Views
{
    [Register("AccountViewMain")]
    public class AccountViewMain : UIView
    {
        public AccountViewMain()
        {
            Initialize();
        }

        public AccountViewMain(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.White;
        }
    }

    [Register("Account View")]
    public class AccountView : MvxViewController
    {
        public AccountView()
        {
        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            View = new AccountViewMain();

            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;


            var loginEdit = new UITextField(new RectangleF( 0, 0, 200, 40));
            loginEdit.BackgroundColor = UIColor.DarkGray;
            Add(loginEdit);

            var passwordEdit = new UITextField(new RectangleF(0, 50, 200, 40));
            passwordEdit.BackgroundColor = UIColor.DarkGray;
            Add(passwordEdit);

            var button = new UIButton(new RectangleF(0, 100, 200, 40));
            button.BackgroundColor = UIColor.Green;
            Add(button);

            var set = this.CreateBindingSet<AccountView, AccountViewModel>();
            set.Bind(loginEdit).To(vm => vm.Login);

            set.Bind(passwordEdit).To(vm => vm.Password);

            set.Bind(button).To(vm => vm.Logon);
            // Perform any additional setup after loading the view
            set.Apply();


            var gesture = new UITapGestureRecognizer(() =>
            {
                loginEdit.ResignFirstResponder();
            });
            View.AddGestureRecognizer(gesture);
        }
    }
}