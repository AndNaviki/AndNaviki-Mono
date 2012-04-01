// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace de.dhoffmann.mono.andnaviki.screens
{
	[Register ("ProviderSelection")]
	partial class ProviderSelection
	{
		[Outlet]
		MonoTouch.UIKit.UILabel lbCountry { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnChooseCountry { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITableView lstProviders { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (lbCountry != null) {
				lbCountry.Dispose ();
				lbCountry = null;
			}

			if (btnChooseCountry != null) {
				btnChooseCountry.Dispose ();
				btnChooseCountry = null;
			}

			if (lstProviders != null) {
				lstProviders.Dispose ();
				lstProviders = null;
			}
		}
	}
}
