using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Cliente2
{
    public interface ICRUDU<U>
    {
        string Insert(U dto);
        string Update(U dto);
        string Delete(String dto);
        List<U> Read();
    }
}
