// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;

namespace de.dhoffmann.mono.andnaviki.screens
{
	[Register ("Root")]
	partial class Root
	{
		[Outlet]
		MonoTouch.UIKit.UIButton btnNewRoute { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton btnSettings { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (btnNewRoute != null) {
				btnNewRoute.Dispose ();
				btnNewRoute = null;
			}

			if (btnSettings != null) {
				btnSettings.Dispose ();
				btnSettings = null;
			}
		}
	}
}
