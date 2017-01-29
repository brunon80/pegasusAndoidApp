using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace PLaws
{
	public class FragmentSearch: Fragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			
			return inflater.Inflate(Resource.Layout.Search, container, false);
		}
	}
}
