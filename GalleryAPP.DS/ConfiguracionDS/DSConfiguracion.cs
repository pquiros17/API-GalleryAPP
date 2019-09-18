using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAPP.DS.ConfiguracionDS
{
    public class DSConfiguracion
    {
        #region [Conexión]
        public static readonly string vccStringConexion = ConfigurationManager.AppSettings["ConexBD"];
        #endregion

        #region [SP Usuario]
        public static string RegistrarRecuerdo { get { return "SP_RegistrarRecuerdo";  } }

        public static string ObtenerRecuerdo { get { return "SP_ObtenerRecuerdo"; } }

        public static string ActualizarRecuerdo { get { return "SP_ActualizarRecuerdo"; } }

        public static string EliminarRecuerdo { get { return "SP_EliminarRecuerdo"; } }
        #endregion

        #region [Restuarante]
        public static string ObtenerRestaurantes { get { return "SP_ObtenerRestaurante"; } }

        public static string ObtenerMenuXRestaurante { get { return "SP_ObtenerMenuRestaurante"; } }
        #endregion
    }
}
