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
        public UITextField loginEdit;
        public UITextField passwordEdit;
        public UIButton enterButton;
        public UILabel message;

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

            loginEdit = new UITextField();
            loginEdit.BackgroundColor = UIColor.Clear;
            loginEdit.BorderStyle = UITextBorderStyle.Bezel;
            loginEdit.Layer.CornerRadius = 10;
            //loginEdit.Layer.BorderColor =UIColor.FromRGB(250, 250, 250);
            loginEdit.Placeholder = "Login";
            loginEdit.TranslatesAutoresizingMaskIntoConstraints = false;

            passwordEdit = new UITextField();
            passwordEdit.BackgroundColor = new UIColor(new nfloat(0.9), new nfloat(0.9), new nfloat(0.9), new nfloat(0.9));
            passwordEdit.Placeholder = "Password";
            passwordEdit.SecureTextEntry = true;
            passwordEdit.Layer.CornerRadius = new nfloat(10.0);
            passwordEdit.TranslatesAutoresizingMaskIntoConstraints = false;

            enterButton = new UIButton();
            enterButton.BackgroundColor = UIColor.FromRGB(140, 173, 53);
            enterButton.SetTitle("Enter", new UIControlState());
            enterButton.TranslatesAutoresizingMaskIntoConstraints = false;

            message = new UILabel();
            message.TextColor = UIColor.Red;
            message.TranslatesAutoresizingMaskIntoConstraints = false;

            AddSubview(loginEdit);
            AddSubview(passwordEdit);
            AddSubview(enterButton);
            AddSubview(message);

            AddConstraint(NSLayoutConstraint.Create(loginEdit, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(loginEdit, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterY, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(loginEdit, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, new nfloat(0.5), 0));

            AddConstraint(NSLayoutConstraint.Create(passwordEdit, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(passwordEdit, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.BottomMargin, 1, 30));
            AddConstraint(NSLayoutConstraint.Create(passwordEdit, NSLayoutAttribute.Width, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.Width, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(enterButton, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(enterButton, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, passwordEdit, NSLayoutAttribute.BottomMargin, 1, 30));
            AddConstraint(NSLayoutConstraint.Create(enterButton, NSLayoutAttribute.Width, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.Width, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(message, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(message, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, enterButton, NSLayoutAttribute.BottomMargin, 1, 30));
        }
    }

    [Register("Account View")]
    public class AccountView : MvxViewController
    {
        public AccountViewMain accountView;

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
            View = accountView = new AccountViewMain();
            this.View.InsertSubview(new UIImageView(UIImage.FromBundle("Images/VTS_Main_Theme.png")), 0); 

            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;


            //var loginEdit = new UITextField(new RectangleF( 0, 0, 200, 40));
            //loginEdit.BackgroundColor = UIColor.Clear;
            //loginEdit.BorderStyle = UITextBorderStyle.Bezel;
            ////loginEdit.Layer.CornerRadius = new nfloat(10.0);
            ////loginEdit.Layer.BorderColor =UIColor.FromRGB(250, 250, 250);
            //loginEdit.Placeholder = "Login";
            //Add(loginEdit);

            //var passwordEdit = new UITextField(new RectangleF(0, 50, 200, 40));
            //passwordEdit.BackgroundColor = new UIColor(new nfloat(0.9), new nfloat(0.9), new nfloat(0.9), new nfloat(0.9));
            //passwordEdit.Placeholder = "Password";
            //passwordEdit.SecureTextEntry = true;
            //passwordEdit.Layer.CornerRadius = new nfloat(10.0);

            //Add(passwordEdit);

            ////View.Layer.BackgroundColor = UIColor.FromRGBA(250, 250 ,250, 40).CGColor;
            ////View.Layer.CornerRadius = new nfloat(20.0);
            ////View.Layer.Frame = new CoreGraphics.CGRect(50, 50, View.Layer.Frame.Width - 20, View.Layer.Frame.Height - 20);


            //var button = new UIButton(new RectangleF(0, 100, 200, 40));
            //button.BackgroundColor = UIColor.FromRGB(140, 173, 53);
            //button.SetTitle("Enter", new UIControlState());
            //Add(button);

            //accountView.enterButton.TouchUpInside += (sender, e) =>
            //{
            //    NSThread.SleepFor(5);
            //    if (errorMessage.Text.Length > 3)
            //    {
            //        //Create Alert
            //        var okAlertController = UIAlertController.Create("Alert", errorMessage.Text, UIAlertControllerStyle.Alert);

            //        //Add Action
            //        okAlertController.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));

            //        // Present Alert
            //        PresentViewController(okAlertController, true, null);
            //    }
            //};

            var set = this.CreateBindingSet<AccountView, AccountViewModel>();
            set.Bind(accountView.loginEdit).To(vm => vm.Login);

            set.Bind(accountView.passwordEdit).To(vm => vm.Password);

            set.Bind(accountView.enterButton).To(vm => vm.Logon);

            set.Bind(accountView.message).To(vm => vm.ErrorMessage).TwoWay();
            // Perform any additional setup after loading the view
            set.Apply();


            var gesture = new UITapGestureRecognizer(() =>
            {
                accountView.loginEdit.ResignFirstResponder();
                accountView.passwordEdit.ResignFirstResponder();
            });
            View.AddGestureRecognizer(gesture);
        }
    }
}