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


using Java.IO;
using Environment = Android.OS.Environment;
using Uri = Android.Net.Uri;
using Android.Graphics;
using Android.Provider;
using Android.Content.PM;

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


            //IMAGES
            var filesButton = FindViewById<Button>(Resource.Id.imagesButton);

            filesButton.Click += delegate {
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(
                    Intent.CreateChooser(imageIntent, "Select photo"), 0);
            };

            //CAMERA
            //if (IsThereAnAppToTakePictures())
            //{
            //    CreateDirectoryForPictures();


            //    Button button = FindViewById<Button>(Resource.Id.cameraButton);
            //    _imageView = FindViewById<ImageView>(Resource.Id.imageView1);
            //    button.Click += TakeAPicture;
            //}
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


        // images
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                var imageView =
                    FindViewById<ImageView>(Resource.Id.imageView1);
                imageView.SetImageURI(data.Data);
            }
        }


        //CAMERA

        //   public static class App
        //   { 
        //    public static File _file; 
        //    public static File _dir;      
        //    public static Bitmap bitmap; 
        //}

        //   private ImageView _imageView; 


        //    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //    { 
        //        base.OnActivityResult(requestCode, resultCode, data); 


        //        // Make it available in the gallery 


        //        Intent mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile); 
        //        Uri contentUri = Uri.FromFile(App._file); 
        //        mediaScanIntent.SetData(contentUri); 
        //        SendBroadcast(mediaScanIntent); 


        //        // Display in ImageView. We will resize the bitmap to fit the display 
        //       // Loading the full sized image will consume to much memory  
        //        // and cause the application to crash. 


        //        int height = Resources.DisplayMetrics.HeightPixels; 
        //        int width = _imageView.Height; 
        //        App.bitmap = App._file.Path.LoadAndResizeBitmap(width, height); 
        //        if (App.bitmap != null) { 
        //            _imageView.SetImageBitmap (App.bitmap); 
        //            App.bitmap = null; 
        //        } 


        //        // Dispose of the Java side bitmap. 
        //        //GC.Collect(); 
        //    } 

        //    private void CreateDirectoryForPictures()
        //    { 
        //        App._dir = new File( 
        //            Environment.GetExternalStoragePublicDirectory( 
        //                Environment.DirectoryPictures), "CameraAppDemo"); 
        //        if (!App._dir.Exists()) 
        //        { 
        //            App._dir.Mkdirs(); 
        //        } 
        //    } 


        //    private bool IsThereAnAppToTakePictures()
        //   { 
        //        Intent intent = new Intent(MediaStore.ActionImageCapture); 
        //        IList<ResolveInfo> availableActivities =
        //            PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly); 
        //        return availableActivities != null && availableActivities.Count > 0; 
        //    } 


        //   private void TakeAPicture(object sender, EventArgs eventArgs)
        //    { 
        //        Intent intent = new Intent(MediaStore.ActionImageCapture); 


        //        App._file = new File(App._dir, String.Format("myPhoto_{0}.jpg", Guid.NewGuid())); 


        //        intent.PutExtra(MediaStore.ExtraOutput, Uri.FromFile(App._file)); 


        //        StartActivityForResult(intent, 0); 
        //    } 

    }
}