﻿using System;
using System.Data;
using System.Data.SqlClient;

namespace Negocio
{
    public class Usuarios
    {
        public SqlDataAdapter DaUsuarios { get; set; }
        public SqlConnection Conn { get; set; }

        public Usuarios()
        {
            /*
             * Este connection string es para conectarse con la base de datos academia en el servidor
             * del departamento sistemas desde una PC de los laboratorios de sistemas:
             */
             // this.Conn = new SqlConnection("Data Source=serverisi;Initial Catalog=academia;Integrated Security=false;
             //                               "user=net;password=net;");

            // si realiza este Laboratorio desde su PC puede probar el siguiente connection string:
            // this.Conn = new SqlConnection("Data Source=localhost;Initial Catalog=academia;Integrated Security=true");

            /* Si realiza esta práctica sobre el MS SQL SERVER 2005 Express Edition entonces debe
             * utilizar el siguiente connection string:
             */
            this.Conn = new SqlConnection("Data Source=localhost\SqlExpress;Initial Catalog=academia;"+
                                          "Integrated Security=true;");

            this.DaUsuarios = new SqlDataAdapter("select * from usuarios", this.Conn);

            this.DaUsuarios.UpdateCommand =
            new SqlCommand(" UPDATE usuarios " +
            " SET tipo_doc = @tipo_doc, nro_doc = @nro_doc, fecha_nac = @fecha_nac, " +
            " apellido = @apellido, nombre = @nombre, direccion = @direccion, " +
            " telefono = @telefono, email = @email, celular = @celular, usuario = @usuario, " +
            " clave = @clave WHERE id=@id ", this.Conn);
            this.DaUsuarios.UpdateCommand.Parameters.Add("@tipo_doc", SqlDbType.Int, 1, "tipo_doc");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@nro_doc", SqlDbType.Int, 1, "nro_doc");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 1, "fecha_nac");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "direccion");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 50, "telefono");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@celular", SqlDbType.VarChar, 50, "celular");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50, "usuario");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@clave", SqlDbType.VarChar, 50, "clave");
            this.DaUsuarios.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 1, "id");
            this.DaUsuarios.InsertCommand =
            new SqlCommand(" INSERT INTO usuarios(tipo_doc,nro_doc,fecha_nac,apellido, " +
                " nombre,direccion,telefono,email,celular,usuario,clave) " +
                " VALUES (@tipo_doc,@nro_doc,@fecha_nac,@apellido,@nombre,@direccion, " +
                " @telefono,@email,@celular, @usuario, @clave  )", this.Conn);
            this.DaUsuarios.InsertCommand.Parameters.Add("@tipo_doc", SqlDbType.Int, 1, "tipo_doc");
            this.DaUsuarios.InsertCommand.Parameters.Add("@nro_doc", SqlDbType.Int, 1, "nro_doc");
            this.DaUsuarios.InsertCommand.Parameters.Add("@fecha_nac", SqlDbType.DateTime, 1, "fecha_nac");
            this.DaUsuarios.InsertCommand.Parameters.Add("@apellido", SqlDbType.VarChar, 50, "apellido");
            this.DaUsuarios.InsertCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 50, "nombre");
            this.DaUsuarios.InsertCommand.Parameters.Add("@direccion", SqlDbType.VarChar, 50, "direccion");
            this.DaUsuarios.InsertCommand.Parameters.Add("@telefono", SqlDbType.VarChar, 50, "telefono");
            this.DaUsuarios.InsertCommand.Parameters.Add("@email", SqlDbType.VarChar, 50, "email");
            this.DaUsuarios.InsertCommand.Parameters.Add("@celular", SqlDbType.VarChar, 50, "celular");
            this.DaUsuarios.InsertCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 50, "usuario");
            this.DaUsuarios.InsertCommand.Parameters.Add("@clave", SqlDbType.VarChar, 50, "clave");



            this.DaUsuarios.DeleteCommand =
                         new SqlCommand(" DELETE FROM usuarios WHERE id=@id ", this.Conn);
            this.DaUsuarios.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 1, "id");
        }

        public DataTable GetAll()
        {
            DataTable dtUsuarios = new DataTable();
            this.DaUsuarios.Fill(dtUsuarios);
            return dtUsuarios;
        }

        public void GuardarCambios(DataTable dtUsuarios)
        {
            this.DaUsuarios.Update(dtUsuarios);
            dtUsuarios.AcceptChanges();
        }

    }
}
