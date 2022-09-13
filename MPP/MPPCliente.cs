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

namespace MPP
{
    public class MPPCliente : IRepositorio<BECliente>
    {
        private string pathClientes = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Clientes.XML";

        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }
        public List<BECliente> Buscar(string Parametro)
        {
            try
            {
                BECliente clienteBuscar;
                List<BECliente> listaClienteDevolver = new List<BECliente>();

                XDocument documento = XDocument.Load(pathClientes);

                var consulta = from cliente in documento.Descendants("cliente")
                               where cliente.Element("nombre").Value.Contains(Parametro)
                               select cliente;

                foreach (XElement EModifcar in consulta)
                {
                    clienteBuscar = new BECliente();
                    clienteBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    clienteBuscar.nombre = EModifcar.Element("nombre").Value;
                    clienteBuscar.tipoDocumento = EModifcar.Element("tipoDocumento").Value;
                    clienteBuscar.documento = EModifcar.Element("documento").Value;
                    clienteBuscar.domicilio = EModifcar.Element("domicilio").Value;
                    clienteBuscar.telefono = EModifcar.Element("telefono").Value;
                    clienteBuscar.email = EModifcar.Element("email").Value;

                    listaClienteDevolver.Add(clienteBuscar);
                }
                return listaClienteDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool Crear(BECliente Parametro)
        {
            try
            {
                List<BECliente> cliente = Listar();
                int cantidadPart = cliente.Count();

                XDocument crear = XDocument.Load(pathClientes);
                crear.Element("clientes").Add(new XElement("cliente",
                                                new XAttribute("codigo", (cantidadPart + 1)),
                                                new XElement("nombre", Parametro.nombre),
                                                new XElement("tipoDocumento", Parametro.tipoDocumento),
                                                new XElement("documento", Parametro.documento),
                                                new XElement("domicilio", Parametro.domicilio),
                                                new XElement("telefono", Parametro.telefono),
                                                new XElement("email", Parametro.email)));

                if (VerificarDNI(Parametro.documento))
                {
                    if (VerificarExistencia(Parametro.email))
                    {
                        crear.Save(pathClientes);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool Eliminar(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(pathClientes);

                var consulta = from cliente in documento.Descendants("cliente")
                               where cliente.Attribute("codigo").Value == Parametro.ToString()
                               select cliente;
                consulta.Remove();

                documento.Save(pathClientes);
                return true;

            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public List<BECliente> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathClientes);

                List<BECliente> personas = new List<BECliente>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BECliente persona = new BECliente
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            nombre = Convert.ToString(item["nombre"]),
                            tipoDocumento = Convert.ToString(item["tipoDocumento"]),
                            documento = Convert.ToString(item["documento"]),
                            domicilio = Convert.ToString(item["domicilio"]),
                            telefono = Convert.ToString(item["telefono"]),
                            email = Convert.ToString(item["email"])
                        };
                        personas.Add(persona);
                    }
                }
                return personas;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<BECliente> ListarTodos()
        {
            throw new NotImplementedException();
        }
        public bool Modificar(BECliente Parametro, string emailAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(pathClientes);

                var consulta = from cliente in documento.Descendants("cliente")
                               where cliente.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select cliente;

                //Busca en el usuario por ID para luego comprobar si hay que cambiar el DNI
                BECliente personaXML = Listar().Find(x => x.documento == Parametro.documento);

                //Verifica si existe el DNI, si existe retona false, sino existe true.
                if (VerificarDNI(Parametro.documento))
                {
                    if (VerificarExistencia(emailAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("email").Value = Parametro.email;
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                            EModifcar.Element("documento").Value = Parametro.documento;
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathClientes);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                            EModifcar.Element("documento").Value = Parametro.documento;
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }

                        documento.Save(pathClientes);
                        return true;
                    }
                }
                else
                {
                    if (VerificarExistencia(emailAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("email").Value = Parametro.email;
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathClientes);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }

                        documento.Save(pathClientes);
                        return true;
                    }
                }
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        bool VerificarExistencia(string email)
        {
            bool resp = true;
            List<BECliente> cliente = Listar();

            if (cliente.Count() > 0)
            {
                foreach (BECliente item in cliente)
                {
                    if (item.email == email)
                    {
                        resp = false;
                        break;
                    }
                }
            }
            return resp;
        }
        bool VerificarDNI(string documento)
        {
            bool resp = true;
            List<BECliente> cliente = Listar();

            if (cliente.Count() > 0)
            {
                foreach (BECliente item in cliente)
                {
                    if (item.documento == documento)
                    {
                        resp = false;
                        break;
                    }
                }
            }
            return resp;
        }
    }
}
