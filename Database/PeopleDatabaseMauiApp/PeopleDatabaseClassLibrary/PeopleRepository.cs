using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PeopleDatabaseClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDatabaseClassLibrary
{
    public class PeopleRepository
    {
        private PeopleDBContext dbContext;

        public PeopleRepository()
        {
            dbContext = new PeopleDBContext();
        }

        public void CreateNewPerson(string name, string surname, int age)
        {
            Person person = new()
            {
                Name = name,
                Surname = surname,
                Age = age
            };

            dbContext.People.Add(person);
            dbContext.SaveChanges();
            
        }

        public List<Person> GetLegalAgePeople()
        {

            /* 
             select * 
            from People p 
        left join Adresses a on a.id = p.AdressId
            where Age >= 18
            order by Name asc, Surname desc
             
             */

            return dbContext
                .People
                .Include(p => p.Adress)
                .AsNoTracking()
                .Where(p => p.Age >= 18)
                .OrderBy(p => p.Name)
                .ThenByDescending(p => p.Surname)
                .ToList();

            //Select(p => p);

        }

        public void SaveChangePerson(Person currentPersonSelecion)
        {
            Person personToUpdate = dbContext.People.FirstOrDefault(p => p.Id == currentPersonSelecion.Id);
            if (personToUpdate != null)
            {
                personToUpdate.Name = currentPersonSelecion.Name;
                personToUpdate.Surname = currentPersonSelecion.Surname;
                personToUpdate.Age = currentPersonSelecion.Age;
                dbContext.SaveChanges();//sledzi obiekty, wykonuje wiele opcji
            }
        }

        public void DeletePerson(int id)
        {
            Person personToDelete = dbContext.People.FirstOrDefault(p =>p.Id == id);    
            if(personToDelete != null)
            {
                dbContext.People.Remove(personToDelete);
                dbContext.SaveChanges();
            }
        }
    }
}
