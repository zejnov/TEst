using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon
{
    //tworzy sam siebie, i może być stowrzony tylko raz
    //nie można zainstancjonować tego obiektu spoza klasy
    //publcizna metoda zwraca instancję klasy, stworzona tylko raz i wtedy gdy potrzeba

    class PeopleRegisterSingleton
    {
        private List<Person> _register = new List<Person>();

        private static PeopleRegisterSingleton _intstance; //niewidoczna poza klasą

        public static PeopleRegisterSingleton GetInstance() //też musi być static
        {
            if (_intstance == null)
            {
                _intstance = new PeopleRegisterSingleton();
            }

            return _intstance;
        }

        private PeopleRegisterSingleton() //musi być prywatny, nic poza naszą klasą nie możę wywołać konstruktora
        { }

        public void Add(Person person)
        {
            _register.Add(person);
        }

        public List<Person> GetAll()
        {
            return _register;
        }

    }
}
