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
    [Register("UniversalView")]
    public class UniversalView : UIView
    {
        public UniversalView()
        {
            Initialize();
        }

        public UniversalView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.White;
        }
    }

    [Register("VacationDetails")]
    public class VacationDetailsView : MvxViewController
    {
        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override void ViewDidLoad()
        {
            View = new UniversalView();

            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;


            var comment = new UILabel(new RectangleF(0, 0, 200, 40));
            comment.BackgroundColor = UIColor.Clear;
            comment.Text = "Comment";
            Add(comment);
            var commentEdit = new UITextField(new RectangleF(0, 50, 200, 40));
            commentEdit.BackgroundColor = UIColor.DarkGray;
            Add(commentEdit);

            var set = this.CreateBindingSet<VacationDetailsView, SelectedVacationViewModel>();
            
            // Perform any additional setup after loading the view
            set.Apply();
        }
    }
}