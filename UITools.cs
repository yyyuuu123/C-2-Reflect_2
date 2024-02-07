using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace C_2_Reflect_2
{
	public class UITools
	{
		static public void FillAnyModel(object model)
		{
			Type modelType = model.GetType(); //it's work too the same
											  //Type typeOfObject = typeof(modelObj); //prefer this

			//Get fields
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
			Type type = models.GetType();
		}
	}
}