using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;
using ObjCRuntime;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;
using VTSClient.UI.iOSNative.Helpers;
using MvvmCross.Binding.iOS.Views;

namespace VTSClient.UI.iOSNative.Views.Tabs
{
    [Register("CreateOvertimeView")]
    public class CreateOvertimeView : CreateView
    {
        public CreateOvertimeView()
            : base()
        { Initialize(); }

        void Initialize()
        {
            pickerPosition1.Active = true;
            pickerPosition2.Active = false;
            BackgroundColor = UIColor.FromRGB(240, 240, 240);
        }
    }

    [Register("CreateOvertimeVacationView")]
    public class CreateOvertimeVacationView : MvxViewController
    {

        CreateOvertimeView createView;
        public CreateOvertimeVacationView()
        {
        }

        public override void ViewDidLoad()
        {
            View = createView = new CreateOvertimeView();

            base.ViewDidLoad();

            if (RespondsToSelector(new Selector("edgesForExtendedLayout")))
                EdgesForExtendedLayout = UIRectEdge.None;

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
                    (ViewModel as CreateOvertimeVacationViewModel).StartD = start.Date.ToDateTime().ToShortDateString();
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
                    (ViewModel as CreateOvertimeVacationViewModel).EndD = end.Date.ToDateTime().ToShortDateString();
                });

                textInputAlertController.AddAction(cancelAction);
                textInputAlertController.AddAction(okayAction);

                //Present Alert
                PresentViewController(textInputAlertController, true, null);
            };

            //__________________end picker____________________

            //Add(picker);         

            (ViewModel as CreateOvertimeVacationViewModel).StartD = NSDate.Now.ToDateTime().ToShortDateString();
            (ViewModel as CreateOvertimeVacationViewModel).EndD = NSDate.Now.ToDateTime().ToShortDateString();
            var set = this.CreateBindingSet<CreateOvertimeVacationView, CreateOvertimeVacationViewModel>();
            //set.Bind(createView.startDateLabel).For(v=>v.Text).To(vm => vm.StartD).TwoWay();

            set.Bind(createView.startDateLabel).To(vm => vm.StartD).TwoWay();
            set.Bind(createView.endDateLabel).To(vm => vm.EndD).TwoWay();
            set.Bind(createView.commentEdit).To(vm => vm.Comment).TwoWay();
            set.Bind(createView.saveButton).To(vm => vm.Save);

            set.Bind(createView.pickerViewModel).For(p => p.ItemsSource).To(vm => vm.ApproverList);
            set.Bind(createView.pickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedApprover);
            set.Bind(createView.message).To(vm => vm.Message);

            set.Bind(createView.chooseImage).To(vm => vm.AddPicture);
            set.Bind(createView.selected).To(vm => vm.PictureBytes).WithConversion("InMemoryImage");
            
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