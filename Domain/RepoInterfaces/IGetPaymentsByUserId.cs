using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaLogicaNegocio.RepoInterfaces
{
    public interface IGetPaymentsByUserId<T>
    {
        IEnumerable<T> GetPaymentsByUserId(int id);
    }
}
