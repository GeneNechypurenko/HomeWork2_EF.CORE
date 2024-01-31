namespace HomeWork2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ShopContext())
            {
                var orderService = new OrderService(context);

                var product1 = new Product { Name = "shirt", Price = 10.99m };
                var product2 = new Product { Name = "jeans", Price = 20.49m };

                context.Products.AddRange(product1, product2);
                context.SaveChanges();

                var order = new Order { OrderDate = DateTime.Now };
                order.Products.Add(product1);
                order.Products.Add(product2);

                orderService.AddOrder(order);

                var orders = orderService.GetOrders();
                foreach (var o in orders)
                {
                    Console.WriteLine($"Order {o.Id} - Date: {o.OrderDate}");
                    foreach (var product in o.Products)
                    {
                        Console.WriteLine($"  Product: {product.Name} - Price: {product.Price}");
                    }
                }
            }
        }
    }
}
