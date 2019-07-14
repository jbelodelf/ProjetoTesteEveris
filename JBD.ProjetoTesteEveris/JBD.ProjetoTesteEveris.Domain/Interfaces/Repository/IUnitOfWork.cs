using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JBD.ProjetoTesteEveris.Domain.Interfaces.Repository
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
