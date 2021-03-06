﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using Entity_Layer;

namespace Bussines_Layer
{
    public class NegocioUnidad
    {
        public string Update(UNIDAD dto)
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.Update(dto);

        }

        public string Delete(string dto)
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.Delete(dto);
        }


        public string Insert(UNIDAD dto)
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.Insert(dto);
        }

        public List<UNIDAD> Read()
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.Read();
        }


        /*FUNCIONARIOS */
        public string UpdateF(UNIDAD dto)
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.UpdateF(dto);

        }

        public string DeleteF(string dto)
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.DeleteF(dto);
        }


        public string InsertF(UNIDAD dto)
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.InsertF(dto);
        }

        public List<UNIDAD> ReadF()
        {
            DaoUnidad dao = new DaoUnidad();
            return dao.ReadF();
        }
    }
}
