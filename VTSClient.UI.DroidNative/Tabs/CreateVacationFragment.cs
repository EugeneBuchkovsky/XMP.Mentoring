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
using MvvmCross.Droid.FullFragging.Fragments;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Core.ViewModels;
using VTSClient.BusinessLogic.ViewModels;

namespace VTSClient.UI.DroidNative.Tabs
{
    [MvxViewFor(typeof(Tab1ViewModel))]
    public class CreateVacationFragment : MvxFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            return this.BindingInflate(Resource.Layout.CreateVacationTabView, null);
        }
    }
}