namespace OOP {
    class Decorator
    {
        static void Main(string[] args)
        {
            var personelCar = new PersonelCar {
                Make = "BMW", Model = "3.20", HirePrice = 2500
            };
            SpecialOffer specialOffer = new SpecialOffer(personelCar);
            specialOffer.DiscountPercentage = 10;

            Console.WriteLine("Concrete : {0}", personelCar.HirePrice)
            Console.WriteLine("Special Offer : {0}", specialOffer.HirePrice)
        }
    }

    abstract class Abs Carbase
    {
        public abstract string Make { get; set; }
        public abstract string Model { get; set; }
        public abstract decimal HirePrice { get; set; }
    }

    class PersonelCar : Carbase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    class CommercialCar : Carbase
    {
        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice { get; set; }
    }

    abstract class CarDecoratorBase : Carbase
    {
        private CarBase _carBase;

        protected CarDecoratorBase(CarBase carBase)
        {
            _carBase = carBase;
        }
    }

    class SpecialOffer : CarDecoratorBase
    {
        public int DiscountPercentage { get; set; }

        private readonly CarBase _carBase;

        public SpecialOffer(CarBase carBase) : base(carBase)
        {
            _carBase = carBase;
        }

        public override string Make { get; set; }
        public override string Model { get; set; }
        public override decimal HirePrice {
            get
            {
                return _carBase.HirePrice - (_carBase.HirePrice * DiscountPercentage / 100);
            }
            set
            {

            }
    }
}
