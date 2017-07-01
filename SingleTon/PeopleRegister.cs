using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleTon
{
    class PeopleRegister
    {
        private List<Person> _register = new List<Person>();

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
