using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace de.dhoffmann.mono.andnaviki
{
	[Activity (Label = "AndNaviki", MainLauncher = true)]
	public class Root : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Root);

			// Get our button from the layout resource,
			// and attach an event to it
			Button btnNewRoute = FindViewById<Button> (Resource.Id.btnNewRoute);
			btnNewRoute.Click += delegate {
				StartActivity(typeof(ProviderSelection));
			};
		}
	}
}


