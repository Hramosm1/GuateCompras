using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;
using System.Data;
using MySql;
using MySql.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace DAO
{
    public class DatosGCDao : ConexionBD
    {

        List<Encabezado> lstEncabezado = new List<Encabezado>();
        List<detalle> lstdetalle = new List<detalle>();
        SqlDataReader LeerFilas;
        SqlCommand Comando = new SqlCommand();
        public List<global> VerRegistros(string Condicion)
        {
            var Conexion = GetConnection();
            Comando.Connection = Conexion;
            Comando.CommandText = "VerRegistros";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@Condicion", Condicion);
            Conexion.Open();
            LeerFilas = Comando.ExecuteReader();
            List<global> ListaGenerica = new List<global>();
            while (LeerFilas.Read())
            {
               
            }
            LeerFilas.Close();
            Conexion.Close();
            return ListaGenerica;
        }

        public string Insert(Encabezado encabezado, List<detalle> detalle, int id ) {


            SqlTransaction myTrans;
            var Conexion = GetConnection();
            Comando = new SqlCommand();            
            Conexion.Open();
            myTrans = Conexion.BeginTransaction();
            Comando.Connection = Conexion;
            Comando.Transaction = myTrans;
              

            try
            {


                Comando.CommandText = "delete from consultagc.detalleclientegc where correlativo=" + encabezado.correlativo +" and nit= '"+ encabezado.nit  + "'";
                Comando.ExecuteNonQuery();
                Comando.CommandText = "delete from consultagc.clientesgc where correlativo=" + encabezado.correlativo + " and nit= '" + encabezado.nit + "'";
                Comando.ExecuteNonQuery();
                if (encabezado.cui == null || string.IsNullOrEmpty(encabezado.cui)) { encabezado.cui = ""; }               
                if (encabezado.nombre == null || string.IsNullOrEmpty(encabezado.nombre)) { encabezado.nombre = ""; }
                if (encabezado.tipoOrganizacion == null || string.IsNullOrEmpty(encabezado.tipoOrganizacion)) { encabezado.tipoOrganizacion = ""; }
                if (encabezado.rgae == null || string.IsNullOrEmpty(encabezado.rgae)) { encabezado.rgae = ""; }
                if (encabezado.adjudica == null || string.IsNullOrEmpty(encabezado.adjudica)) { encabezado.adjudica = ""; }
                if (encabezado.contrasena == null || string.IsNullOrEmpty(encabezado.contrasena)) { encabezado.contrasena = ""; }
                if (encabezado.representantes == null || string.IsNullOrEmpty(encabezado.representantes)) { encabezado.representantes = ""; }
                if (encabezado.vEscritura == null || string.IsNullOrEmpty(encabezado.vEscritura)) { encabezado.vEscritura = ""; }
                if (encabezado.vFechaConstitucion == null || string.IsNullOrEmpty(encabezado.vFechaConstitucion)) { encabezado.vFechaConstitucion = ""; }
                if (encabezado.vFechaProvisional == null || string.IsNullOrEmpty(encabezado.vFechaProvisional)) { encabezado.vFechaProvisional = ""; }
                if (encabezado.vFechaDefinitiva == null || string.IsNullOrEmpty(encabezado.vFechaDefinitiva)) { encabezado.vFechaDefinitiva = ""; }
                if (encabezado.vFechaSat == null || string.IsNullOrEmpty(encabezado.vFechaSat)) { encabezado.vFechaSat = ""; }
                if (encabezado.vAactividad == null || string.IsNullOrEmpty(encabezado.vAactividad)) { encabezado.vAactividad = ""; }
                if (encabezado.vNitNotario == null || string.IsNullOrEmpty(encabezado.vNitNotario)) { encabezado.vNitNotario = ""; }
                if (encabezado.vNitEstatus == null || string.IsNullOrEmpty(encabezado.vNitEstatus)) { encabezado.vNitEstatus = ""; }
                if (encabezado.vMotivoEstatus == null || string.IsNullOrEmpty(encabezado.vMotivoEstatus)) { encabezado.vMotivoEstatus = ""; }
                if (encabezado.vDepartamento == null || string.IsNullOrEmpty(encabezado.vDepartamento)) { encabezado.vDepartamento = ""; }
                if (encabezado.vMunicipio == null || string.IsNullOrEmpty(encabezado.vMunicipio)) { encabezado.vMunicipio = ""; }
                if (encabezado.vDireccion == null || string.IsNullOrEmpty(encabezado.vDireccion)) { encabezado.vDireccion = ""; }
                if (encabezado.vTelefonos == null || string.IsNullOrEmpty(encabezado.vTelefonos)) { encabezado.vTelefonos = ""; }
                if (encabezado.vFax == null || string.IsNullOrEmpty(encabezado.vFax)) { encabezado.vFax = ""; }
                if (encabezado.vPagWeb == null || string.IsNullOrEmpty(encabezado.vPagWeb)) { encabezado.vPagWeb = ""; }
                if (encabezado.vEmail == null || string.IsNullOrEmpty(encabezado.vEmail)) { encabezado.vEmail = ""; }
                if (encabezado.vDepartamentoC == null || string.IsNullOrEmpty(encabezado.vDepartamentoC)) { encabezado.vDepartamentoC = ""; }
                if (encabezado.vMunicipioC == null || string.IsNullOrEmpty(encabezado.vMunicipioC)) { encabezado.vMunicipioC = ""; }
                if (encabezado.vDireccionC == null || string.IsNullOrEmpty(encabezado.vDireccionC)) { encabezado.vDireccionC = ""; }
                if (encabezado.vTelefonoC == null || string.IsNullOrEmpty(encabezado.vTelefonoC)) { encabezado.vTelefonoC = ""; }
                if (encabezado.vFaxC == null || string.IsNullOrEmpty(encabezado.vFaxC)) { encabezado.vFaxC = ""; }


                // (d.nit.Trim().Length > 0 ? IIf(d.nit.Trim()) : "")
                String sqlInsert = "Insert into consultagc.clientesgc values(";
                sqlInsert = sqlInsert + encabezado.correlativo + ",";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.cui.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.nit.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.nombre.Trim())+"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.tipoOrganizacion.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.rgae.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.adjudica.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.contrasena.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.representantes.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vEscritura.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vFechaConstitucion.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vFechaProvisional.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vFechaDefinitiva.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vFechaSat.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vAactividad.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vNitNotario.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vNitEstatus.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vMotivoEstatus.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vDepartamento.Trim())  +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vMunicipio.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vDireccion.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vTelefonos.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vFax.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vPagWeb.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vEmail.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vDepartamentoC.Trim()) +"',";
                sqlInsert = sqlInsert + "'" +  IIf(encabezado.vMunicipioC.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vDireccionC.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vTelefonoC.Trim()) +"',";
                sqlInsert = sqlInsert + "'" + IIf(encabezado.vFaxC.Trim()) +"')";


                //Comando = new MySqlCommand(sqlInsert, Conexion);
                Comando.CommandText = sqlInsert;
                Comando.ExecuteNonQuery();

                //Conexion.Close();

                foreach (var d in detalle)
                {

                    //person != null && !string.IsNullOrEmpty(person.Name);
                    if (d.anioadj==null || string.IsNullOrEmpty(d.anioadj)){d.anioadj = "";}
                    if (d.cantidadadj == null || string.IsNullOrEmpty(d.cantidadadj)) { d.cantidadadj = ""; }
                    if (d.montoadj == null || string.IsNullOrEmpty(d.montoadj)) { d.montoadj = ""; }
                    if (d.cantidadnpg == null || string.IsNullOrEmpty(d.cantidadnpg)) { d.cantidadnpg = ""; }
                    if (d.montonpg == null || string.IsNullOrEmpty(d.montonpg)) { d.montonpg = ""; }
                    if (d.cantTotal == null || string.IsNullOrEmpty(d.cantTotal)) { d.cantTotal = ""; }
                    if (d.montoTotal == null || string.IsNullOrEmpty(d.montoTotal)) { d.montoTotal = ""; }

                    sqlInsert = "";
                    sqlInsert = "Insert into consultagc.detalleclientegc (correlativo,nit,anioadj,cantidadadj,montoadj,cantidadnpg,montonpg,cantTotal,montoTotal,TipoDetalle) values(";
                    sqlInsert = sqlInsert + d.correlativo + ",";
                    sqlInsert = sqlInsert + "'" +  IIf(d.nit.Trim()) + "',";
                    sqlInsert = sqlInsert + "'" +  IIf(d.anioadj.Trim()) + "',";
                    sqlInsert = sqlInsert + "'" +  IIf(d.cantidadadj.Trim())  + "',";
                    sqlInsert = sqlInsert + "'" +  IIf(d.montoadj.Trim())  + "',";
                    sqlInsert = sqlInsert + "'" +  IIf(d.cantidadnpg.Trim())  +"',";
                    sqlInsert = sqlInsert + "'" +  IIf(d.montonpg.Trim())  + "',";
                    sqlInsert = sqlInsert + "'" +  IIf(d.cantTotal.Trim())  +"',";
                    sqlInsert = sqlInsert + "'" +  IIf(d.montoTotal.Trim()) +"',";
                    sqlInsert = sqlInsert + d.tipoDetalle + ")";

                    // Comando = new MySqlCommand(sqlInsert, Conexion);
                    Comando.CommandText = sqlInsert;                    
                    Comando.ExecuteNonQuery();


                    }

                    sqlInsert = "";
               sqlInsert = "update consultagc.correlativo set correlativo= " + encabezado.correlativo +" where id=" +id;
               Comando.CommandText = sqlInsert;
               Comando.ExecuteNonQuery();

                myTrans.Commit();
                return "OK";
            }
            catch (SqlException ex)
            {
                myTrans.Rollback();
                return ex.ToString();
            }
            finally
            {
                Conexion.Close();
            }
            

        }

        private string IIf(string cadena)
        {
            string valor = "";
            int MaxLength = 500;
            if (cadena.Length > MaxLength)
            {
                cadena.Trim().Substring(0, cadena.Length);
            }
            else
            {
                valor= cadena.Trim();
            }


            return valor;
        }
        public void Edit(Encabezado encabezado, List<detalle> detalle) { }

        public correlativo getCorrelativo(int correlativo) {
            correlativo UltimoCorrelativo = new correlativo();
            var Conexion = GetConnection();

            Conexion.Open();
            string sql = "select *from consultagc.correlativo where id=" + correlativo;
            Comando = new SqlCommand(sql, Conexion);

            SqlDataReader reader = Comando.ExecuteReader();
            while (reader.Read())
            {
                UltimoCorrelativo.uCorrelativo = reader.GetInt64(0);
                UltimoCorrelativo.intervalo = reader.GetInt64(1);
                try
                {
                    UltimoCorrelativo.visitas = Int64.Parse(Desencriptar(reader.GetString(2)));
                }
                catch {
                    UltimoCorrelativo.visitas = 0;
                }
                try
                {
                    UltimoCorrelativo.serial = (Desencriptar(reader.GetString(3)));
                }
                catch
                {
                    UltimoCorrelativo.serial ="";
                }

                try
                {
                    UltimoCorrelativo.vActual =Int64.Parse(Desencriptar(reader.GetString(4)));
                }
                catch
                {
                    UltimoCorrelativo.vActual = 0;
                }


            }
            Conexion.Close();

            return UltimoCorrelativo;
        }


        public List<Encabezado> busqueda(string consulta)
        {
            var Conexion = GetConnection();
            List<Encabezado> resultado = new List<Encabezado>();
            Conexion.Open();
            string sql = "select correlativo, nit, nombre from consultagc.clientesgc " + consulta;
            Comando = new SqlCommand(sql, Conexion);

            SqlDataReader reader = Comando.ExecuteReader();
            while (reader.Read())
            {
                Encabezado Enc = new Encabezado();
                Enc.correlativo = reader.GetInt64(0);
                Enc.nit = reader.GetString(1);
                Enc.nombre = reader.GetString(2);
                resultado.Add(Enc);


            }
            Conexion.Close();

            return resultado;
        }


        public DataSet ReporteCrystal(Int64 correlativo, string nit)
        {

            DataSet resultado = new DataSet();
            SqlDataAdapter SqlReporte = new SqlDataAdapter();
            var Conexion = GetConnection();


            //  Dim dsPc As New dsOrden
            Conexion.Open();
            string sql = "SELECT  a.correlativo, cui, a.nit, nombre, tipoorganizacion, rgae, adjudica, "+
              " contrasena, representantes, escritura, fechaconstitucion, fechaprovisional, fechadefinitiva,"+
              " fechasat, actividad, nitnotario, nitestatus, motivoestatus, departamento, municipio, direccion,"+
              " telefonos, fax, pagweb, email, departamentoc, municipioc, direccionc, telefonoc, faxc, anioadj, " +
              " cantidadadj, montoadj, cantidadnpg, montonpg, cantTotal, montoTotal, isnull(TipoDetalle,0) TipoDetalle " +
               " FROM consultagc.clientesgc a left join consultagc.detalleclientegc b on  a.correlativo = b.correlativo and a.nit = b.nit " +
                " where a.nit='" + nit.Trim() + "'" + " AND a.correlativo=" + correlativo.ToString();
            


            SqlReporte = new SqlDataAdapter(sql, Conexion);
            SqlReporte.Fill(resultado, "dtReporte");  
            Conexion.Close();

            return resultado;
        }


        static string Desencriptar(string Input)
        {
            var IV = Encoding.ASCII.GetBytes("SysCoN21"); // La clave debe ser de 8 caracteres
            var EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5"); // No se puede alterar la cantidad de caracteres pero si la clave
            var buffer = Convert.FromBase64String(Input);
            var des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;
            return Encoding.UTF8.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        public string ActualizaVisita(int id)
        {

            correlativo Ucorrelativo = new correlativo();
            Ucorrelativo = getCorrelativo(id);

            SqlTransaction myTrans;
            var Conexion = GetConnection();
            Comando = new SqlCommand();
            Conexion.Open();
            myTrans = Conexion.BeginTransaction();
            Comando.Connection = Conexion;
            Comando.Transaction = myTrans;

            try
            {
                

                string correlativo = Encriptar((Ucorrelativo.vActual + 1).ToString());
                string sqlupdate = "update consultagc.correlativo set va= '" + correlativo + "'";
                Comando.CommandText = sqlupdate;
                Comando.ExecuteNonQuery();

                myTrans.Commit();
                return "OK";
            }
            catch (SqlException ex)
            {
                myTrans.Rollback();
                return ex.ToString();
            }
            finally
            {
                Conexion.Close();
            }


        }

        public string Encriptar(string dato)
        {
            var IV = Encoding.ASCII.GetBytes("SysCoN21"); // La clave debe ser de 8 caracteres
            var EncryptionKey = Convert.FromBase64String("rpaSPvIvVLlrcmtzPU9/c67Gkj7yL1S5");
            var buffer = Encoding.UTF8.GetBytes(dato);
            var des = new TripleDESCryptoServiceProvider();
            des.Key = EncryptionKey;
            des.IV = IV;
            return Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
        }

        public string Activar(string dato)
        {

            dato = Desencriptar(dato);
            string[] subs = dato.Split(',');

            int total = 0;
            string dato1 = "";
            string dato2 = "";
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
             if (dato1!="-666" && dato2 != "-667")
                {
                return "-1";
            }

            dato1 = Encriptar(dato1);
            dato2 = Encriptar(dato2);

            SqlTransaction myTrans;
            var Conexion = GetConnection();
            Comando = new SqlCommand();
            Conexion.Open();
            myTrans = Conexion.BeginTransaction();
            Comando.Connection = Conexion;
            Comando.Transaction = myTrans;

            try
            {
                
                string sqlupdate = "update consultagc.correlativo set v= '" + dato1 +"' , s='" + Encriptar(dato) + "' , va='" +dato2+"'";
                Comando.CommandText = sqlupdate;
                Comando.ExecuteNonQuery();
                myTrans.Commit();
                return "OK";
            }
            catch (SqlException ex)
            {
                myTrans.Rollback();
                return ex.ToString();
            }
            finally
            {
                Conexion.Close();
            }


        }

        public string ActualizaIntervalo(Int64 intervalo)
        {

            correlativo Ucorrelativo = new correlativo();
           

            SqlTransaction myTrans;
            var Conexion = GetConnection();
            Comando = new SqlCommand();
            Conexion.Open();
            myTrans = Conexion.BeginTransaction();
            Comando.Connection = Conexion;
            Comando.Transaction = myTrans;

            try
            {               
                string sqlupdate = "update consultagc.correlativo set intervalo= " + intervalo;
                Comando.CommandText = sqlupdate;
                Comando.ExecuteNonQuery();

                myTrans.Commit();
                return "OK";
            }
            catch (SqlException ex)
            {
                myTrans.Rollback();
                return ex.ToString();
            }
            finally
            {
                Conexion.Close();
            }


        }

    }
}
