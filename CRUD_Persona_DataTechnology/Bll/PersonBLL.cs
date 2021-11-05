using CRUD_Persona_DataTechnology.Models;
using CRUD_Persona_DataTechnology.Models.Dal;
using CRUD_Persona_DataTechnology.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Persona_DataTechnology.Bll
{
    public class PersonBLL
    {
        private readonly DataContext _dataContext;
        public PersonBLL(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Person>> GetPeopleAsync()
        {
            var dal = new PersonDAL(_dataContext);
            return await dal.ToListPersonAsync();
        }

        public void CreatePersonAsync(Person person)
        {
            var dal = new PersonDAL(_dataContext);
            if (person != null && !dal.PersonExist(person))
            {
                dal.CreatePerson(person);
            }
        }

        public async Task<Person> FindPersonByIdAsync(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return await new PersonDAL(_dataContext).FindPersonByIdAsync(id);
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            var dal = new PersonDAL(_dataContext);
            if (person != null)
            {
                return dal.UpdatePerson(person);
            }
            return null;
        }

        public async void DeletePersonAsync(int id) {
            if (id > 0)
            {
                var dal = new PersonDAL(_dataContext);
                dal.DeletePerson(id);
            }
        }
    }
}
