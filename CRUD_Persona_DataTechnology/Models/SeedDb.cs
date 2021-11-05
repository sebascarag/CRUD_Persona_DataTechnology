using CRUD_Persona_DataTechnology.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Persona_DataTechnology.Models
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            //if database  not existe or no updated, each run for here
            await _context.Database.EnsureCreatedAsync();
            await CheckTypeDocumentAsync("Cedula");
            await CheckTypeDocumentAsync("Pasaporte");
            await CheckPersonAsync("123",1, "Sebas Carmona", "sebas@yopmail.com", DateTime.UtcNow.Date);
        }

        private async Task<Person> CheckPersonAsync(string document, int typeDocument, string name, string email, DateTime birthday)
        {
            Person p = _context.People.FirstOrDefault(x => x.Email == email);
            if (p == null)
            {
                _context.People.Add(
                    new Person
                    {
                        Name = name,
                        TypeDocumentId = typeDocument,
                        Document = document,
                        Birthday = birthday,
                        Email = email
                    });
                await _context.SaveChangesAsync();
            }
            return p;
        }

        private async Task<TypeDocument> CheckTypeDocumentAsync(string name)
        {
            TypeDocument td = _context.TypeDocuments.FirstOrDefault(x => x.Name == name);
            if (td == null)
            {
                _context.TypeDocuments.Add(
                    new TypeDocument
                    {
                        Name = name
                    });
                await _context.SaveChangesAsync();
            }
            return td;
        }
    }
}
