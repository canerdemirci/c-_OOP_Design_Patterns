using System;

namespace OOP
{
    class Builder_Pattern
    {
        static void Main(string[] args)
        {
            ProductDirector productDirector = new ProductDirector();
            var builder = new NewCustomerProductBuilder();
            productDirector.GenerateProduct(builder);
            var model = builder.GetModel();

            Console.WriteLine(model.Id);
            Console.WriteLine(model.CategoryName);
            Console.WriteLine(model.DiscountApplied);
            Console.WriteLine(model.DiscountedPrice);
            Console.WriteLine(model.ProductName);
            Console.WriteLine(model.UnitPrice);
            Console.WriteLine(model);
        }
    }

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public bool DiscountApplied { get; set; }
    }

    public abstract class ProductBuilder
    {
        public abstract void GetProductData();
        public abstract void ApplyDiscount();
        public abstract ProductViewModel GetModel();
    }

    public class NewCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice * (decimal)0.9;
            model.DiscountApplied = true;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    public class OldCustomerProductBuilder : ProductBuilder
    {
        ProductViewModel model = new ProductViewModel();

        public override void GetProductData()
        {
            model.Id = 1;
            model.CategoryName = "Beverage";
            model.ProductName = "Chai";
            model.UnitPrice = 20;
        }

        public override void ApplyDiscount()
        {
            model.DiscountedPrice = model.UnitPrice;
            model.DiscountApplied = false;
        }

        public override ProductViewModel GetModel()
        {
            return model;
        }
    }

    public class ProductDirector
    {
        public void GenerateProduct(ProductBuilder productBuilder)
        {
            productBuilder.GetProductData();
            productBuilder.ApplyDiscount();
        }
    }
}
