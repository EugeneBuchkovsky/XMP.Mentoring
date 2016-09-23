using System;

using Foundation;
using UIKit;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Binding.BindingContext;
using VtsMockClient.Domain.Models;
using VTSClient.BusinessLogic.ViewModels;

namespace VTSClient.UI.iOSNative.Views
{
    public partial class MenuItemView : MvxTableViewCell
    {
        public static readonly NSString Key = new NSString("MenuItemView");
        //public static readonly UINib Nib;

        UILabel NameLabel;

        public MenuItemView()
        {
        }

        public void Initialize()
        {
            NameLabel = new UILabel();
            NameLabel.TextColor = UIColor.White;
            NameLabel.Font = UIFont.FromName("AvenirNext-DemiBold", 15f);

            NameLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            
            AddSubview(NameLabel);
            
            AddConstraint(NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(NameLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterY, 1, 0));

            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MenuItemView, MenuViewModel>();
                set.Bind(NameLabel).For(l=>l.Text).To(s => s.Title);
                set.Apply();
            });


            BackgroundColor = UIColor.Clear;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            
        }

        protected MenuItemView(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.

            Initialize();
            
        }
    }
}
