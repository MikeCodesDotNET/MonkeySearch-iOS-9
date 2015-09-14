using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Linq;
using CoreSpotlight;
using MonkeySearch.Models;

namespace MonkeySearch
{
    partial class DetailsViewController : UIViewController
    {
        const string activityName = "com.xamarin.monkeys.monkey";

        public DetailsViewController(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            UserActivity = CreateActivity();

            lblName.Text = monkey.Name;
            lblDescription.Text = monkey.Details;
        }

        Monkey monkey;

        public void SetMonkey(Monkey monkey)
        {
            this.monkey = monkey;
        }

        NSUserActivity CreateActivity()
        {

            var activity = new NSUserActivity(activityName);
            activity.EligibleForSearch = true;
            activity.EligibleForPublicIndexing = true;
            activity.EligibleForHandoff = false;

            activity.Title = monkey.Name;
            activity.AddUserInfoEntries(NSDictionary.FromObjectAndKey(new NSString(monkey.Name), new NSString("Name")));

			var keywords = new NSString[] { (NSString)monkey.Name, (NSString)"Monkey" };
            activity.Keywords = new NSSet<NSString>(keywords);
            activity.ContentAttributeSet = new CoreSpotlight.CSSearchableItemAttributeSet(monkey.Details);

            return activity;

        }
    }
}
