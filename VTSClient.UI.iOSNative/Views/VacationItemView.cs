using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using VtsMockClient.Domain.Models;

namespace VTSClient.UI.iOSNative.Views
{
    public partial class VacationItemView : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("VacationItemView");
        //public static readonly UINib Nib;

        UIImageView image;
        UILabel TypeLabel;
        UILabel NameLabel;
        UILabel StartDate;
        UILabel EndDate;
        UILabel StatusLabel;

        public VacationItemView()
        {
            //Nib = UINib.FromName("VacationItemView", NSBundle.MainBundle);
            //Initialize();

            //this.DelayBind(() =>
            //{
            //    var set = this.CreateBindingSet<VacationItemView, ShortVacationInfo>();
            //    set.Bind(TypeLabel).To(s => s.Type);
            //    set.Bind(NameLabel).To(s => s.ApproverFullName);
            //    set.Bind(StartDate).To(s => s.StartDate);
            //    set.Bind(EndDate).To(s => s.EndDate);
            //    set.Bind(StatusLabel).To(s => s.Status);
            //    set.Apply();
            //});
        }

        public void Initialize()
        {
            //someLabel = new UILabel(new CoreGraphics.CGRect());
            image = new UIImageView(UIImage.FromBundle("Images/mainIcon.jpg"));
            //image.TranslatesAutoresizingMaskIntoConstraints = false;
            TypeLabel = new UILabel();
            TypeLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NameLabel = new UILabel();
            NameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            StartDate = new UILabel();
            StartDate.TranslatesAutoresizingMaskIntoConstraints = false;
            EndDate = new UILabel();
            EndDate.TranslatesAutoresizingMaskIntoConstraints = false;
            StatusLabel = new UILabel();
            StatusLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            AddSubview(image);
            AddSubview(TypeLabel);
            AddSubview(NameLabel);
            AddSubview(StartDate);
            AddSubview(EndDate);
            AddSubview(StatusLabel);

            AddConstraint(NSLayoutConstraint.Create(TypeLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(TypeLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 20));

            AddConstraint(NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, TypeLabel, NSLayoutAttribute.BottomMargin, 1, 20));

            AddConstraint(NSLayoutConstraint.Create(StatusLabel, NSLayoutAttribute.RightMargin, NSLayoutRelation.Equal, this, NSLayoutAttribute.RightMargin, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(StatusLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterY, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(StartDate, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, -50));
            AddConstraint(NSLayoutConstraint.Create(StartDate, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, -10));

            AddConstraint(NSLayoutConstraint.Create(EndDate, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 50));
            AddConstraint(NSLayoutConstraint.Create(EndDate, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.Bottom, 1, -10));
            //AddConstraint(NSLayoutConstraint.Create(EndDate, NSLayoutAttribute.Width, NSLayoutRelation.Equal, EndDate, NSLayoutAttribute.Width, new nfloat(0.5), -10));
            //AddConstraint(NSLayoutConstraint.Create(EndDate, NSLayoutAttribute.Height, NSLayoutRelation.Equal, EndDate, NSLayoutAttribute.Height, new nfloat(0.5), -10));

            //AddConstraint(NSLayoutConstraint.Create(image, NSLayoutAttribute.LeadingMargin, NSLayoutRelation.Equal, this, NSLayoutAttribute.LeftMargin, 1, 20));
            //AddConstraint(NSLayoutConstraint.Create(image, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterY, 1, 0));
            //AddConstraint(NSLayoutConstraint.Create(image, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, new nfloat(0.5), 0));
            //AddConstraint(NSLayoutConstraint.Create(image, NSLayoutAttribute.Width, NSLayoutRelation.Equal, image, NSLayoutAttribute.Height, 1, 0));

            image.Frame = new CoreGraphics.CGRect( 10, this.Layer.Frame.Height / 2 - image.Layer.Frame.Height / 2, this.Layer.Frame.Height / 2 , 40);


            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<VacationItemView, ShortVacationInfo>();
                set.Bind(TypeLabel).To(s => s.Type);
                set.Bind(NameLabel).To(s => s.ApproverFullName);
                set.Bind(StartDate).To(s => s.StartDate);
                set.Bind(EndDate).To(s => s.EndDate);
                set.Bind(StatusLabel).To(s => s.Status);
                set.Apply();
            });
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            //TypeLabel = new UILabel();
            //NameLabel = new UILabel();
            //StartDate = new UILabel();
            //EndDate = new UILabel();
            //StatusLabel = new UILabel();







            //TypeLabel.Frame = new CoreGraphics.CGRect(60, 10, 200, 30);
            //NameLabel.Frame = new CoreGraphics.CGRect(60, 50, 200, 30);
            //StartDate.Frame = new CoreGraphics.CGRect(10, 90, 150, 20);
            //EndDate.Frame = new CoreGraphics.CGRect(160, 90, 150, 20);
            //StatusLabel.Frame = new CoreGraphics.CGRect(220, 50, 70, 20);
            //image.Draw(new CoreGraphics.CGRect(UIScreen.MainScreen.Bounds.Width / 4, UIScreen.MainScreen.Bounds.Height / 4, UIScreen.MainScreen.Bounds.Width / 2, UIScreen.MainScreen.Bounds.Height / 2)); ;
            //TypeLabel.TextColor = UIColor.Black;
            //someLabel.AddConstraints();
        }

        protected VacationItemView(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            Initialize();
            
        }
    }
}
