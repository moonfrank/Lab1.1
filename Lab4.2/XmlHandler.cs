using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._2
{
    class XmlHandler:FileHandler
    {
        protected DataSet ds;

        public override DataTable GetTabla()
        {
            this.ds = new DataSet();
            this.ds.ReadXml("agenda.xml");
            return this.ds.Tables["contactos"];
        }

        public override void AplicaCambios()
        {
            this.ds.WriteXml("agenda.xml");
            this.ds.WriteXml("agendaconschema.xml", XmlWriteMode.WriteSchema);
        }
    }
}
