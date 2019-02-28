using AdamTaskApplication.Data.Interfaces;
using AdamTaskApplication.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdamTaskApplication.Data.Repositries
{
    public class FilesRepository : Repository<Files> , IFiles
    {
        public FilesRepository(MainContext mainContext) : base(mainContext)
        {

        }
    }
}
