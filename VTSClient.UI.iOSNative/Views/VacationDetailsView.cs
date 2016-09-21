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
        public UILabel nameLabel;

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
            //nameLabel = new UILabel();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            //this.AddConstraint(NSLayoutConstraint.Create(nameLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.LessThanOrEqual, this, NSLayoutAttribute.CenterX, 1, 0));
            //this.AddConstraint(NSLayoutConstraint.Create(nameLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 20));
            //this.AddConstraint(NSLayoutConstraint.Create(nameLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, 1, 0));
            //this.AddConstraint(NSLayoutConstraint.Create(nameLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, 1, 0));

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
        public UniversalView MyView;

        public override void ViewDidLoad()
        {
            View = MyView = new UniversalView();

            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;


            var nameLabel = new UILabel(new RectangleF(50, 0, 200, 50));
            nameLabel.BackgroundColor = UIColor.Clear;
            Add(nameLabel);
            var typeLabel = new UILabel(new RectangleF(50, 60, 200, 40));
            typeLabel.BackgroundColor = UIColor.Clear;
            Add(typeLabel);
            var StatusLabel = new UILabel(new RectangleF(50, 110, 200, 40));
            StatusLabel.BackgroundColor = UIColor.Clear;
            Add(StatusLabel);
            var startDate = new UILabel(new RectangleF(50, 160, 200, 40));
            startDate.BackgroundColor = UIColor.Clear;
            Add(startDate);
            var endDate = new UILabel(new RectangleF(50, 210, 200, 40));
            endDate.BackgroundColor = UIColor.Clear;
            Add(endDate);
            var comment = new UIButton();
            comment.Frame = new CoreGraphics.CGRect(50, 260, 200, 40);
            //var comment = new UILabel(new RectangleF(50, 260, 200, 40));
            comment.BackgroundColor = UIColor.FromRGBA(10, 10, 10, 10);
            comment.SetTitle("Comment>", new UIControlState());
            Add(comment);
            //var commentEdit = new UITextField(new RectangleF(50, 310, 200, 40));
            var commentEdit = new UITextField();
            commentEdit.Frame = new CoreGraphics.CGRect(0, 0, 250, 35);
            commentEdit.BackgroundColor = UIColor.Clear;
            commentEdit.Layer.BorderWidth = 1;
            commentEdit.Layer.CornerRadius = 10;
            //Add(commentEdit);
            var saveButton = new UIButton(new CoreGraphics.CGRect(50, 310, 200, 40));
            saveButton.BackgroundColor = UIColor.FromRGB(140, 173, 53);
            saveButton.SetTitle("Save", new UIControlState());
            Add(saveButton);

            var set = this.CreateBindingSet<VacationDetailsView, SelectedVacationViewModel>();
            set.Bind(typeLabel).To(vm => vm.Type);
            set.Bind(nameLabel).To(vm => vm.Name);
            set.Bind(StatusLabel).To(vm => vm.Status);
            set.Bind(startDate).To(vm => vm.StartDate);
            set.Bind(endDate).To(vm => vm.EndDate);
            set.Bind(commentEdit).To(vm => vm.Comment).TwoWay();
            set.Bind(saveButton).To(vm => vm.Save);
            // Perform any additional setup after loading the view
            set.Apply();

            //Create comment modal page
            comment.TouchUpInside += (sender, e) =>
            {
                //Create Alert
                var textInputAlertController = UIAlertController.Create("", "", UIAlertControllerStyle.Alert);
                //commentEdit.Frame = new CoreGraphics.CGRect(0, 0, textInputAlertController.PopoverPresentationController.FrameOfPresentedViewInContainerView.Width, 35);
                //Add Text Input
                textInputAlertController.Add(commentEdit);
                //if (textInputAlertController.PopoverPresentationController != null)
                //    textInputAlertController.PopoverPresentationController.SourceRect = new CoreGraphics.CGRect(0, 0, 200, 200);
                //textInputAlertController.PreferredContentSize = new CoreGraphics.CGSize(View.Frame.Width, View.Frame.Height / 2);
                //Add Actions
                var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => { }); 
                var okayAction = UIAlertAction.Create("Okay", UIAlertActionStyle.Default, alertAction => { });

                textInputAlertController.AddAction(cancelAction);
                textInputAlertController.AddAction(okayAction);

                //Present Alert
                PresentViewController(textInputAlertController, true, null);
            };
            //____end_____

            var gesture = new UITapGestureRecognizer(() =>
            {
                commentEdit.ResignFirstResponder();
            });
            View.AddGestureRecognizer(gesture);
        }
    }
}