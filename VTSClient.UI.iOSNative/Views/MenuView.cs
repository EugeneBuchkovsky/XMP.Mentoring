using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace VTSClient.UI.iOSNative.Views
{
    [Register("MenuView")]
    public class MenuView : UITableView
    {
        public MenuView()
        {
            Initialize();
        }

        public MenuView(RectangleF bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.FromRGBA(70, 69, 71, 250);
        }
    }
}