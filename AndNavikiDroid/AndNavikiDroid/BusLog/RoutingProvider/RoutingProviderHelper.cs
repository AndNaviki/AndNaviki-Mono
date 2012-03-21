using System;

namespace de.dhoffmann.mono.andnaviki.buslog.routingprovider
{
	public class RoutingProviderHelper
	{
		private string[] routingProvider = {
			"Naviki.org",
			"Datei",
			"Webadresse"
		};
		
		public RoutingProviderHelper ()
		{
			
			
			
		}
		
		public string[] RoutingProvider
		{
			get 
			{
				return routingProvider;
			}
		}
		
	}
}

