using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04回调方法
{
    /// <summary>
    /// 工作中经常会用到Logger类型，其作用就是输出工作日志
    /// 在对log进行记录的时候经常会使用委托回调方法
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ProductFactory productFactory = new ProductFactory();
            WrapFactory wrapFactory = new WrapFactory();

            Func<Product> product1 = new Func<Product>(productFactory.MakePizza);
            Func<Product> product2 = new Func<Product>(productFactory.MakeToyCar);

            Logger logger = new Logger();
            Action<Product> log = new Action<Product>(logger.log);

            Box box1 = wrapFactory.WrapProduct(product1, log);
            Box box2 = wrapFactory.WrapProduct(product2, log);

            Console.WriteLine(box1.Product.Name);
            Console.WriteLine(box2.Product.Name);
        }
        class Logger //日志类
        {
            public void log(Product product)
            {
                Console.WriteLine("Product '{0}' created at {1}. Price is {2}.", product.Name, DateTime.UtcNow, product.Price);
            }
        }
        class Product //产品类
        {
            public string Name { get; set; }
            public double Price { get; set; }
        }
        class Box //包装类
        {
            public Product Product { get; set; }
        }
        class WrapFactory //包装工厂
        {
            public Box WrapProduct(Func<Product> getProduct, Action<Product> logCallback)
            {
                Box box = new Box();
                Product product = getProduct.Invoke();
                if (product.Price >= 50)
                {
                    logCallback.Invoke(product);
                }
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
                product.Price = 12;
                return product;
            }
            public Product MakeToyCar()
            {
                Product product = new Product();
                product.Name = "ToyCar";
                product.Price = 100;
                return product;
            }
        }
    }
}
