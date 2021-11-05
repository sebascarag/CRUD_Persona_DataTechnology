using CRUD_Persona_DataTechnology.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Persona_DataTechnology.Models.Dal
{
    public class PersonDAL
    {
        protected DataContext db;
        private DbSet<Person> dbset;
        public PersonDAL(DataContext dataContext)
        {
            db = dataContext;
            dbset = db.Set<Person>();
        }

        public async Task<List<Person>> ToListPersonAsync()
        {
            var list = await dbset.Include(t => t.TypeDocument).ToListAsync();
            return list;
        }

        public void CreatePerson(Person person) {
            dbset.Add(person);
            db.SaveChanges();
            db.Dispose();
        }

        public async Task<Person> FindPersonByIdAsync(int id) {
            if (id <= 0)
            {
                return null;
            }
            return await db.People.FindAsync(id);
        }

        public Person UpdatePerson(Person person) {
            try
            {
                db.Update(person);
                db.SaveChanges();
                return person;
            }
            catch (DbUpdateConcurrencyException)
            {
                return null;
            }
        }

        public bool PersonExist(Person person) {
            return db.People.Any(e => e.PersonId == person.PersonId);
        }

        public void DeletePerson(int id) {
            var person = db.People.Find(id);
            dbset.Remove(person);
            db.SaveChanges();
        }
    }
}
