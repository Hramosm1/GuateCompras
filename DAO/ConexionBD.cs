using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql;
using MySql.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace DAO
{
    public class ConexionBD

    {
        /*   protected MySqlConnection Conexion =
              new MySqlConnection(
                  "server=localhost;uid=root;password=Sql@dmin;database=consultagc;"
                  );
                  */      


        static string connectionString;     

        static string ConnectionToMySql()
        {

            string Server,Database,User,Password;


#if TRACE && !DEBUG

            Server = "192.168.8.6";
            Database = "consultagc";
            User = "investigacion";
            Password = "vWCZ3UHg";

#elif DEBUG && TRACE
            Server = "192.168.8.8";
            Database = "consultagc";
            User = "investigacion";
            Password = "vWCZ3UHg";       
#endif


            // lee();
            //return connectionString = @"Data Source=SERVIDOR\SQLEXPRESS;Initial Catalog=consultagc;User ID=sa;Password=Sql@dmin"; ;
            //return connectionString = @"Data Source= 192.168.8.6; Initial Catalog = consultagc; User ID=investigacion; Password = vWCZ3UHg"; //PROD
            return connectionString = @"Data Source= "+Server+"; Initial Catalog = "+Database+"; User ID="+User+"; Password = "+ Password; //DESA
        }
        //protected MySqlConnection GetConnection()
        //{
        //    return new MySqlConnection(ConnectionToMySql());
        //}

      

        protected SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionToMySql());
        }

        static void lee()
        {
            //string[] lines = System.IO.File.ReadAllLines("conexion.dat");           
            //foreach (string line in lines)
            //{
            //    connectionString = Desencriptar(line);

            //}

            connectionString = "";

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




    }
}
