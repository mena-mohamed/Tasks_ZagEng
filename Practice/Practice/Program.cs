namespace Practice
{

    public enum Category
    {
        Food,
        Electronics,
        Clothing
    }

    public struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    


    internal class Program
    {
        static void Main(string[] args)
        {

            Product product = new Product("phone", 20000, Category.Electronics);

            Console.WriteLine(product.Name);

            product.Price = -10;

            Console.WriteLine(product.Price);
        }
    }
}



