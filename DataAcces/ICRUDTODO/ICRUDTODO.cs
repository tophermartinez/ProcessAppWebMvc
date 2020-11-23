using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.ICRUDTODO
{
    public interface ICRUDTODO<X>
    {
        string Insert(X dto);
        string Update(X dto);
        string Delete(String dto);
        List<X> Read();

        string InsertF(X dto);
        string UpdateF(X dto);
        string DeleteF(String dto);
        List<X> ReadF();
    }
}
