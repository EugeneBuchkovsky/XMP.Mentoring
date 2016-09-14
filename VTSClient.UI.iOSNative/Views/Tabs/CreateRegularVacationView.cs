using System;
using System.Drawing;

using CoreFoundation;
using UIKit;
using Foundation;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;
using ObjCRuntime;
using MvvmCross.iOS.Views;
using MvvmCross.Binding.BindingContext;

namespace VTSClient.UI.iOSNative.Views.Tabs
{
    [Register("AddVacView")]
    public class AddVacView : UIView
    {
        public AddVacView()
        {
            Initialize();
        }

        public AddVacView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Red;
        }
    }

    [Register("CreateRegularVacationView")]
    public class CreateRegularVacationView : MvxViewController
    {
        public CreateRegularVacationView()
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

            var set = this.CreateBindingSet<CreateRegularVacationView, CreateRegularVacationViewModel>();
            //set.Bind(type).To(vm => vm.Type);

            //set.Bind(name).To(vm => vm.Name);

            //set.Bind(status).To(vm => vm.Status);
            // Perform any additional setup after loading the view
            set.Apply();
        }
    }
}