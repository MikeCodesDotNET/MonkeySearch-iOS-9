using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MonkeySearch
{
    partial class MonkeyCell : UITableViewCell
    {
        public MonkeyCell(IntPtr handle)
            : base(handle)
        {
        }


        public MonkeyCell(NSString cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
        }

        public string Name
        {
            get
            {
                return lblName.Text;
            }
            set
            {
                lblName.Text = value;
            }
        }

        public UIImage Image
        {
            get
            {
                return imgPhoto.Image;
            }
            set
            {
                imgPhoto.Image = value;
            }
        }
    }
}
