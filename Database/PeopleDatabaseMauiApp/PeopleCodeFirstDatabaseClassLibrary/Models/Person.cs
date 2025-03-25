using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleCodeFirstDatabaseClassLibrary.Models
{
    internal class Person
    {
        //[Key] -- jesli nazwa klucza glownego jest inna nix Id
        public int Id { get; set; } // klucz główny, IdXyz juz zwykła kolumna

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        [MaxLength(60)]
        [Required]
        public string Surname { get; set; }

        [Range(0, 150)]
        public int Age { get; set; }

        public string Country { get; set; }

        //Pierwszy foregin

        public int MainAddressId { get; set; }
        public Address MainAddress { get; set; }

        // drugi Foregin

        public int SecondAddressId { get; set; }
        public Address SecondAddress { get; set; } //SecondAddress properties
    }
}
