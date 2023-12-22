﻿using ClasesBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using DAC;

namespace WcfPachacamac
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        DACCategorias dacCategorias = new DACCategorias();

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public void insertCategorias(clsCategoria xCategoria)
        {
            
            dacCategorias.insert_categorias(xCategoria);
        }

        public List<clsCategoria> getCategorias()
        {
            return dacCategorias.listarcategorias();
        }

        public void updateCategorias(clsCategoria xCategoria)
        {
            dacCategorias.update_categorias(xCategoria);
        }

        public void deleteCategorias(int idCategoria)
        {
            dacCategorias.delete_categorias(idCategoria);
        }
    }
}
