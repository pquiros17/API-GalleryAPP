using Restaurante.DS.Usuario;
using Restaurante.ET.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.BL.Usuario
{
    public class BLUsuario
    {
        #region [LoginUsuario]
        public ETUsuario LogearUsuario(ETUsuario pvoUsuario)
        {
            try
            {
                pvoUsuario = new ETUsuario { Contrasena = "1234", Correo = "a@a.com" };
                ETUsuario vloUsuario = null;
                if (!string.IsNullOrEmpty(pvoUsuario.Cedula))
                    pvoUsuario.Correo = pvoUsuario.Correo;
                vloUsuario = DSUsuario.LoginUsuario(pvoUsuario);
                return vloUsuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [Registrar Usuario]
        public bool RegistrarUsuario(ETUsuario pvoUsuario)
        {
            try
            {
                return DSUsuario.RegistrarUsuario(pvoUsuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
