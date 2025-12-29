using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaLogicaNegocio.ApplicationInterfaces
{
    public interface ICuGetPaymentsByUserId<T>
    {
        IEnumerable<T> Execute(int id);
    }
}
