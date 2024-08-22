using bookDemo.Models;
namespace bookDemo.Data
{
    public static class ApplicationContext
    {
        public static List<Book> Books { get; set;}
        static ApplicationContext()
        {
            Books = new List<Book>()
            {
                new Book(){Id=1, Title="Cin Ali", Price = 34},
                new Book(){Id=2, Title="Denizler Altında Yirmi Bin Fersah ", Price = 47},
                new Book(){Id=3, Title="Küçük Prens ", Price = 81},
            };
        }
    }
}
