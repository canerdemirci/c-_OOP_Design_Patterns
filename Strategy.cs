namespace OOP
{
    class Strategy
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.CreditCalculatorBase = After2010CreditCalculator();
            customerManager.SaveCredit();
            customerManager.CreditCalculatorBase = Before2010CreditCalculator();
            customerManager.SaveCredit();
        }
    }

    abstract class CreditCalculatorBase
    {
        public abstract void Calculate();
    }

    class Before2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using before2010");
        }
    }

    class After2010CreditCalculator : CreditCalculatorBase
    {
        public override void Calculate()
        {
            Console.WriteLine("Credit calculated using after2010");
        }
    }

    class CustomerManager
    {
        public CreditCalculatorBase CreditCalculatorBase { get; set; }

        public void SaveCredit()
        {
            Console.WriteLine("Customer manager business");
            CreditCalculatorBase.Calculate();
        }
    }
}
