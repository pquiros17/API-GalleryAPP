using GalleryAPP.DS.Conexion;
using System;
using System.Text;
using MySql.Data.MySqlClient;
using GalleryAPP.DS.ConfiguracionDS;
using GalleryAPP.ET.DatosUsuario;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace GalleryAPP.DS.AccesoDatosUsuario
{
    public class DSRecuerdo
    {
        #region [Obtener Recuerdo]
        /// <summary>
        /// Método que permite obtener los recuerdos ingresados
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public  List<Recuerdo> ObtenerRecuerdo(Recuerdo pvoRecuerdo)
        {
            SqlConnection vloConexion = null;
            List<Recuerdo> ListaRecuerdo = new List<Recuerdo>();
            try
            {
                Recuerdo vloRecuerdo = null;

                using (vloConexion = DSConexion.ObtenerConexion())
                {
                    vloConexion.Open();

                    using (var vloComando = new SqlCommand())
                    {
                        vloComando.Connection = vloConexion;
                        vloComando.CommandType = System.Data.CommandType.StoredProcedure;
                        vloComando.CommandText = DSConfiguracion.ObtenerRecuerdo;
                        vloComando.Parameters.AddWithValue("@Id_Usuario", pvoRecuerdo.Id_Usuario);
                       

                        using (var vloLector = vloComando.ExecuteReader())
                        {
                            while (vloLector.Read())
                            {
                                vloRecuerdo = new Recuerdo();

                                vloRecuerdo.Id_Usuario = Convert.ToInt32(vloLector["Id_Usuario"]);
                                vloRecuerdo.Id_Recuerdo = Convert.ToInt32(vloLector["Id_Recuerdo"]);
                                vloRecuerdo.DescripcionRecuerdo = vloLector["DescripcionRecuerdo"].ToString();
                                vloRecuerdo.FechaRecuerdo = Convert.ToDateTime(vloLector["FechaRecuerdo"]);
                                
                                var vloBytesImagen = Convert.FromBase64String(vloLector["Foto"].ToString());
                                vloRecuerdo.Foto = vloBytesImagen;
                                vloBytesImagen = null;
                                ListaRecuerdo.Add(vloRecuerdo);
                            }

                        }
                    }

                    if (vloConexion.State == System.Data.ConnectionState.Open)
                        vloConexion.Close();
                }

                return ListaRecuerdo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (vloConexion.State == System.Data.ConnectionState.Open)
                    vloConexion.Close();
            }
        }
        #endregion

        #region [Registrar recuerdo]
        /// <summary>
        /// Método que permite registrar un recuerdo
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public  bool RegistrarRecuerdo(Recuerdo pvoRecuerdo)
        {
            SqlConnection vloConexion = null;
            try
            {
                bool vlbRegistroUsuario = false;

                using (vloConexion = DSConexion.ObtenerConexion())
                {
                    vloConexion.Open();
                    using (var vloComando = new SqlCommand())
                    {
                        vloComando.Connection = vloConexion;
                        vloComando.CommandType = System.Data.CommandType.StoredProcedure;
                        vloComando.CommandText = DSConfiguracion.RegistrarRecuerdo;
                        var foto = Convert.ToBase64String(pvoRecuerdo.Foto);
                        vloComando.Parameters.AddWithValue("@Id_Usuario", pvoRecuerdo.Id_Usuario);
                        vloComando.Parameters.AddWithValue("@Id_Recuerdo", pvoRecuerdo.Id_Recuerdo);
                        vloComando.Parameters.AddWithValue("@Descripcion", pvoRecuerdo.DescripcionRecuerdo);
                        vloComando.Parameters.AddWithValue("@FechaIngreso", pvoRecuerdo.FechaRecuerdo);
                        vloComando.Parameters.AddWithValue("@Foto",foto );
                       

                        vlbRegistroUsuario = vloComando.ExecuteNonQuery() > 0;
                    }

                    if (vloConexion.State == System.Data.ConnectionState.Open)
                        vloConexion.Close();
                }

                return vlbRegistroUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (vloConexion.State == System.Data.ConnectionState.Open)
                    vloConexion.Close();
            }
        }
        #endregion

        #region [Actualizar Recuerdo]
        /// <summary>
        /// Método que permite poder actualizar un recuerdo
        /// del usuario 
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public  bool ActualizarRecuerdo(Recuerdo pvoRecuerdo)
        {
            SqlConnection vloConexion = null;
            try
            {
                bool vlbRegistroUsuario = false;

                using (vloConexion = DSConexion.ObtenerConexion())
                {
                    vloConexion.Open();
                    using (var vloComando = new SqlCommand())
                    {
                        vloComando.Connection = vloConexion;
                        vloComando.CommandType = System.Data.CommandType.StoredProcedure;
                        vloComando.CommandText = DSConfiguracion.ActualizarRecuerdo;
                        vloComando.Parameters.AddWithValue("@Id_Usuario", pvoRecuerdo.Id_Usuario);
                        vloComando.Parameters.AddWithValue("@Id_Recuerdo", pvoRecuerdo.Id_Recuerdo);
                        vloComando.Parameters.AddWithValue("@Descripcion", pvoRecuerdo.DescripcionRecuerdo);
                        vloComando.Parameters.AddWithValue("@FechaIngreso", pvoRecuerdo.FechaRecuerdo);
                        var foto = Convert.ToBase64String(pvoRecuerdo.Foto);
                        vloComando.Parameters.AddWithValue("@Foto", foto);

                        vlbRegistroUsuario = vloComando.ExecuteNonQuery() > 0;
                    }

                    if (vloConexion.State == System.Data.ConnectionState.Open)
                        vloConexion.Close();
                }

                return vlbRegistroUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (vloConexion.State == System.Data.ConnectionState.Open)
                    vloConexion.Close();
            }
        }


        #endregion

        #region [Eliminar Recuerdo]
        /// <summary>
        /// Método que permite poder eliminar un recuerdo
        /// del usuario 
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public  bool EliminarRecuerdo(Recuerdo pvoRecuerdo)
        {
            SqlConnection vloConexion = null;
            try
            {
                bool vlbRegistroUsuario = false;

                using (vloConexion = DSConexion.ObtenerConexion())
                {
                    vloConexion.Open();
                    using (var vloComando = new SqlCommand())
                    {
                        vloComando.Connection = vloConexion;
                        vloComando.CommandType = System.Data.CommandType.StoredProcedure;
                        vloComando.CommandText = DSConfiguracion.EliminarRecuerdo;
                        vloComando.Parameters.AddWithValue("@Id_Usuario", pvoRecuerdo.Id_Usuario);
                        vloComando.Parameters.AddWithValue("@Id_Recuerdo", pvoRecuerdo.Id_Recuerdo);
                        

                        vlbRegistroUsuario = vloComando.ExecuteNonQuery() > 0;
                    }

                    if (vloConexion.State == System.Data.ConnectionState.Open)
                        vloConexion.Close();
                }

                return vlbRegistroUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (vloConexion.State == System.Data.ConnectionState.Open)
                    vloConexion.Close();
            }
        }


        #endregion
    }
}
