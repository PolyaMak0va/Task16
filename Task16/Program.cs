using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace Task16
{
    /* 1. Необходимо разработать программу для записи информации о товаре в текстовый файл в формате json.
     * Разработать класс для моделирования объекта «Товар». Предусмотреть члены класса «Код товара» (целое число), 
     * «Название товара» (строка), «Цена товара» (вещественное число).
     * Создать массив из 5-ти товаров, значения должны вводиться пользователем с клавиатуры.
     * Сериализовать массив в json-строку, сохранить ее программно в файл «Products.json».
     * 2. Необходимо разработать программу для получения информации о товаре из json-файла.
     * Десериализовать файл «Products.json» из задачи 1. Определить название самого дорогого товара.
     */
    class Program
    {
        static void Main(string[] args)
        {
            string path = "Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string path2 = "Logs/Products.json";
            if (!File.Exists(path2))
            {
                var newFile = File.Create(path2);
                newFile.Close();
            }
            try
            {
                Console.Write("Введите количество видов товара:   ");
                int a = Convert.ToInt32(Console.ReadLine());

                Product[] products = new Product[a];
                JsonSerializerOptions options = new JsonSerializerOptions()
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic), // на сайте microsoft.com
                    WriteIndented = true
                };
                for (int i = 0; i < a; i++)
                {
                    products[i] = new Product();
                    Console.Write("\nВведите код товара:       \t ");
                    products[i].CodeProduct = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите наименование товара:\t ");
                    products[i].NameProduct = Convert.ToString(Console.ReadLine());
                    Console.Write("Введите стоимость товара:\t ");
                    products[i].PriceProduct = Convert.ToDouble(Console.ReadLine());
                    products[i].Print();
                }
                string jsonString = JsonSerializer.Serialize(products, options);
                File.WriteAllText(path2, jsonString);
                StreamReader sr = new StreamReader(path2, false);
                sr.ReadToEnd();
                sr.Close();
                jsonString = File.ReadAllText(path2);
                Product[] product2 = JsonSerializer.Deserialize<Product[]>(jsonString);
                double max = product2[0].PriceProduct;
                int maxIndex = 0;
                for (int i = 0; i < a; i++)
                {
                    if (product2[i].PriceProduct > max)
                    {
                        max = product2[i].PriceProduct;
                        maxIndex = i;
                    }
                }
                Console.WriteLine("Самый дорогой товар: {0}, его цена составляет {1} руб.", product2[maxIndex].NameProduct, product2[maxIndex].PriceProduct);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Неправильный формат ввода!", ex.Message);
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
    class Product
    {
        public int CodeProduct { get; set; }
        public string NameProduct { get; set; }
        public double PriceProduct { get; set; }
        public Product()
        {
            NameProduct = " ";
        }
        public Product(int code, string name, double price)
        {
            CodeProduct = code;
            NameProduct = name;
            PriceProduct = price;
        }
        public void Print()
        {
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Code of Product:  {0}", CodeProduct);
            Console.WriteLine("Name of Product:  {0}", NameProduct);
            Console.WriteLine("Price of Product: {0} rub.", PriceProduct);
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();
        }
    }
}
