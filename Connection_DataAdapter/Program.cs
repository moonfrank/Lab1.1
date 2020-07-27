using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Connection_DataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dtEmpresas = new DataTable("Empresas");
            dtEmpresas.Columns.Add("CustomerID", typeof(string));
            dtEmpresas.Columns.Add("CompanyName", typeof(string));
            SqlConnection myconn = new SqlConnection();
            myconn.ConnectionString = "Data Source=LOCALHOST\\SQLEXPRESS;Initial Catalog=Northwind;User ID=sa;Pwd=123";

            #region .Fill con DataReader
            /*
            SqlCommand mycomando = new SqlCommand();
            mycomando.CommandText = "SELECT CustomerID, CompanyName FROM Customers";
            mycomando.Connection = myconn;
            
            myconn.Open();
            SqlDataReader mydr = mycomando.ExecuteReader();
            dtEmpresas.Load(mydr);
            myconn.Close();
            */
            #endregion

            #region .Fill con DataAdapter
            SqlDataAdapter myadap = new SqlDataAdapter("SELECT CustomerID, CompanyName FROM Customers", myconn);
            myconn.Open();
            myadap.Fill(dtEmpresas);
            myconn.Close();
            #endregion

            #region .Update
            Console.Write("Escriba el ID del Cliente al que desea modificar: ");
            DataRow[] rwEmpresas = dtEmpresas.Select("CustomerID = '" + Console.Read() + "'");
            if (rwEmpresas.Length!=1)
            {
                Console.WriteLine("Cliente no encontrado");
                Console.ReadKey();
                return;
            }
            DataRow rwEmpresa = rwEmpresas[0];
            Console.WriteLine("Nombre actual de la empresa: " + rwEmpresa["CompanyName"].ToString());
            Console.Write("Escriba nuevo nombre: ");
            rwEmpresa.BeginEdit();
            rwEmpresa["Company Name"]=Console.ReadLine();
            rwEmpresa.EndEdit();

            SqlCommand update = new SqlCommand();
            update.Connection = myconn;
            update.CommandText = "UPDATE Customers SET CompanyName = @CompanyName WHERE CustomerID = @CustomerID";
            update.Parameters.Add("@CompanyName", SqlDbType.NVarChar,50, "CompanyName");
            update.Parameters.Add("@CustomerID", SqlDbType.NVarChar, 5, "CustomerID");
            myadap.UpdateCommand = update;
            myadap.Update(dtEmpresas);
            #endregion

            #region Listado en Consola
            Console.WriteLine("Listado de Empresas:");
            foreach(DataRow rwEmp in dtEmpresas.Rows)
            {
                Console.WriteLine(rwEmp["CustomerID"].ToString() + " - " + rwEmp["CompanyName"].ToString());
            }
            Console.ReadKey();
            #endregion
        }
    }
}
