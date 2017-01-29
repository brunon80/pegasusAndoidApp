using System;
using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Graphics;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace PLaws
{
	public class LawsAdapter : BaseAdapter<Laws>, IFilterable
	{

		// Data
		public Laws[] items;
		public Laws[] MatchItems;
		Activity context;
		ItemFilter mFilter;
		//Default constructor

		public LawsAdapter(Activity context, Laws[] items)
		{
			mFilter = new ItemFilter(this);
			this.context = context;
			this.items = items;
			this.MatchItems = items;
		}
		// Return a row identifier
		public override long GetItemId(int position)
		{
			return position;
		}
		//return the data associated with a particular row number.

		public override Laws this[int position]
		{
			get { return MatchItems[position]; }
		}
		//tells how many rows are in the data.
		public override int Count
		{
			get { return MatchItems.Length; }
		}

		public Filter Filter
		{
			get
			{
				return mFilter;
			}
		}

		//Return a View for each row, populated with data.
		public override View GetView(int position, View convertView, ViewGroup parent)
		{
			var view = convertView; // re-use an existing view, in one is available

			if (view == null) // otherwise create a new one
				view = context.LayoutInflater.Inflate(Resource.Layout.TextViewItem, null);
			view.FindViewById<TextView>(Resource.Id.textView1).Text = MatchItems[position].Desc; //+ " Pop:" + items[position].Pop;
			view.FindViewById<TextView>(Resource.Id.textView2).Text = MatchItems[position].Num;
			if (position % 2 == 0)
			{
				view.SetBackgroundColor(Color.Rgb(255, 255, 255));
				view.FindViewById<TextView>(Resource.Id.textView2).SetTextColor(Color.Gray);
			}
			else {
				view.SetBackgroundColor(Color.Argb(200 ,239, 64, 35));
				view.FindViewById<TextView>(Resource.Id.textView2).SetTextColor(Color.White);
			}

			return view;
		}

		public void ResetSearch()
		{
			MatchItems = items;
			NotifyDataSetChanged();
		}

	}

	class ItemFilter : Filter {

		readonly LawsAdapter _adapter;
		public ItemFilter(LawsAdapter adapter) {
			_adapter = adapter;
		}

		protected override FilterResults PerformFiltering(ICharSequence constraint)
		{
			FilterResults results = new FilterResults();
			var searchFor = constraint.ToString();
			if (constraint.ToString() != null)
			{
				var matchList = new List<Laws>();
				var matches =
					from i in _adapter.items
						where i.Desc.IndexOf(searchFor, StringComparison.InvariantCultureIgnoreCase) >= 0
						select i;
				foreach (var match in matches)
				{
					matchList.Add(match);
				}
				_adapter.MatchItems = matchList.ToArray();

				Java.Lang.Object[] matchObjects;
				matchObjects = new Java.Lang.Object[matchList.Count];
				for (int i = 0; i < matchList.Count; i++)
				{
					matchObjects[i] = new Java.Lang.String(matchList[i].Desc);
				}

				results.Values = matchObjects;
				results.Count = matchList.Count;
			} else
			{
				_adapter.ResetSearch();
			}


			return results;
		}

		protected override void PublishResults(ICharSequence constraint, FilterResults results)
		{
			_adapter.NotifyDataSetChanged();
		}

	}

}
