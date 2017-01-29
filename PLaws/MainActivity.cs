using Android.App;
using Android.Views;
using Android.OS;
using System;
using Android.Widget;
using Android.Graphics.Drawables;
using Android.Graphics;

namespace PLaws
{
	[Activity(Label = "Pegasus", Icon = "@drawable/pegasus")]
	public class MainActivity : Activity, Communicator, FragmentManager.IOnBackStackChangedListener, SearchView.IOnQueryTextListener
	{
		string[] lawDesc = { 
			"Que aprueba el Acuerdo entre la República del Paraguay y el Reino de España sobre transporte aéreo.",
			"Que aprueba el Acuerdo de Cooperación Científica y Tecnológica entre el gobierno de la República del Paraguay y el gobierno de la República Árabe de Egipto.",
			"Que aprueba el Acuerdo entre el Gobierno de la República del Paraguay y el Gobierno de la República Italiana sobre Promoción y Protección de Inversiones",
			"Que aprueba el Convenio entre el Gobierno de la República del Paraguay y el Gobierno de los Estados Unidos Mexicanos sobre transporte aéreo.",
			"Que aprueba el ajuste complementario al acuerdo entre el Gobierno de la República del Paraguay y el Gobierno de la República Federativa del Brasil del 29 de marzo de 1988 para la Cooperación en materia de Seguridad Publica y combate al trafico ilícito de estupefacientes y sustancias psicotrópicas y delitos conexos",
			"Que aprueba el Convenio de Seguridad Social entre la República del Paraguay y la República de Chile.",
			"Que aprueba el convenio entre la república del Paraguay y la república del Ecuador para la restitución de bienes culturales robados, importados, exportados o transferidos ilícitamente."
		};
		string[] lawNum = { 
			"Ley Nº 5.617 / 2016",
			"Ley Nº 5.293 / 2014",
			"Ley Nº 4.904 / 2013",
			"Ley Nº 4.649 / 2012",
			"Ley Nº 4.634 / 2012",
			"Ley Nº 4.593 / 2012",
			"Ley Nº 4.576 / 2012"
		};

		FragmentList list;
		string lawText = "Um texto de Exemplo, aqui terá o texto da lei qdo vier do servidor";
		FragmentManager manager;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);
			ActionBar actionBar = ActionBar;
			actionBar.SetBackgroundDrawable(new ColorDrawable(Color.Rgb(10, 52, 86)));
			//actionBar.SetDisplayHomeAsUpEnabled(true);

			manager = FragmentManager;

			list = new FragmentList(lawDesc, lawNum);
			manager.BeginTransaction()
			       .SetTransition(FragmentTransit.FragmentFade)
			       .Add(Resource.Id.relativeLayout1, list, "listLaws")
				   .Commit();
		}

		public override bool OnCreateOptionsMenu(IMenu menu)
		{
			var inflater = MenuInflater;
			inflater.Inflate(Resource.Menu.menu_main, menu);
			return true;
		}

		public override bool OnOptionsItemSelected(IMenuItem item)
		{
			int id = item.ItemId;
			if (id == Resource.Id.search)
			{
				SearchView search = (Android.Widget.SearchView)item.ActionView;
				search.SetOnQueryTextListener(this);
				// Toast.MakeText(this, "Search clicked", ToastLength.Short).Show();
				return true;
			}
			else if (id == Resource.Id.action)
			{
				Toast.MakeText(this, "This application is a Alpha test. \n Created by Bruno, Romerio, Andrew, Isaac", ToastLength.Long).Show();
				return true;
			}
			else if (id == Android.Resource.Id.Home) {
				
			}

			return base.OnOptionsItemSelected(item);
		}

		public void changeListData()
		{
			FragmentTransaction transaction = manager.BeginTransaction();
			//transaction.SetTransition(FragmentTransit.FragmentClose);
			var lawTextView = new FragmentTextLaw(lawText);
			transaction.Replace(Resource.Id.relativeLayout1, lawTextView);
			transaction.AddToBackStack("addTextLaw");
			transaction.Commit();
		}

		protected override void OnResume()
		{
			base.OnResume();
			Console.WriteLine("onResume Called MAIN");

		}

		public void OnBackStackChanged()
		{

		}

		public bool OnQueryTextChange(string newText)
		{
			if (newText != "")
			{
				list.searchOnList(newText);
				//Toast.MakeText(this, "Esta sendo digitado: " + newText, ToastLength.Short).Show();
			}
			return true;
		}

		public bool OnQueryTextSubmit(string query)
		{
			if (query != "")
			{
				//Toast.MakeText(this, "Foi digitado: " + query, ToastLength.Short).Show();
			}
			return true;
		}
	}
}

