using Android.App;
using Android.Widget;
using Android.OS;
using BranchXamarinSDK;
using Android.Content;
using System.Collections.Generic;
using Android.Content.PM;

namespace BranchIODemo
{
	[Activity (Label = "BranchIODemo", MainLauncher = true, Icon = "@mipmap/icon" ,LaunchMode = LaunchMode.SingleTask)]
	[IntentFilter (new [] { Android.Content.Intent.ActionView },
		Categories = new [] { Android.Content.Intent.CategoryDefault, Android.Content.Intent.CategoryBrowsable },
		DataScheme = "branchtest",
		DataHost = "open")]
	[MetaData ("io.branch.sdk.BranchKey", Value = "key_live_oei2AOhau2i0e3iiGJXb0klgCwodsLuH")]
	public class MainActivity : Activity,IBranchSessionInterface
	{
		int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);
			BranchAndroid.Debug = true;
			BranchAndroid.Init (this, "key_live_oei2AOhau2i0e3iiGJXb0klgCwodsLuH", this);
			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};
		}

		// Ensure we get the updated link identifier when the app is opened from the
		// background with a new link.
		protected override void OnNewIntent(Intent intent) {
			//BranchAndroid.getInstance().SetNewUrl(intent.Data);
			this.Intent=intent;
		}

		#region IBranchSessionInterface implementation

		public void InitSessionComplete (Dictionary<string, object> data)
		{
			// Do something with the referring link data...
		}

		public void SessionRequestError (BranchError error)
		{
			// Handle the error case here
		}

		#endregion
	}
}


