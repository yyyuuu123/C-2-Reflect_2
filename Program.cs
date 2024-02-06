using System.Reflection;
using C_2_Reflect_2.Models;

Book book = new();

GetTypeObject(new Car());
GetTypeObject(new Book());
GetTypeObject(new Empl());

static void GetTypeObject<T>(T data)
{
	Type typeOfObject = null;
	object mainDataUser = null;

	//Get type object
	switch (data)
	{
		case Book:
			typeOfObject = typeof(Book);
			break;
		case Car:
			typeOfObject = typeof(Car);
			break;
		case Empl:
			typeOfObject = typeof(Empl);
			break;
		default:
			break;
	}

	//Get fields
	PropertyInfo?[] fieldInfos = typeOfObject.GetProperties();

	foreach (PropertyInfo item in fieldInfos)
	{
		System.Console.WriteLine($"Enter: {item.Name}");
		string inputUser = Console.ReadLine();
		object? changeValue = Convert.ChangeType(inputUser, item.PropertyType);
		item.SetValue(data, changeValue);
	}
	System.Console.WriteLine();
}