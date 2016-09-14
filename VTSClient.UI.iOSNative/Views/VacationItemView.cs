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

            

            TypeLabel = new UILabel();
            TypeLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NameLabel = new UILabel();
            StartDate = new UILabel();
            EndDate = new UILabel();
            StatusLabel = new UILabel();

            AddSubview(TypeLabel);
            AddSubview(NameLabel);
            AddSubview(StartDate);
            AddSubview(EndDate);
            AddSubview(StatusLabel);
            

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



            //this.AddConstraint(NSLayoutConstraint.Create(TypeLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.LessThanOrEqual, this, NSLayoutAttribute.CenterX, 1, 0));
            //this.AddConstraint(NSLayoutConstraint.Create(TypeLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.Top, 1, 20));
            //this.AddConstraint(NSLayoutConstraint.Create(TypeLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, 1, 0));
            //this.AddConstraint(NSLayoutConstraint.Create(TypeLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, 1, 0));



            TypeLabel.Frame = new CoreGraphics.CGRect(60, 10, 200, 30);
            NameLabel.Frame = new CoreGraphics.CGRect(60, 50, 200, 30);
            StartDate.Frame = new CoreGraphics.CGRect(50, 90, 150, 20);
            EndDate.Frame = new CoreGraphics.CGRect(200, 90, 150, 20);
            StatusLabel.Frame = new CoreGraphics.CGRect(250, 50, 100, 20);
            TypeLabel.TextColor = UIColor.Black;
            //someLabel.AddConstraints();
        }

        protected VacationItemView(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            Initialize();
            
        }
    }
}
