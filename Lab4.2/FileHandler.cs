using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.IO;

namespace Lab4._2
{
    class FileHandler
    {
        protected DataTable misContactos;

        public FileHandler()
        {
            this.misContactos = this.GetTabla();
        }

        public virtual DataTable GetTabla()
        {
            return new DataTable();
        }

        public virtual void AplicaCambios()
        {

        }

        public void Listar()
        {
            foreach (DataRow fila in this.misContactos.Rows)
            {
                if (fila.RowState!=DataRowState.Deleted)
                {
                    foreach (DataColumn col in this.misContactos.Columns)
                        Console.WriteLine("{0}: {1}", col.ColumnName, fila[col]);
                    Console.WriteLine();
                }
            }
        }

        public void NuevaFila()
        {
            DataRow fila = this.misContactos.NewRow();
            foreach (DataColumn col in this.misContactos.Columns)
            {
                Console.Write("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();
            }
            this.misContactos.Rows.Add(fila);
        }

        public void EditarFila()
        {
            Console.WriteLine("Ingrese el numero de fila a editar");
            int nroFila = int.Parse(Console.ReadLine());
            DataRow fila = this.misContactos.Rows[nroFila - 1];
            for (int nroCol = 1; nroCol<this.misContactos.Columns.Count; nroCol++)
            {
                DataColumn col = this.misContactos.Columns[nroCol];
                Console.Write("Ingrese {0}:", col.ColumnName);
                fila[col] = Console.ReadLine();
            }
        }

        public void EliminarFila()
        {
            Console.WriteLine("Ingrese el numero de fila a eliminar");
            this.misContactos.Rows[(int.Parse(Console.ReadLine())) - 1].Delete();
        }
    }
}
