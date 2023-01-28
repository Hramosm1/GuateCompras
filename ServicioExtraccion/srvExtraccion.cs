using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using ScrapySharp;
using ScrapySharp.Extensions;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Clases;

namespace ServicioExtraccion
{
    public partial class srvExtraccion : ServiceBase
    {
        public srvExtraccion()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }
        protected void descrgar()
            {
            List<String> Resumen = new List<string>();
            Encabezado Enc = new Encabezado();
            List<detalle> Det = new List<detalle>();
            HtmlWeb cWeb = new HtmlWeb();
            HtmlDocument doc = cWeb.Load("https://www.guatecompras.gt/proveedores/consultaDetProvee.aspx?rqp=10&lprv=41042");
            //HtmlDocument doc = cWeb.Load("https://www.guatecompras.gt/proveedores/consultaDetProvee.aspx?rqp=10&lprv=2093004");

            string cui = "";
            string nombre = "";
            string nit = "";
            string tipoOrganizacion = "";
            string rgae = "";
            string adjudica = "";
            string contrasena = "";

            foreach (var nodo in doc.DocumentNode.CssSelect(".cuadoResumenFrame"))
            {

                cui = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblCUI']").InnerText.ToString();
                nombre = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNombreProv']").InnerText.ToString();
                nit = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNIT']").InnerText.ToString();
                tipoOrganizacion = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblTipoOrganizacion']").InnerText.ToString();
                rgae = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblHabilitado']").InnerText.ToString();
                adjudica = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblAdj']").InnerText.ToString();
                contrasena = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblContraSnl']").InnerText.ToString();
            }


            //representante Legal
            int i = 0;
            string representantes = "";
            try
            {
                foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_gvRepresentantesLegales")).Descendants("tr"))
                {
                    if (i > 0)
                    {
                        if (i == 1)
                        {
                            representantes = row.InnerText.Trim();
                        }
                        else
                        {
                            representantes = representantes + " || " + row.InnerText.Trim();
                        }
                    }
                    i++;

                }
                representantes = representantes.Replace(System.Environment.NewLine, " ");
                representantes = Regex.Replace(representantes, "\\s+", " ");
            }
            catch (Exception)
            {
                representantes = "";
            }



            //Datos Adicionales
            string vEscritura = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNumeroEscrituraConstitucion']").InnerText.ToString();
            string vFechaConstitucion = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblFechaConstitucion']").InnerText.ToString();
            string vFechaProvisional = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblRegistroMercantilProv']").InnerText.ToString();
            string vFechaDefinitiva = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblRegistroMercantilDef']").InnerText.ToString();
            string vFechaSat = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblInscripcionSAT']").InnerText.ToString();
            string vAactividad = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblActividadEconomica']").InnerText.ToString();
            string vNitNotario = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNITAbogado']").InnerText.ToString();
            string vNitEstatus = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblEstatusSAT']").InnerText.ToString();
            string vMotivoEstatus = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblMotivoSAT']").InnerText.ToString();

            //Domicilio Fiscal
            string vDepartamento = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomDepartamento']").InnerText.ToString();
            string vMunicipio = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomMunicipio']").InnerText.ToString();
            string vDireccion = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomDireccion']").InnerText.ToString();
            string vTelefonos = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomTelefono']").InnerText.ToString();
            string vFax = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomFax']").InnerText.ToString();

            //Domicilio Comercial

            string vPagWeb = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComPagina']").InnerText.ToString();
            string vEmail = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComCorreo']").InnerText.ToString();
            string vDepartamentoC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComDepartamento']").InnerText.ToString();
            string vMunicipioC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComMunicipio']").InnerText.ToString();
            string vDireccionC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComDireccion']").InnerText.ToString();
            string vTelefonoC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComTelefono']").InnerText.ToString();
            string vFaxC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComFAX']").InnerText.ToString();

            string vNogsNpgs = doc.DocumentNode.SelectSingleNode("//table[@id='MasterGC_ContentBlockHolder_dbResumen']").InnerText.ToString();



            //NOGS NPGS
            string anioadj = "";
            string cantidadadj = "";
            string montoadj = "";
            string cantidadnpg = "";
            string montonpg = "";
            string cantTotal = "";
            string montoTotal = "";
            int n = 3;

            foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_dbResumen")).Descendants("tr"))
            {
                if (n == 6)
                {
                    break;
                }

                anioadj = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_Anio']").InnerText.ToString();
                cantidadadj = doc.DocumentNode.SelectSingleNode("//a[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_HLinkCantAdjConcurso']").InnerText.ToString();
                montoadj = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblMontoAdjConcurso']").InnerText.ToString();
                cantidadnpg = doc.DocumentNode.SelectSingleNode("//a[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_HLinkCantPSC']").InnerText.ToString();
                montonpg = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblMontoPSC']").InnerText.ToString();
                cantTotal = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblCantTotal']").InnerText.ToString();
                montoTotal = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblMontoTotal']").InnerText.ToString();
                n++;

            }



            // INCONFORMIDADES
            string incoformidad = "";
            string entidad = "";


            n = 1;

            foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_gvInconformidades")).Descendants("tr"))
            {
                if (n == 4)
                {
                    break;
                }

                incoformidad = "Numero: " + doc.DocumentNode.SelectSingleNode("//span[@title='Número de la inconformidad']").InnerText.ToString() +
                " , Fecha: " + doc.DocumentNode.SelectSingleNode("//span[@title='Fecha de publicación']").InnerText.ToString() +
                " , status: " + doc.DocumentNode.SelectSingleNode("//span[@title='Estatus en que se encuentra la inconformidad']").InnerText.ToString();

                entidad = "Entidad: " + doc.DocumentNode.SelectSingleNode("//span[@title='Entidad compradora contra la que se presentó la inconformidad']").InnerText.ToString() +
                 " , motivo:" + doc.DocumentNode.SelectSingleNode("//a[@title='Motivo de la inconformidad']").InnerText.ToString();
                n++;

            }



            // PROCESOS DE COMPRA
            n = 1;

            string proceso = "";
            string dato1 = "";
            string dato2 = "";

            foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_Grd_Titulos_ctl02_GV_Mensajes")).Descendants("tr"))
            {

                proceso = row.InnerText;
                proceso = Regex.Replace(proceso, "\\t+", "");
                proceso = Regex.Replace(proceso, "\\r+", "");
                proceso = Regex.Replace(proceso, "\\n+", "");

                proceso = ReducirEspaciado(proceso);
                proceso = proceso.Trim();
                string[] subs = proceso.Split(' ');


                int total = 0;
                foreach (var sub in subs)
                {
                    if (total == 0)
                    {
                        dato1 = sub;
                    }
                    else
                    {
                        dato2 = sub;
                    };
                    total++;
                }
                System.Console.WriteLine(dato1 + " " + dato2);
            }


            // CONTRATO ABIERTO
            n = 3;
            string categoria = "";
            string cantCategoria = "";
            foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_dgResultado")).Descendants("tr"))
            {
                if (n == 6)
                {
                    break;
                }

                if (doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dgResultado_ctl0" + n + "_lblCat']") != null)
                {
                    categoria = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dgResultado_ctl0" + n + "_lblCat']").InnerText.ToString();
                    cantCategoria = doc.DocumentNode.SelectSingleNode("//a[@id='MasterGC_ContentBlockHolder_dgResultado_ctl0" + n + "_lnkProvee']").InnerText.ToString();

                }

                n++;

            }

        }

        public static string ReducirEspaciado(string Cadena)
        {
            while (Cadena.Contains("  "))
            {
                Cadena = Cadena.Replace("  ", " ");
            }

            return Cadena;
        }
    }
}
