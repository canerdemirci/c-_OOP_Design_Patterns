using System;

namespace OOP
{
    class Singleton
    {
        static void Main(string[] args)
        {
            var customerManager = CustomerManager.CreateAsSingleton();       
            
            customerManager.Save();     
        }
    }

    class CustomerManager
    {
        private static CustomerManager _customerManager;

        private CustomerManager() {}

        public static CustomerManager CreateAsSingleton() => _customerManager ?? (_customerManager = new CustomerManager());

        public void Save() => Console.WriteLine("Saved");
    }
}
