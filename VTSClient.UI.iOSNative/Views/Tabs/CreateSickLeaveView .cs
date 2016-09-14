using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using ObjCRuntime;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace VTSClient.UI.iOSNative.Views.Tabs
{

    [Register("CreateSickLeaveView")]
    public class CreateSickLeaveView : MvxViewController
    {
        public CreateSickLeaveView()
        {
        }
        

        public override void ViewDidLoad()
        {
            View = new AddVacView();

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

            var set = this.CreateBindingSet<CreateSickLeaveView, CreateRegularVacationViewModel>();
            //set.Bind(type).To(vm => vm.Type);

            //set.Bind(name).To(vm => vm.Name);

            //set.Bind(status).To(vm => vm.Status);
            // Perform any additional setup after loading the view
            set.Apply();
        }
    }
}