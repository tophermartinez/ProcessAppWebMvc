using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using Entity_Layer;

namespace Bussines_Layer
{
    public class NegocioTarea
    {

        public string Update(TAREA dto)
        {
            DaoTarea dao = new DaoTarea();
            return dao.Update(dto);

        }

        public int delete(int dto)
        {
            DaoTarea dao = new DaoTarea();
            return dao.Delete(dto);
        }

        //public string insert(USUARIO dto)
        //{
        //    DaoTarea dao = new DaoTarea();
        //    return dao.Insert(dto);
        //}

        public List<TAREA> read()
        {
            DaoTarea dao = new DaoTarea();
            return dao.Read();
        }
    }
    }
