using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace Task_1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 5;
            Goods[] goods = new Goods[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите код товара");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите название товара");
                string name = Console.ReadLine();
                Console.WriteLine("Введите цену товара");
                double price = Convert.ToDouble(Console.ReadLine());
                goods[i] = new Goods() { Id = id, Name = name, Price = price };
            }
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize(goods, options);

            using (StreamWriter sw = new StreamWriter("Goods.json"))
            {
                sw.WriteLine(jsonString);
            }

            String jsonString = String.Empty;
            using (StreamReader sr = new StreamReader(@"Goods.json"))
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
            Console.WriteLine($"Самый дорогой товар: {maxPrice.Name} \nЦена товара: {maxPrice.Price}  Код товара: {maxPrice.Id}");
            Console.ReadKey();
        }
    }
    }
}
