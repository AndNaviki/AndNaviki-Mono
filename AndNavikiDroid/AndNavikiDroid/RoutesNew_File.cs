using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace de.dhoffmann.mono.andnaviki
{
	[Activity (Label = "AndNaviki - Neue Route")]
	public class RoutesNew_File : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.RoutesNew_File);

			// Get our button from the layout resource,
			// and attach an event to it
		}
	}
}

