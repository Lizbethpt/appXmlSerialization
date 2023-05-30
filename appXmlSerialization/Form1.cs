using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace appXmlSerialization
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SerializeDataSet("datos.xml");
            SerializeArticulo("articulos.xml");
        }
        private void SerializeArticulo(string filename)
        {
            XmlSerializer seri = new XmlSerializer(typeof(Articulo));
            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet ds = new DataSet("myDataSet1");
            DataTable t = new DataTable("Articulos");
            DataColumn nombre = new DataColumn("Nombre", typeof(string));
            DataColumn precio = new DataColumn("Precio", typeof(decimal));
            t.Columns.Add(nombre);
            t.Columns.Add(precio);
            for (int i = 0; i < 10; i++)
            {
                DataRow r = t.NewRow();
                r["Nombre"] = "Articulo " + i;
                r["Precio"] = i * 10m;
                t.Rows.Add(r);
            }
            TextWriter writer = new StreamWriter(filename);
            seri.Serialize(writer, ds);
            writer.Close();
        }
        private void SerializeDataSet(string filename)
        {
            XmlSerializer ser = new XmlSerializer(typeof(DataSet));

            // Creates a DataSet; adds a table, column, and ten rows.
            DataSet ds = new DataSet("myDataSet");
            DataTable t = new DataTable("table1");
            DataColumn c = new DataColumn("thing");
            t.Columns.Add(c);
            ds.Tables.Add(t);
            DataRow r;

            for (int i = 0; i < 10; i++)
            {
                r = t.NewRow();
                r[0] = "Thing " + i;
                t.Rows.Add(r);
            }

            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, ds);
            writer.Close();
        }
        
    }
}
