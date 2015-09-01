using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using MonkeySearch.Models;
using System.Linq;
using CoreSpotlight;

namespace MonkeySearch
{
    partial class MonkeyTableViewController : UITableViewController
    {


        public MonkeyTableViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            TableView.Source = new MoneySource(Helpers.MonkeyHelper.Monkeys);
            TableView.ReloadData();
        }

        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
            base.PrepareForSegue(segue, sender);

            if (segue.Identifier == "monkeyDetailsSegue")
            { // set in Storyboard
                var navctlr = segue.DestinationViewController as DetailsViewController;
                if (navctlr != null)
                {
                    navctlr.SetMonkey(Helpers.MonkeyHelper.Monkeys[TableView.IndexPathForSelectedRow.Row]);
                }
            }
        }


        public class MoneySource : UITableViewSource
        {

            List<Monkey> monkeys;
            NSString cellIdentifier = new NSString("monkeyCell");

            public MoneySource(List<Monkey> monkeys)
            {
                this.monkeys = monkeys;
            }

            #region implemented abstract members of UITableViewSource

            public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
            {
                var cell = tableView.DequeueReusableCell(cellIdentifier) as MonkeyCell ?? new MonkeyCell(cellIdentifier);
                //cell.Image = new UIImage(monkeys[indexPath.Row].Image);
                cell.Name = monkeys[indexPath.Row].Name;
                return cell;
            }

            public override nint RowsInSection(UITableView tableview, nint section)
            {
                return (nint)monkeys.Count;
            }

            #endregion
        }
    }
}
