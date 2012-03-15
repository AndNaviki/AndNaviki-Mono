using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace de.dhoffmann.mono.andnaviki
{
	[Activity (Label = "AndNaviki - Neue Route")]
	public class Routes_New : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Routes_New);
			
			Spinner spnCalcRouteType = FindViewById<Spinner>(Resource.Id.spnCalcRouteType);
			// spnCalcRouteType.ItemSelected += new EventHandler<ItemEventArgs>(spnCalcRouteType_ItemSelected);
			ArrayAdapter adapterCalcRouteType = ArrayAdapter.CreateFromResource(this, Resource.Array.CalcRouteType_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapterCalcRouteType.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spnCalcRouteType.Adapter = adapterCalcRouteType;

			// Get our button from the layout resource,
			// and attach an event to it
		}
	}
}

