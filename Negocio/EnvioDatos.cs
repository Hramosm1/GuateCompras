using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
using DAO;
using System.Data;

namespace Negocio
{
  public  class EnvioDatos
    {

        public string Insert(Encabezado encabezado, List<detalle> detalle, int id)
        {
            DatosGCDao insertar = new DatosGCDao();
            return insertar.Insert(encabezado, detalle, id);             

        }

        public correlativo getCorrelativo(int id)
        {
            DatosGCDao getCoorelativo = new DatosGCDao();
            return getCoorelativo.getCorrelativo(id);

        }

      

        public List<Encabezado> busqueda(string consulta)
        {
            DatosGCDao getCoorelativo = new DatosGCDao();
            return getCoorelativo.busqueda(consulta);

        }

        public DataSet ReporteCrystal(Int64 correlativo, string nit)
        {
            DatosGCDao getCoorelativo = new DatosGCDao();
            return getCoorelativo.ReporteCrystal(correlativo,nit);

        }

        public void actualizaVisita(int id)
        {
            DatosGCDao getCoorelativo = new DatosGCDao();
             getCoorelativo.ActualizaVisita(id);

        }

        public string activar(string consulta)
        {
            DatosGCDao getCoorelativo = new DatosGCDao();
            return getCoorelativo.Activar(consulta);

        }

        public string ActualizarIntervalo(Int64 intervalo)
        {
            DatosGCDao getCoorelativo = new DatosGCDao();
            return getCoorelativo.ActualizaIntervalo(intervalo);

        }
    }
}
