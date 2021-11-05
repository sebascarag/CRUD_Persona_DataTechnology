using CRUD_Persona_DataTechnology.Models;
using CRUD_Persona_DataTechnology.Models.Dal;
using CRUD_Persona_DataTechnology.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Persona_DataTechnology.Bll
{
    public class TypeDocumentBLL
    {
        private readonly DataContext _dataContext;
        public TypeDocumentBLL(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<TypeDocument>> GetTypeDocumentsAsync()
        {
            var dal = new TypeDocumentDAL(_dataContext);
            return await dal.ToListTypeDocumentAsync();
        }
    }
}
