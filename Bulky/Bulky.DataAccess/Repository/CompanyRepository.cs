﻿using Bulky.DataAccess.Repository.IRepository;
using BulkyWeb.DataAccess.Data;
using Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository {
    public class CompanyRepository : Repository<Category>, ICompanyRepository {
        private ApplicationDbContext _db;
        public CompanyRepository(ApplicationDbContext db) : base(db) {
            _db = db;
        }

        public void Update(Company obj) {
            _db.Companies.Update(obj);
        }
    }
}
