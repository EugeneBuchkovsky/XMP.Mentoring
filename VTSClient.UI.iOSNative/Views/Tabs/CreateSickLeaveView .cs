using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using ObjCRuntime;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using VTSClient.UI.iOSNative.Helpers;

namespace VTSClient.UI.iOSNative.Views.Tabs
{
    [Register("CreateSickView")]
    public class CreateSickView : CreateView
    {
        public CreateSickView()
            : base()
        { Initialize(); }

        void Initialize()
        {
            picker.RemoveFromSuperview();
            pickerPosition1.Active = false;
            pickerPosition2.Active = true;
            BackgroundColor = UIColor.FromRGB(240, 240, 240);
        }
    }

    [Register("CreateSickLeaveView")]
    public class CreateSickLeaveView : MvxViewController
    {
        CreateSickView createView;
        public CreateSickLeaveView()
        {
        }
        

        public override void ViewDidLoad()
        {
            View = createView = new CreateSickView();

            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

            //var startDate = new UIDatePicker(new CoreGraphics.CGRect(50, 150, 200, 200));
            //Add(startDate);

            //var comment = new UILabel(new RectangleF(0, 0, 200, 40));
            //comment.BackgroundColor = UIColor.Clear;
            //comment.Text = "Comment";
            //Add(comment);

            //var commentEdit = new UITextField(new RectangleF(0, 50, 200, 40));
            //commentEdit.BackgroundColor = UIColor.DarkGray;
            //Add(commentEdit);


            //var actionDatePicker = new ActionShowDatePicker(this.View);

            //var title = new UILabel(new CoreGraphics.CGRect(0, 150, 300, 50));
            //title.TextColor = UIColor.Black;
            //var dateButton = new UIButton(new CoreGraphics.CGRect(0, 200, 50, 50));
            //dateButton.BackgroundColor = UIColor.Yellow;


            //dateButton.TouchUpInside += (sender, e) =>
            //{
            //    actionDatePicker.Show();
            //};


            //actionDatePicker.Title = "Choose Date:";
            //actionDatePicker.DatePicker.Mode = UIDatePickerMode.DateAndTime;
            //actionDatePicker.DatePicker.MinimumDate = NSDate.Now;
            //actionDatePicker.DatePicker.MaximumDate = NSDate.Now;



            //actionDatePicker.DatePicker.ValueChanged += (s, e) => {
            //    title.Text = (s as UIDatePicker).Date.ToString();
            //  };

            //DATA PICKER 
            var start = new UIDatePicker();
            start.Mode = UIDatePickerMode.Date;
            start.Frame = new CoreGraphics.CGRect(0, 0, 280, 50);

            createView.startDateButton.TouchUpInside += (sender, e) =>
            {
                //Create Alert
                var textInputAlertController = UIAlertController.Create("", "", UIAlertControllerStyle.Alert);
                //Add Text Input
                textInputAlertController.Add(start);
                textInputAlertController.ModalPresentationStyle = UIModalPresentationStyle.FullScreen;

                //Add Actions
                var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => { });
                //var okayAction = UIAlertAction.Create("Okay", UIAlertActionStyle.Default, alertAction => createView.startDateLabel.Text = start.Date.ToDateTime().ToShortDateString());
                var okayAction = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, alertAction =>
                {
                    (ViewModel as CreateSickLeaveViewModel).StartD = start.Date.ToDateTime().ToShortDateString();
                });



                textInputAlertController.AddAction(cancelAction);
                textInputAlertController.AddAction(okayAction);

                //Present Alert
                PresentViewController(textInputAlertController, true, null);
            };

            var end = new UIDatePicker();
            end.Mode = UIDatePickerMode.Date;
            end.Frame = new CoreGraphics.CGRect(0, 0, 280, 50);

            createView.endDateButton.TouchUpInside += (sender, e) =>
            {
                //Create Alert
                var textInputAlertController = UIAlertController.Create("", "", UIAlertControllerStyle.Alert);
                //Add Text Input
                textInputAlertController.Add(end);


                //Add Actions
                var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => { });
                var okayAction = UIAlertAction.Create("Ok", UIAlertActionStyle.Default, alertAction =>
                {
                    (ViewModel as CreateSickLeaveViewModel).EndD = end.Date.ToDateTime().ToShortDateString();
                });

                textInputAlertController.AddAction(cancelAction);
                textInputAlertController.AddAction(okayAction);

                //Present Alert
                PresentViewController(textInputAlertController, true, null);
            };

            //__________________end picker____________________


            //var textInputAlert = UIAlertController.Create("1", "2", UIAlertControllerStyle.ActionSheet);
            //textInputAlert.Add(new UIDatePicker());
            ////Add Actions
            //var cancelAction = UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, alertAction => Console.WriteLine("Cancel was Pressed"));

            //textInputAlert.AddAction(cancelAction);

            ////Present Alert
            //PresentViewController(textInputAlert, true, null);




            //Add(title);
            //Add(dateButton);


            (ViewModel as CreateSickLeaveViewModel).StartD = NSDate.Now.ToDateTime().ToShortDateString();
            (ViewModel as CreateSickLeaveViewModel).EndD = NSDate.Now.ToDateTime().ToShortDateString();
            var set = this.CreateBindingSet<CreateSickLeaveView, CreateSickLeaveViewModel>();
            //set.Bind(createView.startDateLabel).For(v=>v.Text).To(vm => vm.StartD).TwoWay();


            set.Bind(createView.startDateLabel).To(vm => vm.StartD).TwoWay();
            set.Bind(createView.endDateLabel).To(vm => vm.EndD).TwoWay();
            set.Bind(createView.commentEdit).To(vm => vm.Comment).TwoWay();
            set.Bind(createView.saveButton).To(vm => vm.Save);

            set.Bind(createView.message).To(vm => vm.Message);


            //set.Bind(name).To(vm => vm.Name);

            //set.Bind(status).To(vm => vm.Status);
            // Perform any additional setup after loading the view
            set.Apply();

            var gesture = new UITapGestureRecognizer(() =>
            {
                createView.commentEdit.ResignFirstResponder();
            });
            View.AddGestureRecognizer(gesture);
        }
    }
}