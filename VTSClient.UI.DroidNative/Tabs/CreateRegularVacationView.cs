using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using VTSClient.UI.DroidNative.Heplers;
using MvvmCross.Binding.BindingContext;
using VTSClient.BusinessLogic.ViewModels.CreateTabViewModel;

namespace VTSClient.UI.DroidNative.Tabs
{
    [Activity]
    public class CreateRegularVacationView : MvxActivity
    {
        TextView _dateDisplay1;
        Button _dateSelectButton1;
        TextView _dateDisplay2;
        Button _dateSelectButton2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.CreateRegularVacationView);

            _dateDisplay1 = FindViewById<TextView>(Resource.Id.date_display1);
            _dateSelectButton1 = FindViewById<Button>(Resource.Id.date_select_button1);
            _dateSelectButton1.Click += StartDateSelect_OnClick;

            _dateDisplay2 = FindViewById<TextView>(Resource.Id.date_display2);
            _dateSelectButton2 = FindViewById<Button>(Resource.Id.date_select_button2);
            _dateSelectButton2.Click += EndDateSelect_OnClick;

            

            var set = this.CreateBindingSet<CreateRegularVacationView, CreateRegularVacationViewModel>();
            set.Bind(_dateDisplay1)
                .For(v => v.Text)
                .To(vm => vm.StartD)
                .TwoWay();
            set.Bind(_dateDisplay2)
                 .For(v => v.Text)
                 .To(vm => vm.EndD)
                 .TwoWay();
            set.Apply();

            _dateDisplay1.Text = DateTime.Now.ToShortDateString();
            _dateDisplay2.Text = DateTime.Now.AddHours(8).ToShortDateString();
        }

        void StartDateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateDisplay1.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        void EndDateSelect_OnClick(object sender, EventArgs eventArgs)
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                _dateDisplay2.Text = time.ToShortDateString();
            });
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }
    }
}