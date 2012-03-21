using System;
using Android.App;
using Android.OS;
using Android.Widget;
using Android.Content;
using de.dhoffmann.mono.andnaviki.buslog.routingprovider;

namespace de.dhoffmann.mono.andnaviki
{
	[Activity (Label = "AndNaviki - Providerauswahl")]
	public class ProviderSelection : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.ProviderSelection);
			
			Spinner spnCountry = FindViewById<Spinner>(Resource.Id.spnCountry);

			ArrayAdapter adapterCountries = ArrayAdapter.CreateFromResource(this, Resource.Array.Countries_array, Android.Resource.Layout.SimpleSpinnerItem);
			adapterCountries.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
			spnCountry.Adapter = adapterCountries;
			
			RoutingProviderHelper routingProviderHelper = new RoutingProviderHelper();
			
			ListView lstProvider = FindViewById<ListView>(Resource.Id.lstProvider);
			ArrayAdapter<string> adapterProvider = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, routingProviderHelper.RoutingProvider);
			lstProvider.Adapter = adapterProvider;
			
			// Providerauswahl 
			lstProvider.ItemClick += delegate(object sender, ItemEventArgs e) {
				
				switch(((Android.Widget.TextView)e.View).Text.ToLower()) 
				{
					case "naviki.org":
						StartActivity(typeof(RoutesNew_NavikiOrg));
						break;
					case "datei":
						StartActivity(typeof(RoutesNew_File));
						break;
					case "webadresse":
						StartActivity(typeof(RoutesNew_Url));
						break;
				}
			};
			
		}
			
	}
}

