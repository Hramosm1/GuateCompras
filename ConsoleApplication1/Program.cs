using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScrapySharp;
using ScrapySharp.Extensions;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Clases;
using Negocio;


namespace ConsoleApplication1
{
    class Program
    {
        public static int actualid = 0;
        static void Main(string[] args)
        {
            //  Console.WriteLine("Introduzca un texto");
            actualid = 0;
            DescargarInfo(actualid);


        }

        public static bool hayInternet()
        {
           
            System.Uri Url = new System.Uri("https://www.google.com/");

            System.Net.WebRequest WebRequest;
            WebRequest = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse objetoResp;

            try
            {
                objetoResp = WebRequest.GetResponse();              
                objetoResp.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
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

        public static void DescargarInfo(int idd)
        {
            try
            {
                if (hayInternet())
                { 
                Int64 correlativo = 0;
            Int64 intervalo = 0;
            string nit = "";

            correlativo Ucorrelativo = new correlativo();
            EnvioDatos detalleCorrelativo = new EnvioDatos();
                    int id = idd;
            Ucorrelativo = detalleCorrelativo.getCorrelativo(id);
                    intervalo = Ucorrelativo.intervalo;
                    correlativo =Ucorrelativo.uCorrelativo;
                    string error = "";
            int Nerror = 0;

            for (int x = 0; x < intervalo; x++)
            {
                        error = "";
                Encabezado enc = new Encabezado();
                List<detalle> det = new List<detalle>();
                HtmlWeb cWeb = new HtmlWeb();
                HtmlDocument doc = cWeb.Load("https://www.guatecompras.gt/proveedores/consultaDetProvee.aspx?rqp=10&lprv=" + correlativo.ToString());

                if (doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblError']") != null)
                {
                    error = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblError']").InnerText.ToString();

                }

                if (!(error.Contains("La fuente de información no está disponible")))
                {

                    enc.correlativo = correlativo;
                    foreach (var nodo in doc.DocumentNode.CssSelect(".cuadoResumenFrame"))
                    {

                        enc.cui = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblCUI']").InnerText.ToString();
                        enc.nombre = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNombreProv']").InnerText.ToString().ToUpper();
                        nit = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNIT']").InnerText.ToString();
                        enc.nit = nit.ToUpper();
                        enc.tipoOrganizacion = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblTipoOrganizacion']").InnerText.ToString();
                        enc.rgae = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblHabilitado']").InnerText.ToString();
                        enc.adjudica = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblAdj']").InnerText.ToString();
                        enc.contrasena = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblContraSnl']").InnerText.ToString();
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
                        enc.representantes = Regex.Replace(representantes, "\\s+", " ");
                    }
                    catch (Exception)
                    {
                        enc.representantes = "";
                    }



                    //Datos Adicionales
                    enc.vEscritura = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNumeroEscrituraConstitucion']").InnerText.ToString();
                    enc.vFechaConstitucion = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblFechaConstitucion']").InnerText.ToString();
                    enc.vFechaProvisional = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblRegistroMercantilProv']").InnerText.ToString();
                    enc.vFechaDefinitiva = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblRegistroMercantilDef']").InnerText.ToString();
                    enc.vFechaSat = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblInscripcionSAT']").InnerText.ToString();
                    enc.vAactividad = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblActividadEconomica']").InnerText.ToString();
                    enc.vNitNotario = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblNITAbogado']").InnerText.ToString();
                    enc.vNitEstatus = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblEstatusSAT']").InnerText.ToString();
                    enc.vMotivoEstatus = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblMotivoSAT']").InnerText.ToString();

                    //Domicilio Fiscal
                    enc.vDepartamento = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomDepartamento']").InnerText.ToString();
                    enc.vMunicipio = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomMunicipio']").InnerText.ToString();
                    enc.vDireccion = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomDireccion']").InnerText.ToString();
                    enc.vTelefonos = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomTelefono']").InnerText.ToString();
                    enc.vFax = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblDomFax']").InnerText.ToString();

                    //Domicilio Comercial

                    enc.vPagWeb = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComPagina']").InnerText.ToString();
                    enc.vEmail = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComCorreo']").InnerText.ToString();
                    enc.vDepartamentoC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComDepartamento']").InnerText.ToString();
                    enc.vMunicipioC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComMunicipio']").InnerText.ToString();
                    enc.vDireccionC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComDireccion']").InnerText.ToString();
                    enc.vTelefonoC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComTelefono']").InnerText.ToString();
                    enc.vFaxC = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_lblComFAX']").InnerText.ToString();



                    int n = 3;
                    try
                    {

                        foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_dbResumen")).Descendants("tr"))
                        {
                            if (n == 6)
                            {
                                break;
                            }
                            detalle detalle = new detalle();
                            detalle.nit = nit;
                            detalle.correlativo = correlativo;
                            detalle.tipoDetalle = 1;
                            detalle.anioadj = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_Anio']").InnerText.ToString();
                            detalle.cantidadadj = doc.DocumentNode.SelectSingleNode("//a[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_HLinkCantAdjConcurso']").InnerText.ToString();
                            detalle.montoadj = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblMontoAdjConcurso']").InnerText.ToString();
                            detalle.cantidadnpg = doc.DocumentNode.SelectSingleNode("//a[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_HLinkCantPSC']").InnerText.ToString();
                            detalle.montonpg = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblMontoPSC']").InnerText.ToString();
                            detalle.cantTotal = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblCantTotal']").InnerText.ToString();
                            detalle.montoTotal = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dbResumen_ctl0" + n + "_lblMontoTotal']").InnerText.ToString();
                            det.Add(detalle);
                            n++;

                        }

                    }
                    catch (Exception)
                    {

                    }




                    // INCONFORMIDADES     
                    n = 1;
                    try
                    {
                        foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_gvInconformidades")).Descendants("tr"))
                        {
                            if (n == 4)
                            {
                                break;
                            }
                            detalle detalle = new detalle();
                            detalle.nit = nit;
                            detalle.correlativo = correlativo;
                            detalle.tipoDetalle = 2;

                            detalle.anioadj = "Numero: " + doc.DocumentNode.SelectSingleNode("//span[@title='Número de la inconformidad']").InnerText.ToString() +
                            " , Fecha: " + doc.DocumentNode.SelectSingleNode("//span[@title='Fecha de publicación']").InnerText.ToString() +
                            " , status: " + doc.DocumentNode.SelectSingleNode("//span[@title='Estatus en que se encuentra la inconformidad']").InnerText.ToString();

                            detalle.cantidadadj = "Entidad: " + doc.DocumentNode.SelectSingleNode("//span[@title='Entidad compradora contra la que se presentó la inconformidad']").InnerText.ToString() +
                             " , motivo:" + doc.DocumentNode.SelectSingleNode("//a[@title='Motivo de la inconformidad']").InnerText.ToString();

                            det.Add(detalle);
                            n++;

                        }
                    }
                    catch (Exception)
                    {

                    }



                    // PROCESOS DE COMPRA
                    n = 1;

                    string proceso = "";
                    string dato1 = "";
                    string dato2 = "";
                    try
                    {
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

                            detalle detalle = new detalle();
                            detalle.nit = nit;
                            detalle.correlativo = correlativo;
                            detalle.anioadj = dato1;
                            detalle.cantidadadj = dato2;
                            detalle.tipoDetalle = 3;

                            det.Add(detalle);

                        }
                    }
                    catch (Exception)
                    {

                    }


                    // CONTRATO ABIERTO
                    n = 3;
                    try
                    {
                        foreach (HtmlNode row in doc.DocumentNode.Descendants("table").FirstOrDefault(_ => _.Id.Equals("MasterGC_ContentBlockHolder_dgResultado")).Descendants("tr"))
                        {
                            if (n == 6)
                            {
                                break;
                            }

                            if (doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dgResultado_ctl0" + n + "_lblCat']") != null)
                            {
                                detalle detalle = new detalle();
                                detalle.nit = nit;
                                detalle.correlativo = correlativo;
                                detalle.anioadj = doc.DocumentNode.SelectSingleNode("//span[@id='MasterGC_ContentBlockHolder_dgResultado_ctl0" + n + "_lblCat']").InnerText.ToString();
                                detalle.cantidadadj = doc.DocumentNode.SelectSingleNode("//a[@id='MasterGC_ContentBlockHolder_dgResultado_ctl0" + n + "_lnkProvee']").InnerText.ToString(); ;
                                detalle.tipoDetalle = 4;
                                det.Add(detalle);

                            }

                            n++;

                        }
                    }
                    catch (Exception)
                    {

                    }

                    EnvioDatos Enviar = new EnvioDatos();
                    if (Enviar.Insert(enc, det, id) != "OK")
                    {
                        String manejoError = "Error";
                        Nerror++;

                    };
                    correlativo++;
                            Console.WriteLine("Importando correlativo {0} ", correlativo);
                        }
                else
                {
                    Nerror++;
                            correlativo++;
                            Console.WriteLine("no encontro informacion {0} ", correlativo);

                        }
                        // si hay 100 errores salimos para no congestionar, posiblemente ya llego al final 
                        if (Nerror == 10000) { break; };
                       
                    }


                 
                }
                else
            {
                    Console.WriteLine("Sin internet ");
                    DescargarInfo(actualid);
                }

            }
            catch (Exception)
            {
                Console.WriteLine("Encontro Error, intentara reestablecer");
                DescargarInfo(actualid);
            }


        }

    }
}
