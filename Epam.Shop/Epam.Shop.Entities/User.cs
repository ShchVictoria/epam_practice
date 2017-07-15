using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Shop.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Login { get; set; }

        public byte[] Password { get; set; }

        public int IdRole { get; set; }

        public string Name { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }
    }
}
