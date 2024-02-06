using System.Reflection;
using C_2_Reflect_2.Models;

Book book = new();

GetTypeObject(new Car());
GetTypeObject(new Book());
GetTypeObject(new Empl());



static void GetTypeObject(object data)
{
	Type typeOfObject = null;

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

	Type type = typeof(Book);
	//Get fields
	PropertyInfo?[] fieldInfos = typeOfObject.GetProperties();

	foreach (PropertyInfo item in fieldInfos)
	{
		System.Console.WriteLine(item.Name);
	}

}