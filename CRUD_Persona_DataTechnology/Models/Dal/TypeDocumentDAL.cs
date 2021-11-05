using CRUD_Persona_DataTechnology.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Persona_DataTechnology.Models.Dal
{
    public class TypeDocumentDAL
    {
        protected DataContext db;
        private DbSet<TypeDocument> dbset;
        public TypeDocumentDAL(DataContext dataContext)
        {
            db = dataContext;
            dbset = db.Set<TypeDocument>();
        }

        public async Task<List<TypeDocument>> ToListTypeDocumentAsync()
        {
            var list = await dbset.ToListAsync();
            return list;
        }
    }
}
