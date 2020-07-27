using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataSetNoTipado
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Tabla Alumnos
            DataTable dtAlumnos = new DataTable("Alumnos");

            DataColumn dtcolIDAlumno = new DataColumn("ID Alumno", typeof(int));
            dtcolIDAlumno.ReadOnly = true;
            dtcolIDAlumno.AutoIncrement = true;
            dtcolIDAlumno.AutoIncrementSeed = 0;
            dtcolIDAlumno.AutoIncrementStep = 1;
            DataColumn dtcolNombre = new DataColumn("Nombre", typeof(string));
            DataColumn dtcolApellido = new DataColumn("Apellido", typeof(string));

            dtAlumnos.Columns.Add(dtcolIDAlumno);
            dtAlumnos.Columns.Add(dtcolApellido);
            dtAlumnos.Columns.Add(dtcolNombre);

            dtAlumnos.PrimaryKey = new DataColumn[] { dtcolIDAlumno };

            DataRow rwAlumno = dtAlumnos.NewRow();
            rwAlumno[dtcolApellido] = "Perez";
            rwAlumno[dtcolNombre] = "Juan";
            dtAlumnos.Rows.Add(rwAlumno);

            DataRow rwAlumno2 = dtAlumnos.NewRow();
            rwAlumno2["Apellido"] = "Perez";
            rwAlumno2["Nombre"] = "Marcelo";
            dtAlumnos.Rows.Add(rwAlumno2);
            #endregion

            #region Tabla Cursos
            DataTable dtCursos = new DataTable("Cursos");

            DataColumn dtcolIDCurso = new DataColumn("ID Curso", typeof(int));
            dtcolIDCurso.ReadOnly = true;
            dtcolIDCurso.AutoIncrement = true;
            dtcolIDCurso.AutoIncrementSeed = 1;
            dtcolIDCurso.AutoIncrementStep = 1;
            DataColumn dtcolCurso = new DataColumn("Nombre", typeof(string));

            dtCursos.Columns.Add(dtcolIDCurso);
            dtCursos.Columns.Add(dtcolCurso);
            dtCursos.PrimaryKey = new DataColumn[] { dtcolIDCurso };

            DataRow rwCurso = dtCursos.NewRow();
            rwCurso[dtcolCurso] = "Informática";
            dtCursos.Rows.Add(rwCurso);
            #endregion

            #region Tabla Relacion Alumnos y Cursos
            DataTable dtAlumnos_Cursos = new DataTable("Alumnos_Cursos");
            DataColumn dtcol_ac_IDAlumno = new DataColumn("ID Alumno", typeof(int));
            DataColumn dtcol_ac_IDCurso = new DataColumn("ID Curso", typeof(int));
            dtAlumnos_Cursos.Columns.Add(dtcol_ac_IDAlumno);
            dtAlumnos_Cursos.Columns.Add(dtcol_ac_IDCurso);
            #endregion

            #region DataSet y DataRelations
            DataSet dsUniversidad = new DataSet();
            dsUniversidad.Tables.Add(dtAlumnos);
            dsUniversidad.Tables.Add(dtCursos);
            dsUniversidad.Tables.Add(dtAlumnos_Cursos);

            DataRelation relAlumno_ac = new DataRelation("Alumno_Cursos", dtcolIDAlumno, dtcol_ac_IDAlumno);
            DataRelation relCurso_ac = new DataRelation("Curso_Alumnos", dtcolIDCurso, dtcol_ac_IDCurso);

            dsUniversidad.Relations.Add(relAlumno_ac);
            dsUniversidad.Relations.Add(relCurso_ac);
            #endregion

            DataRow rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[dtcol_ac_IDAlumno] = 0;
            rwAlumnosCursos[dtcol_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);
            rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
            rwAlumnosCursos[dtcol_ac_IDAlumno] = 1;
            rwAlumnosCursos[dtcol_ac_IDCurso] = 1;
            dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);
            
            #region Mostrar en pantalla
            Console.Write("Ingrese nombre del curso: ");
            string materia = Console.ReadLine();
            Console.WriteLine("Listado de Alumnos del Curso "+materia+':');
            DataRow[] row_CursoInf = dtCursos.Select("Nombre = '" + materia + '\'');
            foreach(DataRow rowCu in row_CursoInf)
            {
                DataRow[] row_AlumnoInf = rowCu.GetChildRows(relCurso_ac);
                foreach (DataRow rowAl in row_AlumnoInf)
                {
                    Console.WriteLine(rowAl.GetParentRow(relAlumno_ac)[dtcolApellido].ToString() + ", " + rowAl.GetParentRow(relAlumno_ac)[dtcolNombre].ToString());
                }
                
            }

            #endregion

            Console.ReadKey();
        }
    }
}
