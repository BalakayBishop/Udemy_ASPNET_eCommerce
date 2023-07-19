using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository {
    public class UnitOfWork : IUnitOfWork {
        // an private class field (attr) of type AppDbContext
        private ApplicationDbContext _db;

        // a public prop of type I____Repo
        public ICategoryRepository Category { get; private set; }
        public IProductRepository Product { get; private set; }

        //Ctor for UnitOfWork injecting the db context and creating an obj instance of CategoryRepository
        public UnitOfWork(ApplicationDbContext db) {
            _db = db;
            Category = new CategoryRepository(_db);
            Product = new ProductRepository(_db);
        }

        public void Save() {
            _db.SaveChanges();
        }
    }
}
