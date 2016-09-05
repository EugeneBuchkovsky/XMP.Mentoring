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

//using MvvmCross.Droid.Views;
using MvvmCross.Core.ViewModels;
using VTSClient.BusinessLogic.ViewModels;

using MvvmCross.Droid.FullFragging.Fragments;
using MvvmCross.Droid.FullFragging;
using MvvmCross.Droid.FullFragging.Views;
using Android.Support.V4.Widget;
using MvvmCross.Binding.Droid.Views;
using VTSClient.UI.DroidNative.Heplers;

namespace VTSClient.UI.DroidNative.Views
{
    [Activity(Label = "Vacations", MainLauncher = false)]
    [MvxViewFor(typeof(VacationsViewModel))]
    public class VacationsView : MvxActivity
    {
        private DrawerLayout m_Drawer;
        private MyActionBarDrawerToggle drawerToggle;
        private ListView m_List;
        private string _title;

        private string _drawerTitle;

        private VacationsViewModel m_ViewModel;
        public new VacationsViewModel ViewModel
        {
            get { return this.m_ViewModel ?? (this.m_ViewModel = base.ViewModel as VacationsViewModel); }
        }

        //protected override void OnViewModelSet()
        //{
        //    SetContentView(Resource.Layout.VacationsLayout);
        //}

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.VacationsLayout);

            this._title = this._drawerTitle = this.Title;

            this.m_Drawer = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            this.m_List = this.FindViewById<MvxListView>(Resource.Id.left_drawer);
            this.drawerToggle = new MyActionBarDrawerToggle(this, this.m_Drawer, Resource.Drawable.ic_drawer_light, Resource.String.drawer_open, Resource.String.drawer_close);


            //this.m_List.Adapter = new ArrayAdapter<string>(this, Resource.Layout.Item_menu, Sections);
            this.m_List.ItemClick += DrawerListOnItemClick;


            this.drawerToggle.DrawerClosed += delegate
             {
                 this.ActionBar.Title = this._title;
                 this.InvalidateOptionsMenu();
             };






            //You can alternatively use _drawer.DrawerOpened here 
            this.drawerToggle.DrawerOpened += delegate
            {
                this.ActionBar.Title = this._drawerTitle;
                this.InvalidateOptionsMenu();
            };



            m_Drawer.SetDrawerListener(drawerToggle);   

        }

        private void DrawerListOnItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Android.Support.V4.App.Fragment fragment = null;
            this.m_Drawer.CloseDrawer(m_List);
        }
    }
}