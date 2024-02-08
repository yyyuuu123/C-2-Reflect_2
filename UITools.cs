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
            Console.WriteLine(modelType);

            //Get Property
            PropertyInfo?[] fieldInfos = modelType.GetProperties();
            foreach (PropertyInfo item in fieldInfos)
            {
                titles.Add(item.Name + new string(' ', item.Name.Length * 2));
            }

            string title = $"|  {string.Join("  |  ", titles)}  |";
            string topLine = new string('-', title.Length);

            System.Console.WriteLine(topLine);
            System.Console.WriteLine(title);
            System.Console.WriteLine(topLine);


            foreach (T modelItem in models)
            {
                List<string> detailsItems = new();
                for (int i = 0; i < fieldInfos.Length; i++)
                {
                    int propColLenght = fieldInfos[i].Name.Length;
                    object? item = fieldInfos[i]?.GetValue(modelItem);
                    string? itemText = item?.ToString();
                    int lenght = GetlenghRow(propColLenght, itemText.Length);
                    detailsItems.Add(itemText + new string(' ', lenght));
                }

                string row = $"|  {string.Join("  |  ", detailsItems)}  |";
                Console.WriteLine(row);
            }
            System.Console.WriteLine(topLine);
            Console.WriteLine();
        }

        //static private int GetlenghRow(int propLenght, int itemLenght) => itemLenght > propLenght ? propLenght: itemLenght;
        static private int GetlenghRow(int propLenght, int itemLenght)
        {
            if (propLenght > itemLenght)
            {
                return (propLenght * 2) + (propLenght - itemLenght);
            }
            else if (propLenght == itemLenght)
            {
                return propLenght * 2;
            }
            else
            {

                return (propLenght * 2) - (itemLenght - propLenght);
            }
        }
    }
}