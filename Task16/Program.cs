using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.Write("Введите количество видов товара:   ");
            int a = Convert.ToInt32(Console.ReadLine());
            Product[] products = new Product[a];
            Product product1 = new Product();

            for (int j = 0; j < a; j++)
            {
                Console.Write("\nВведите код товара:       \t ");
                product1.CodeProduct = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите наименование товара:\t ");
                product1.NameProduct = Convert.ToString(Console.ReadLine());
                Console.Write("Введите стоимость товара:\t ");
                product1.PriceProduct = Convert.ToDouble(Console.ReadLine());
                products[j] = product1;
            }
            foreach (var p in products)
            {
                product1.Print();
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
            Console.WriteLine("Price of Product: {0}", PriceProduct);
            Console.WriteLine(new string('=', 50));
            Console.WriteLine();
        }
    }
}
