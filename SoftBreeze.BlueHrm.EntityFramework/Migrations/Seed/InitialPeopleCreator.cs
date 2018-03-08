using System.Collections.Generic;
using System.Linq;
using SoftBreeze.BlueHrm.EntityFramework;
using SoftBreeze.BlueHrm.People;

namespace SoftBreeze.BlueHrm.Migrations.Seed
{
    public class InitialPeopleCreator
    {
        private readonly BlueHrmDbContext _context;

        public InitialPeopleCreator(BlueHrmDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var douglas = _context.Persons.FirstOrDefault(p => p.EmailAddress == "anthony.ademu@admuanthony.com");
            if (douglas == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Anthony",
                        Surname = "Admu",
                        EmailAddress = "anthony.ademu@admuanthony.com",
                        Phones = new List<Phone>
                                {
                                    new Phone {Type = PhoneType.Home, Number = "1112242"},
                                    new Phone {Type = PhoneType.Mobile, Number = "2223342"}
                                }
                    });
            }

            var asimov = _context.Persons.FirstOrDefault(p => p.EmailAddress == "isaac.daudu@foundation.org");
            if (asimov == null)
            {
                _context.Persons.Add(
                    new Person
                    {
                        Name = "Isaac",
                        Surname = "Daudu",
                        EmailAddress = "isaac.daudu@foundation.org",
                        Phones = new List<Phone>
                                {
                                    new Phone {Type = PhoneType.Home, Number = "8889977"}
                                }
                    });
            }
        }
    }
}
