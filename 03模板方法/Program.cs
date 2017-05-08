using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03模板方法
{
    /// <summary>
    /// 使用模板方法，可以提高代码的复用
    /// 代码的复用不但可以提高工作效率，还可以减少bug的引入；
    /// 良好的复用结构是所有优秀软件所追求的共同目标之一；
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Func<Product> product1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> product2 = new Func<Product>(productFactory.MakeToyCar);

            Box box1 = wrapFactory.WrapProduct(product1);
            Box box2 = wrapFactory.WrapProduct(product2);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
    }
    class Product //产品类
    {
        public string Name { get; set; }
    }
    class Box //包装类
    {
        public Product Product { get; set; }
    }
    class WrapFactory //包装工厂
    {
        public Box WrapProduct(Func<Product> getProduct)
        {
            Box box = new Box();
            Product product = getProduct.Invoke();
            box.Product = product;
            return box;
        }
    }
    class ProductFactory //生产工厂
    {
        public Product MakePizza()
        {
            Product product = new Product();
            product.Name = "Pizza";
            return product;
        }
        public Product MakeToyCar()
        {
            Product product = new Product();
            product.Name = "ToyCar";
            return product;
        }
    }
}
