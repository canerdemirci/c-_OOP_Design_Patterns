namespace OOP
{
    class Facade_Pattern
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Save();
        }
    }

    interface ILogging
    {
        void Log();
    }

    interface ICaching
    {
        void Cache();
    }

    interface IAuthorize
    {
        void CheckUser();
    }

    class Logging : ILogging
    {
        public void Log()
        {
            Console.WriteLine("Logged");
        }
    }

    class Caching : ICaching
    {
        public void Cache()
        {
            Console.WriteLine("Cached");
        }
    }

    class Authorize : IAuthorize
    {
        public void CheckUser()
        {
            Console.WriteLine("User checked");
        }
    }

    class CustomerManager 
    {
        private CrossCuttingConcernsFacade _concerns;

        public CustomerManager()
        {
            _concerns = new CrossCuttingConcernsFacade();
        }

        public void Save()
        {
            _concerns.Caching.Cache();
            _concerns.Logging.Log();
            _concerns.Authorizing.CheckUser();
            Console.WriteLine("Saved");
        }
    }

    class CrossCuttingConcernsFacade 
    {
        public ILogging Logging;
        public ICaching Caching;
        public IAuthorize Authorizing;

        public CrossCuttingConcernsFacade()
        {
            Logging = new Logging();
            Caching = new Caching();
            Authorizing = new Authorize();
        }
    }
}
