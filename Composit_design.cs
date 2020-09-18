using System;
using System.Collections;
using System.Collections.Generic;

namespace Composit
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee engin = new Employee { Name = "Engin Demiroğ" };
            Employee salih = new Employee { Name = "Salih Demiroğ" };
            Employee derin = new Employee { Name = "Derin Demiroğ" };
            Employee ahmet = new Employee { Name = "Ahmet Demiroğ" };

            Contractor ali = new Contractor { Name = "Ali" };

            engin.AddSubOrdinate(salih);
            engin.AddSubOrdinate(derin);
            salih.AddSubOrdinate(ahmet);
            derin.AddSubOrdinate(ali);

            Console.WriteLine(engin.Name);

            foreach (IPerson person in engin)
            {
                Console.WriteLine(" " + person.Name);
                
                foreach (IPerson employee in person)
                {
                    Console.WriteLine("  " + employee.Name);
                }
            }
        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson>
    {
        public string Name { get; set; }
     
        List<IPerson> _subordinates = new List<IPerson>();

        public void AddSubOrdinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubOrdinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubOrdinate(int index)
        {
            return _subordinates[index];
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
                yield return subordinate;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
    
