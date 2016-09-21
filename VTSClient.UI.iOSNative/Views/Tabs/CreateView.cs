﻿using Foundation;
using MvvmCross.Binding.iOS.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using UIKit;
using VTSClient.UI.iOSNative.Helpers;

namespace VTSClient.UI.iOSNative.Views.Tabs
{
    public class CreateView : MvxView
    {
        public UILabel startNameLabel;
        public UILabel startDateLabel;
        public UILabel endNameLabel;
        public UILabel endDateLabel;
        public UILabel commentLabel;
        public UITextField commentEdit;
        public UIButton startDateButton;
        public UIButton endDateButton;
        public UIButton saveButton;
        public UILabel message;

        public CreateView()
        {
            Initialize();
        }

        public CreateView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {

            startNameLabel = new UILabel();
            startNameLabel.BackgroundColor = UIColor.Clear;
            startNameLabel.Text = "Start date:";
            startNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            startDateLabel = new UILabel();
            startDateLabel.Text = NSDate.Now.ToDateTime().ToShortDateString();
            startDateLabel.BackgroundColor = UIColor.White;
            startDateLabel.Layer.CornerRadius = 10;
            startDateLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            endNameLabel = new UILabel();
            endNameLabel.BackgroundColor = UIColor.Clear;
            endNameLabel.Text = "End date:";
            endNameLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            endDateLabel = new UILabel();
            endDateLabel.Text = NSDate.Now.ToDateTime().ToShortDateString();
            endDateLabel.BackgroundColor = UIColor.White;
            endDateLabel.Layer.CornerRadius = 10;
            endDateLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            commentLabel = new UILabel();
            commentLabel.Text = "Comment";
            commentLabel.BackgroundColor = UIColor.White;
            commentLabel.Layer.CornerRadius = 10;
            commentLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            commentEdit = new UITextField();
            commentEdit.BackgroundColor = UIColor.White;
            commentEdit.Layer.CornerRadius = 10;
            commentEdit.TranslatesAutoresizingMaskIntoConstraints = false;

            startDateButton = new UIButton();
            startDateButton.SetImage(new UIImage("Images/datePicker.png"), new UIControlState());
            startDateButton.BackgroundColor = UIColor.Yellow;
            startDateButton.Layer.CornerRadius = 10;
            startDateButton.TranslatesAutoresizingMaskIntoConstraints = false;

            endDateButton = new UIButton();
            endDateButton.SetImage(new UIImage("Images/datePicker.png"), new UIControlState());
            endDateButton.BackgroundColor = UIColor.White;
            endDateButton.Layer.CornerRadius = 10;
            endDateButton.TranslatesAutoresizingMaskIntoConstraints = false;

            saveButton = new UIButton();
            saveButton.SetTitle("Send request", new UIControlState());
            saveButton.BackgroundColor = UIColor.FromRGB(140, 173, 53);
            saveButton.TranslatesAutoresizingMaskIntoConstraints = false;

            message = new UILabel();
            message.TextColor = UIColor.Red;
            message.TranslatesAutoresizingMaskIntoConstraints = false;

            AddSubview(startNameLabel);
            AddSubview(startDateLabel);
            AddSubview(endNameLabel);
            AddSubview(endDateLabel);
            AddSubview(commentLabel);
            AddSubview(commentEdit);
            AddSubview(startDateButton);
            AddSubview(endDateButton);
            AddSubview(saveButton);
            AddSubview(message);



            AddConstraint(NSLayoutConstraint.Create(startDateLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(startDateLabel, NSLayoutAttribute.TopMargin, NSLayoutRelation.Equal, this, NSLayoutAttribute.TopMargin, 1, 50));
            //AddConstraint(NSLayoutConstraint.Create(startDateLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, new nfloat(0.5), 0));

            AddConstraint(NSLayoutConstraint.Create(startNameLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(startNameLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, startDateLabel, NSLayoutAttribute.CenterY, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(startDateButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, startDateLabel, NSLayoutAttribute.Right, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(startDateButton, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, startDateLabel, NSLayoutAttribute.CenterY, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(startDateButton, NSLayoutAttribute.Width, NSLayoutRelation.Equal, startDateLabel, NSLayoutAttribute.Height, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(endNameLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(endNameLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, endDateLabel, NSLayoutAttribute.CenterY, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(endDateLabel, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(endDateLabel, NSLayoutAttribute.TopMargin, NSLayoutRelation.Equal, startDateButton, NSLayoutAttribute.BottomMargin, 1, 30));
            //AddConstraint(NSLayoutConstraint.Create(endDateLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, new nfloat(0.5), 0));

            AddConstraint(NSLayoutConstraint.Create(endDateButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, endDateLabel, NSLayoutAttribute.Right, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(endDateButton, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, endDateLabel, NSLayoutAttribute.CenterY, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(endDateButton, NSLayoutAttribute.Width, NSLayoutRelation.Equal, endDateLabel, NSLayoutAttribute.Height, 1, 0));

            AddConstraint(NSLayoutConstraint.Create(commentLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, this, NSLayoutAttribute.Left, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(commentLabel, NSLayoutAttribute.CenterY, NSLayoutRelation.Equal, commentEdit, NSLayoutAttribute.CenterY, 1, 0));
            //AddConstraint(NSLayoutConstraint.Create(commentLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, new nfloat(0.5), 0));

            AddConstraint(NSLayoutConstraint.Create(commentEdit, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(commentEdit, NSLayoutAttribute.TopMargin, NSLayoutRelation.Equal, endDateLabel, NSLayoutAttribute.BottomMargin, 1, 30));
            AddConstraint(NSLayoutConstraint.Create(commentEdit, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, new nfloat(0.5), 0));

            AddConstraint(NSLayoutConstraint.Create(saveButton, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(saveButton, NSLayoutAttribute.TopMargin, NSLayoutRelation.Equal, commentEdit, NSLayoutAttribute.TopMargin, 1, 30));
            AddConstraint(NSLayoutConstraint.Create(saveButton, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, new nfloat(0.5), 0));

            AddConstraint(NSLayoutConstraint.Create(message, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(message, NSLayoutAttribute.TopMargin, NSLayoutRelation.Equal, saveButton, NSLayoutAttribute.TopMargin, 1, 30));

            BackgroundColor = UIColor.White;
            //Frame = new CoreGraphics.CGRect(0, 0, this.Layer.Frame.Width, 5000);
            //ContentSize = new CoreGraphics.CGSize(this.Layer.Frame.Width, 5000);
        }
    }
}