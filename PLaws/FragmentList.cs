using System;
using Android.App;
using Android.OS;
using Android.Text;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace PLaws
{
	public class FragmentList: Fragment, AdapterView.IOnItemClickListener
	{
		string[] lawDesc;
		string[] lawNum;
		Laws[] LawsArray;
		ListView laws;
		LawsAdapter adapter;
		Communicator communicator;

		public FragmentList(string[] lawDesc, string[] lawNum )
		{
			this.lawDesc = lawDesc;
			this.lawNum = lawNum;
		}

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			Console.WriteLine("OnCreateView CALLED LIST");
			return inflater.Inflate(Resource.Layout.List, container, false);
		}

		public override void OnActivityCreated(Bundle savedInstanceState)
		{
			
			base.OnActivityCreated(savedInstanceState);
			LawsArray = new Laws[lawDesc.Length];
			for (int i = 0; i < lawDesc.Length; i++)
			{
				LawsArray[i] = new Laws(lawDesc[i], lawNum[i]);
			}
			communicator = (Communicator)Activity;
			laws = Activity.FindViewById<ListView>(Resource.Id.listViewLaws);
			adapter = new LawsAdapter(Activity, LawsArray);
			laws.Adapter = adapter;
			laws.OnItemClickListener = this;
		}


		public void OnItemClick(AdapterView parent, View view, int position, long id)
		{
			// Android.Widget.Toast.MakeText(Activity, statesName[position], Android.Widget.ToastLength.Short).Show();
			communicator.changeListData();
		}

		public void searchOnList(string name) {
			adapter.Filter.InvokeFilter(name);
		}
	}
}
