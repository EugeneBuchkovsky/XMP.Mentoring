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
    [Register("CreateRegularView")]
    public class CreateRegularView : CreateView
    {
        public UIPickerView picker;
        public MvxPickerViewModel pickerViewModel;
        public CreateRegularView()
            : base()
        { Initialize(); }

        void Initialize()
        {
            picker = new UIPickerView();
            pickerViewModel = new MvxPickerViewModel(picker);
            picker.Model = pickerViewModel;
            picker.ShowSelectionIndicator = true;
            //picker.Frame = new CoreGraphics.CGRect(0, 200, 200, 100);
            picker.BackgroundColor = UIColor.White;
            picker.TranslatesAutoresizingMaskIntoConstraints = false;


            AddSubview(picker);

            AddConstraint(NSLayoutConstraint.Create(picker, NSLayoutAttribute.CenterX, NSLayoutRelation.Equal, this, NSLayoutAttribute.CenterX, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(picker, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, startDateLabel, NSLayoutAttribute.Top, 1, -20));
            AddConstraint(NSLayoutConstraint.Create(picker, NSLayoutAttribute.Width, NSLayoutRelation.Equal, this, NSLayoutAttribute.Width, 1, 0));
            AddConstraint(NSLayoutConstraint.Create(picker, NSLayoutAttribute.Height, NSLayoutRelation.Equal, this, NSLayoutAttribute.Height, new nfloat(0.15), 0));

            BackgroundColor = UIColor.FromRGB(240, 240, 240);
        }
    }

    [Register("CreateRegularVacationView")]
    public class CreateRegularVacationView : MvxViewController
    {

        CreateRegularView createView;
        public CreateRegularVacationView()
        {
        }

        public override void ViewDidLoad()
        {
            View = createView = new CreateRegularView();

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
            start.Frame = new CoreGraphics.CGRect(0, 0, 250, 50);
            
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
                    (ViewModel as CreateRegularVacationViewModel).StartD = start.Date.ToDateTime().ToShortDateString();
                });
                


                textInputAlertController.AddAction(cancelAction);
                textInputAlertController.AddAction(okayAction);

                //Present Alert
                PresentViewController(textInputAlertController, true, null);
            };

            var end = new UIDatePicker();
            end.Mode = UIDatePickerMode.Date;
            end.Frame = new CoreGraphics.CGRect(0, 0, 250, 50);

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
                    (ViewModel as CreateRegularVacationViewModel).EndD = end.Date.ToDateTime().ToShortDateString();
                });

                textInputAlertController.AddAction(cancelAction);
                textInputAlertController.AddAction(okayAction);

                //Present Alert
                PresentViewController(textInputAlertController, true, null);
            };

            //__________________end picker____________________



            //var picker = new UIPickerView();
            //var pickerViewModel = new MvxPickerViewModel(picker);
            //picker.Model = pickerViewModel;
            //picker.ShowSelectionIndicator = true;
            //picker.Frame = new CoreGraphics.CGRect(0, 200, 200, 100);
            //picker.BackgroundColor = UIColor.White;

            //Add(picker);         

            (ViewModel as CreateRegularVacationViewModel).StartD = NSDate.Now.ToDateTime().ToShortDateString();
            (ViewModel as CreateRegularVacationViewModel).EndD = NSDate.Now.ToDateTime().ToShortDateString();
            var set = this.CreateBindingSet<CreateRegularVacationView, CreateRegularVacationViewModel>();
            //set.Bind(createView.startDateLabel).For(v=>v.Text).To(vm => vm.StartD).TwoWay();


            set.Bind(createView.startDateLabel).To(vm => vm.StartD).TwoWay();
            set.Bind(createView.endDateLabel).To(vm => vm.EndD).TwoWay();
            set.Bind(createView.commentEdit).To(vm => vm.Comment).TwoWay();
            set.Bind(createView.saveButton).To(vm => vm.Save);

            set.Bind(createView.pickerViewModel).For(p => p.ItemsSource).To(vm => vm.ApproverList);
            set.Bind(createView.pickerViewModel).For(p => p.SelectedItem).To(vm => vm.SelectedApprover);

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