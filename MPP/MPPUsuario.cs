﻿using System;
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
    public class MPPUsuario : IRepositorio<BEUsuario>
    {
        private string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Usuarios.XML";

        public bool Alta(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from usuario in documento.Descendants("usuario")
                               where usuario.Attribute("codigo").Value == Parametro.ToString()
                               select usuario;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("estado").Value = "1";
                }

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Baja(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from usuario in documento.Descendants("usuario")
                               where usuario.Attribute("codigo").Value == Parametro.ToString()
                               select usuario;

                foreach (XElement EModifcar in consulta)
                {
                    EModifcar.Element("estado").Value = "0";
                }

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public List<BEUsuario> Buscar(string Parametro)
        {
            try
            {
                BEUsuario usuarioBuscar;
                List<BEUsuario> listaUsuariosDevolver = new List<BEUsuario>();

                XDocument documento = XDocument.Load(path);

                var consulta = from producto in documento.Descendants("producto")
                               where producto.Element("nombre").Value.Contains(Parametro)
                               select producto;

                foreach (XElement EModifcar in consulta)
                {
                    usuarioBuscar = new BEUsuario();
                    usuarioBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    usuarioBuscar.codigoRol = Convert.ToInt32(EModifcar.Element("codigoRol").Value);
                    usuarioBuscar.nombre = EModifcar.Element("nombre").Value;
                    usuarioBuscar.tipoDocumento = EModifcar.Element("tipoDocumento").Value;
                    usuarioBuscar.documento = EModifcar.Element("documento").Value;
                    usuarioBuscar.telefono = EModifcar.Element("telefono").Value;
                    usuarioBuscar.email = EModifcar.Element("email").Value;
                    usuarioBuscar.clave = EModifcar.Element("clave").Value;
                    usuarioBuscar.estado = Convert.ToBoolean(EModifcar.Element("estado").Value);

                    listaUsuariosDevolver.Add(usuarioBuscar);
                }
                return listaUsuariosDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Crear(BEUsuario Parametro)
        {
            try
            {
                List<BEUsuario> usuarios = Listar();
                int cantidadPart = usuarios.Count();

                XDocument crear = XDocument.Load(path);
                crear.Element("usuarios").Add(new XElement("usuario",
                                                new XAttribute("codigo", (cantidadPart + 1)),
                                                new XElement("codigoRol", Parametro.codigoRol),
                                                new XElement("nombre", Parametro.nombre),
                                                new XElement("tipoDocumento", Parametro.tipoDocumento),
                                                new XElement("documento", Parametro.documento),
                                                new XElement("telefono", Parametro.telefono),
                                                new XElement("email", Parametro.email),
                                                new XElement("clave", Parametro.clave),
                                                new XElement("estado", 1)));

                if (VerificarExistencia(Parametro.email))
                {
                    crear.Save(path);
                    return true;
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
                XDocument documento = XDocument.Load(path);

                var consulta = from usuario in documento.Descendants("usuario")
                               where usuario.Attribute("codigo").Value == Parametro.ToString()
                               select usuario;
                consulta.Remove();

                documento.Save(path);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public List<BEUsuario> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BEUsuario> usuarios = new List<BEUsuario>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BEUsuario usuario = new BEUsuario
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                codigoRol = Convert.ToInt32(item["codigoRol"]),
                                nombre = Convert.ToString(item["nombre"]),
                                tipoDocumento = Convert.ToString(item["tipoDocumento"]),
                                documento = Convert.ToString(item["documento"]),
                                telefono = Convert.ToString(item["telefono"]),
                                email = Convert.ToString(item["email"]),
                                clave = Convert.ToString(item["clave"]),
                                estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                            };
                            usuarios.Add(usuario);
                        }

                    }
                }
                return usuarios;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public List<BEUsuario> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(path);

                List<BEUsuario> usuarios = new List<BEUsuario>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BEUsuario usuario = new BEUsuario
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            codigoRol = Convert.ToInt32(item["codigoRol"]),
                            nombre = Convert.ToString(item["nombre"]),
                            tipoDocumento = Convert.ToString(item["tipoDocumento"]),
                            documento = Convert.ToString(item["documento"]),
                            telefono = Convert.ToString(item["telefono"]),
                            email = Convert.ToString(item["email"]),
                            clave = Convert.ToString(item["clave"]),
                            estado = Convert.ToBoolean(Convert.ToInt32(item["estado"]))
                        };
                        usuarios.Add(usuario);
                    }
                }
                return usuarios;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public bool Modificar(BEUsuario Parametro, string emailAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(path);

                var consulta = from usuario in documento.Descendants("usuario")
                               where usuario.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select usuario;
                if (Parametro.email != emailAnterior)
                {
                    if (VerificarExistencia(emailAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("email").Value = Parametro.email;
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("codigoRol").Value = Convert.ToString(Parametro.codigoRol);
                            EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                            EModifcar.Element("documento").Value = Parametro.documento;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                            EModifcar.Element("clave").Value = Convert.ToString(Parametro.clave);
                        }
                        documento.Save(path);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    foreach (XElement EModifcar in consulta)
                    {
                        EModifcar.Element("nombre").Value = Parametro.nombre;
                        EModifcar.Element("codigoRol").Value = Convert.ToString(Parametro.codigoRol);
                        EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                        EModifcar.Element("documento").Value = Parametro.documento;
                        EModifcar.Element("telefono").Value = Parametro.telefono;
                        EModifcar.Element("clave").Value = Convert.ToString(Parametro.clave);
                    }

                    documento.Save(path);
                    return true;
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
            List<BEUsuario> usuarios = Listar();

            if (usuarios.Count() > 0)
            {
                foreach (BEUsuario item in usuarios)
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
    }
}