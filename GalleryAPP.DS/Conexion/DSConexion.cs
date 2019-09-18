using System;
using GalleryAPP.DS.ConfiguracionDS;
using System.Data.SqlClient;

namespace GalleryAPP.DS.Conexion
{
    public class DSConexion
    {
        #region [Obtener Conexión MySql]
        public static SqlConnection ObtenerConexion()
        {
            try
            {
                return new SqlConnection(DSConfiguracion.vccStringConexion);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
