using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Runtime.Serialization;

namespace C_2_Reflect_2
{
	public class UITools
	{
		static public void FillAnyModel(object model)
		{
			Type modelType = model.GetType(); //it's work too the same
											  //Type typeOfObject = typeof(modelObj); //prefer this

			//Get Property
			PropertyInfo?[] fieldInfos = modelType.GetProperties();

			foreach (PropertyInfo item in fieldInfos)
			{
				System.Console.WriteLine($"Enter: {item.Name}");
				string inputUser = Console.ReadLine();
				object? changeValue = Convert.ChangeType(inputUser, item.PropertyType);
				item.SetValue(model, changeValue);
			}
			System.Console.WriteLine();
		}

		static public void PrintAnyModel<T>(List<T> models)
		{
			List<string> titles = new();

			Type modelType = models[0].GetType();

			//Get Property
			PropertyInfo?[] fieldInfos = modelType.GetProperties();
			foreach (PropertyInfo item in fieldInfos)
			{
				titles.Add(item.Name + new string(' ', item.Name.Length));
			}

			string title = $"|  {string.Join("  |  ", titles)}  |";
			string topLine = new string('-', title.Length);

			System.Console.WriteLine(topLine);
			System.Console.WriteLine(title);
			System.Console.WriteLine(topLine);

			List<string> detailsItems = new();

			foreach (T modelItem in models)
			{
				foreach (PropertyInfo prop in fieldInfos)
				{
					object item = prop.GetValue(modelItem);
					string itemtext = item.ToString();
				}
			}

		}
	}
}