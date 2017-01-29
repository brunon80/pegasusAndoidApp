using System;
namespace PLaws
{
	public class Laws
	{

		string _Desc;
		public string Desc
		{
			//set the state name
			set { _Desc = value; }
			//get the state name
			get { return _Desc; }
		}
		string _Num;
		public string Num
		{
			//set the state pop
			set { _Num = value; }
			//get the state pop
			get { return _Num; }
		}
		// Default constructor
		public Laws(string desc, string num)
		{
			Desc = desc;
			Num = num;
		}
	}
}
