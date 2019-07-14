using JBD.ProjetoTesteEveris.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBD.ProjetoTesteEveris.Data.Contexts
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataBaseContext _context;
        public UnitOfWork(DataBaseContext context)
        {
            _context = context;
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }
    }
}
