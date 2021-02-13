using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEmpleado.Data;

namespace WebEmpleado.Models
{
    public class Employe 
    {
        public int id { get; set; }
        
        public string FnameS { get; set; }

        public string Position { get; set; }

        public int  Salary { get; set; }

        public Employe()
        {

        }
        //private readonly EmployeDbContext _context;
        //public Employe(EmployeDbContext context)
        //{
        //    _context = context;
        //}
        //public IEnumerable<Employe> GetEmploye()
        //{
        //    return _context.Employe.ToList();
        //}
        //public void InsertEmploye(Employe employe)
        //{
        //    _context.Employe.Add(employe);
        //}
        //public void Save()
        //{
        //    _context.SaveChanges();
        //}
        //private bool _disposed;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //    {
        //        if (disposing)
        //        {
        //            _context.Dispose();
        //        }
        //    }
        //    _disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}


