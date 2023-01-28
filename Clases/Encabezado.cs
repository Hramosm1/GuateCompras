using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
   public class Encabezado
    {
        private int MaxLength = 10;
        public Int64 correlativo { get; set; }
        public string cui { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string tipoOrganizacion { get; set; }
        public string rgae { get; set; }
        public string adjudica { get; set; }
        public string contrasena { get; set; }
        public string representantes { get; set; }

        public string vEscritura { get; set; }
        public string vFechaConstitucion { get; set; }
        public string vFechaProvisional { get; set; }
        public string vFechaDefinitiva { get; set; }
        public string vFechaSat { get; set; }
        public string vAactividad { get; set; }
        public string vNitNotario { get; set; }
        public string vNitEstatus { get; set; }
        public string vMotivoEstatus { get; set; }

        //Domicilio Fiscal
        public string vDepartamento { get; set; }
        public string vMunicipio { get; set; }
        public string vDireccion { get; set; }
        public string vTelefonos { get; set; }
        public string vFax { get; set; }

        //Domicilio Comercial

        public string vPagWeb { get; set; }
        public string vEmail { get; set; }
        public string vDepartamentoC { get; set; }
        public string vMunicipioC { get; set; }
        public string vDireccionC { get; set; }
        public string vTelefonoC { get; set; }
        public string vFaxC { get; set; }        



       
}

    public  class detalle
    {
        //NOGS NPGS
        public Int64 correlativo { get; set; }     
        public string nit  { get; set; }
        public int tipoDetalle { get; set; }
        public string anioadj { get; set; }
        public string cantidadadj { get; set; }
        public string montoadj { get; set; }
        public string cantidadnpg { get; set; }
        public string montonpg { get; set; }
        public string cantTotal { get; set; }
        public string montoTotal { get; set; }

       
    }

    public class global
    {
        public List<Encabezado> lstEncabezado = new List<Encabezado>();
        public List<detalle> lstDetalle = new List<detalle>();
    }

    public class correlativo
    {
        //NOGS NPGS
        public Int64 intervalo { get; set; }
        public Int64 uCorrelativo { get; set; }
        public Int64 visitas { get; set; }
        public string serial { get; set; }
        public Int64 vActual { get; set; }

    }
}
