using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Reflection;
using Microsoft.VisualBasic.Devices;

namespace MPP
{
    public class MPPBackUp
    {
        Computer thisComputer = new Computer();
        private string pathBack = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\listadoBackUp" + "\\ListadoBackUp.XML";
        private string directorioDestino = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml";
        private string directorioOrigen = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\backUps";
        public List<BEBackup> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathBack);

                List<BEBackup> listaBack = new List<BEBackup>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                            BEBackup backup = new BEBackup
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                nombreUsuario = Convert.ToString(item["nombreusuario"]),
                                codigoUsuario = Convert.ToInt32(item["codigousuario"]),
                                fecha = Convert.ToDateTime(item["fecha"])
                            };
                        listaBack.Add(backup);
                    }
                }
                return listaBack;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public bool Crear(BEBackup Parametro)
        {
            try
            {
                List<BEBackup> backup = Listar();
                int cantidad = backup.Count();

                XDocument crear = XDocument.Load(pathBack);
                crear.Element("backs").Add(new XElement("back",
                                                new XAttribute("codigo", (cantidad+1)),
                                                new XElement("nombreusuario", Parametro.nombreUsuario),
                                                new XElement("codigousuario", Parametro.codigoUsuario),
                                                new XElement("fecha", Parametro.fecha)));
                crear.Save(pathBack);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool Restore(int codigoBack)
        {
            try
            {
                string directorio = "\\" + codigoBack.ToString();
                //elimino los archivos del directorio para eliminarlo
                string[] files = Directory.GetFiles(directorioDestino);
                foreach (string file in files)
                {
                    File.Delete(file);
                }
                //Elimino el directorio
                Directory.Delete(directorioDestino);
                //Creo un nuevo directorio
                thisComputer.FileSystem.CreateDirectory(directorioDestino);
                //Si el directorio existe copia el directorio con el código que se quiere hacer el restore.
                if (Directory.Exists(directorioDestino))
                {
                    thisComputer.FileSystem.CopyDirectory(String.Concat(directorioOrigen, directorio), directorioDestino);
                    return true;
                }
                return false;
            }
            catch (ArgumentException ex)
            {
                throw ex;
            }

        }
    }
}
