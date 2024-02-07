using System.Reflection;
using C_2_Reflect_2;
using C_2_Reflect_2.Models;

Book book1 = new Book();
Car car1 = new();

UITools.FillAnyModel(book1);
UITools.FillAnyModel(car1);


Book book2 = new()
{
	Author = "Anton",
	Genre = "Fantasy",
	Year = 2025
};

Car car2 = new()
{
	Engine = "Electric",
	Vendor = "Mers",
	Year = 2028
};

List<Book> books = new() { book1, book2 };
List<Car> cars = new() { car1, car2 };

UITools.PrintAnyModel(books);
