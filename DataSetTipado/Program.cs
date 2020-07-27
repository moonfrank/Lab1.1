using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetTipado
{
    class Program
    {
        static void Main(string[] args)
        {
            dsUniversidad miUniversidad = new dsUniversidad();
            dsUniversidad.dtAlumnosDataTable dtAlumnos = new dsUniversidad.dtAlumnosDataTable();
            dsUniversidad.dtCursosDataTable dtCursos = new dsUniversidad.dtCursosDataTable();
            dsUniversidad.dtAlumnosRow rwAlumno = dtAlumnos.NewdtAlumnosRow();
            rwAlumno.Apellido = "Perez";
            rwAlumno.Nombre = "Juan";
            dtAlumnos.AdddtAlumnosRow(rwAlumno);
            rwAlumno = dtAlumnos.NewdtAlumnosRow();
            rwAlumno.Apellido = "Perez";
            rwAlumno.Nombre = "Marcelo";
            dtAlumnos.AdddtAlumnosRow(rwAlumno);

            dsUniversidad.dtCursosRow rwCurso = dtCursos.NewdtCursosRow();
            rwCurso.Curso = "Informática";
            dtCursos.AdddtCursosRow(rwCurso);

            dsUniversidad.dtAlumnos_CursosDataTable dtAlumnos_Cursos = new dsUniversidad.dtAlumnos_CursosDataTable();
            dsUniversidad.dtAlumnos_CursosRow rwAlumnosCursos = dtAlumnos_Cursos.NewdtAlumnos_CursosRow();
            dtAlumnos_Cursos.AdddtAlumnos_CursosRow(rwAlumno, rwCurso);
        }
    }
}
