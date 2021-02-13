using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebEmpleado.Models
{
    interface IEmploye : IDisposable
    {
        IEnumerable<Employe> GetBlogs();

        void InsertBlog(Employe employe);

        void Save();
    }
}
    

