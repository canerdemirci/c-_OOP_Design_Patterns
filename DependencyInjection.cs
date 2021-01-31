using System;

namespace csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
            productManager.Save();
        }
    }

    interface IProductDal
    {
        void Save();
    }

    class EfProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with EF");
        }
    }

    class NhProductDal : IProductDal
    {
        public void Save()
        {
            Console.WriteLine("Saved with NH");
        }
    }

    class ProductManager
    {
        private IProductDal _productDal;
        
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        
        public void Save()
        {
            _productDal.Save();
        }
    }
}
