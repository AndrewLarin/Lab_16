using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace InformationOfGoods
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(@"C:\Курсы\ИТМО\Программирование на языке C# по технологии Windows Presentation Foundation\Clear\Lab_16\Task_1\bin\Debug\Goods.json"))
            {
                jsonString = sr.ReadToEnd();
            }
            Goods[] goods2 = JsonSerializer.Deserialize<Goods[]>(jsonString);

            Goods maxPrice = goods2[0];
            foreach (Goods item in goods2)
            {
                if (item.Price > maxPrice.Price)
                {
                    maxPrice = item;
                }
            }
            Console.WriteLine($"Самый дорогой товар: {maxPrice.Name} \nЦена товара: {maxPrice.Price}  \nКод товара: {maxPrice.Id}");
            Console.ReadKey();
        }
    }
}
