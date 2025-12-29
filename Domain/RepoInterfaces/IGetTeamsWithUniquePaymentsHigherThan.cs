using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibreriaLogicaNegocio.Entities;

namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IGetTeamsWithUniquePaymentsHigherThan<T>
    {
        IEnumerable<T> GetTeamsWithUniquePaymentsHigherThan(double amount);
    }
}
