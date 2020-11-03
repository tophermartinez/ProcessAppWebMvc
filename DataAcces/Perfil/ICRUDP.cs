using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Perfil
{
    interface ICRUDP<P>
    {
        string Insert(P dto);
        string Update(P dto);
        string Delete(String dto);
        List<P> Read();
    }
}