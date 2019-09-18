using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Restaurante.DS.Conexion;
using Restaurante.ET.Usuario;
using Restaurante.DS.ConfiguracionDS;
namespace Restaurante.DS.Usuario
{
    public class DSUsuario
    {
        #region [Registrar Usuario]
        public static bool RegistrarUsuario(ETUsuario pvoUsuario)
        {
            try
            {
                bool vlbRegistro = false;
                using (var vloConexion = DSConexion.ObtenerConexion())
                {
                    vloConexion.Open();
                    using (var vloInsertar = new MySqlCommand(DSConfiguracion.RegistrarUsuario))
                    {
                        vloInsertar.Connection = vloConexion;
                        vloInsertar.CommandType = System.Data.CommandType.StoredProcedure;
                        vloInsertar.Parameters.AddWithValue("@Cedula", pvoUsuario.Cedula);
                        vloInsertar.Parameters.AddWithValue("@Nombre", pvoUsuario.Nombre);
                        vloInsertar.Parameters.AddWithValue("@Apellido", pvoUsuario.Apellido);
                        vloInsertar.Parameters.AddWithValue("@Apellido2", pvoUsuario.Apellido2);
                        vloInsertar.Parameters.AddWithValue("@Correo", pvoUsuario.Correo);
                        vloInsertar.Parameters.AddWithValue("@CodigoArea", pvoUsuario.CodigoArea);
                        vloInsertar.Parameters.AddWithValue("@Telefono", pvoUsuario.Telefono);
                        vloInsertar.Parameters.AddWithValue("@Nacimiento", pvoUsuario.FechaNacimiento);
                        vloInsertar.Parameters.AddWithValue("@Contrasena", pvoUsuario.Contrasena);
                        vlbRegistro = vloInsertar.ExecuteNonQuery() > 0;
                    }
                    if (vloConexion.State == System.Data.ConnectionState.Open)
                        vloConexion.Close();
                }
                return vlbRegistro;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [Login Usuario]
        public static ETUsuario LoginUsuario(ETUsuario pvoUsuario)
        {
            try
            {
                ETUsuario vloUsuario = null;
                using (var vloConexion = DSConexion.ObtenerConexion())
                {
                    vloConexion.Open();
                    using (var vloComando = new MySqlCommand(DSConfiguracion.LoginUsuario))
                    {
                        vloComando.Connection = vloConexion;
                        vloComando.CommandType = System.Data.CommandType.StoredProcedure;
                        vloComando.Parameters.AddWithValue("@Correo", pvoUsuario.Correo);
                        vloComando.Parameters.AddWithValue("@Contrasena", pvoUsuario.Contrasena);
                        using (var vloLector = vloComando.ExecuteReader())
                        {
                            if (vloLector.Read())
                            {
                                vloUsuario = new ETUsuario();
                                vloUsuario.Cedula = vloLector["Cedula"].ToString();
                                vloUsuario.Nombre = vloLector["Nombre"].ToString();
                                vloUsuario.Apellido = vloLector["Apellido"].ToString();
                                vloUsuario.Apellido2 = vloLector["Apellido2"].ToString();
                                vloUsuario.Correo = vloLector["Correo"].ToString();
                                vloUsuario.FechaNacimiento = Convert.ToDateTime(vloLector["Nacimiento"].ToString());
                                //vloUsuario.Telefono = Convert.ToInt32(vloLector["Telefono"].ToString());
                            }
                            if (!vloLector.IsClosed)
                                vloLector.Close();
                        }
                    }
                    if (vloConexion.State == System.Data.ConnectionState.Open)
                        vloConexion.Close();
                }
                return vloUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
