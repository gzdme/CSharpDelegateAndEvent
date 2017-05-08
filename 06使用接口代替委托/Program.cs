using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06使用接口代替委托
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductFactory pizzaFactory = new PizzaFactory();
            IProductFactory toycarFactory = new ToyCarFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Box box1 = wrapFactory.WrapProduct(pizzaFactory);
            Box box2 = wrapFactory.WrapProduct(toycarFactory);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }
    class Product //产品类
    {
        public string Name { get; set; }
    }
    interface IProductFactory
    {
        Product Make();
    }
    class PizzaFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
    }
    class ToyCarFactory : IProductFactory
    {
        public Product Make()
        {
            Product product = new Product();
            product.Name = "ToyCar";
            return product;
        }
    }
    class Box //包装类
    {
        public Product Product { get; set; }
    }
    class WrapFactory //包装工厂
    {
        public Box WrapProduct(IProductFactory productFactory)
        {
            Box box = new Box();
            Product product = productFactory.Make();
            box.Product = product;
            return box;
        }
    }
}
