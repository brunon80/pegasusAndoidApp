using System;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace PLaws
{
	public class FragmentTextLaw: Fragment
	{
		TextView textLaw;
		readonly string text;
		public FragmentTextLaw(string text) {
			this.text = text;
		}
		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			return inflater.Inflate(Resource.Layout.LawText, container, false);
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			base.OnActivityCreated(savedInstanceState);
			textLaw = Activity.FindViewById<TextView>(Resource.Id.lawTextView);
			textLaw.Text = text;
		}
	}
}
