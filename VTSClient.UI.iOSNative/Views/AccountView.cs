using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using MvvmCross.iOS.Views;
using VTSClient.BusinessLogic.ViewModels;
using MvvmCross.Binding.BindingContext;
using ObjCRuntime;
using CoreGraphics;

namespace VTSClient.UI.iOSNative.Views
{
    [Register("AccountViewMain")]
    public class AccountViewMain : UIView
    {
        public UITextField loginEdit;
        public UITextField passwordEdit;
        public UIButton enterButton;
        public UILabel message;
        public UIImageView logo;

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
            loginEdit.BorderStyle = UITextBorderStyle.RoundedRect;
            loginEdit.BackgroundColor = new UIColor(new nfloat(0.9), new nfloat(0.9), new nfloat(0.9), new nfloat(0.2));
            loginEdit.Layer.CornerRadius = 10;
            //loginEdit.Layer.BorderColor =UIColor.FromRGB(250, 250, 250);
            loginEdit.Placeholder = "Login";
            loginEdit.TranslatesAutoresizingMaskIntoConstraints = false;

            passwordEdit = new UITextField();
            passwordEdit.BorderStyle = UITextBorderStyle.RoundedRect;
            passwordEdit.BackgroundColor = new UIColor(new nfloat(0.9), new nfloat(0.9), new nfloat(0.9), new nfloat(0.2));
            passwordEdit.Layer.CornerRadius = 10;
            passwordEdit.SecureTextEntry = true;
            passwordEdit.Placeholder = "Password";
            passwordEdit.TranslatesAutoresizingMaskIntoConstraints = false;

            enterButton = new UIButton();
            enterButton.BackgroundColor = UIColor.FromRGB(140, 173, 53);
            enterButton.SetTitle("Enter", new UIControlState());
            enterButton.TranslatesAutoresizingMaskIntoConstraints = false;

            message = new UILabel();
            message.TextColor = UIColor.Red;
            message.TranslatesAutoresizingMaskIntoConstraints = false;

            logo = new UIImageView(UIImage.FromBundle("Images/Logo_Epam_Color.png"));
            logo.TranslatesAutoresizingMaskIntoConstraints = false;

            AddSubview(loginEdit);
            AddSubview(passwordEdit);
            AddSubview(enterButton);
            AddSubview(message);
            AddSubview(logo);

            AddConstraint(NSLayoutConstraint.Create(loginEdit, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(loginEdit, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterY, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(loginEdit, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, new nfloat(0.5), 0));
            AddConstraint(NSLayoutConstraint.Create(loginEdit, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, new nfloat(0.1), 0));

            AddConstraint(NSLayoutConstraint.Create(passwordEdit, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(passwordEdit, NSLayoutAttribute.Top, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.Bottom, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(passwordEdit, NSLayoutAttribute.Width, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.Width, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(passwordEdit, NSLayoutAttribute.Height, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.Height, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(enterButton, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(enterButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, passwordEdit, NSLayoutAttribute.Bottom, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(enterButton, NSLayoutAttribute.Width, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.Width, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(enterButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, loginEdit, NSLayoutAttribute.Height, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(message, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(message, NSLayoutAttribute.Top, NSLayoutRelation.Equal, enterButton, NSLayoutAttribute.Bottom, 1, 0));


            AddConstraint(NSLayoutConstraint.Create(logo, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(logo, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, 0));
        }
    }

    [Register("Account View")]
    public class AccountView : MvxViewController
    {
        private UIView activeview;             // Controller that activated the keyboard
        private float scroll_amount = 0.0f;    // amount to scroll 
        private float bottom = 0.0f;           // bottom point
        private float offset = 30.0f;          // extra offset
        private bool moveViewUp = false;           // which direction are we moving

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

            NavigationController.NavigationBarHidden = true;

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.DidShowNotification, KeyBoardUpNotification);
            NSNotificationCenter.DefaultCenter.AddObserver(UIKeyboard.WillHideNotification, KeyBoardDownNotification);

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

        private void KeyBoardUpNotification(NSNotification notification)
        {
            
            
            //var frame = View.Frame;
            //if (scroll_amount > 0)
            //    frame.Y -= scroll_amount;
            //else
            //    frame.Y += scroll_amount;
            //scroll_amount = 0;
            //View.Frame = frame;

            //if (scroll_amount > 0)
            //    ScrollTheView(false);
            //else
            //    ScrollTheView(true);
            //scroll_amount = 0;

            // get the keyboard size
            CoreGraphics.CGRect r = UIKeyboard.BoundsFromNotification(notification);

            // Find what opened the keyboard
            foreach (UIView view in this.View.Subviews)
            {
                if (view.IsFirstResponder)
                    activeview = view;
            }

            var a = r.Height;
            //System.Diagnostics.Debug.Print("1___________");
            //System.Diagnostics.Debug.Print("scroll" + scroll_amount.ToString());
            //System.Diagnostics.Debug.Print("Frame Y" + activeview.Frame.Y.ToString());
            //System.Diagnostics.Debug.Print("frame height" + activeview.Frame.Height.ToString());

            //// Bottom of the controller = initial position + height + offset      
            //bottom = (float)(activeview.Frame.Y + activeview.Frame.Height + offset);

            //// Calculate how far we need to scroll
            //scroll_amount = (float)(r.Height - (View.Frame.Size.Height - bottom));

            scroll_amount = (float)r.Height/3;

            //Perform the scrolling
            if (scroll_amount > 0)
            {
                moveViewUp = true;
                ScrollTheView(moveViewUp);
            }
            else {
                moveViewUp = false;
            }


            //moveViewUp = true;
            //ScrollTheView(moveViewUp);


        }

        private void KeyBoardDownNotification(NSNotification notification)
        {
            System.Diagnostics.Debug.Print("2");

            if (moveViewUp) { ScrollTheView(false); }
        }

        private void ScrollTheView(bool move)
        {

            // scroll the view up or down
            UIView.BeginAnimations(string.Empty, System.IntPtr.Zero);
            UIView.SetAnimationDuration(0.2);

            CoreGraphics.CGRect frame = View.Frame;

            if (move)
            {
                frame.Y -= scroll_amount;
            }
            else
            {
                frame.Y += scroll_amount;
                scroll_amount = 0;
            }

            View.Frame = frame;
            UIView.CommitAnimations();
        }
    }
}