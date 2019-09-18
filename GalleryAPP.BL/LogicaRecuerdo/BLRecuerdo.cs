
using GalleryAPP.DS.AccesoDatosUsuario;
using GalleryAPP.ET.DatosUsuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAPP.BL.LogicaRecuerdo
{
    public class BLRecuerdo
    {
        DSRecuerdo Recuerdo = null;

        public BLRecuerdo()
        {
            Recuerdo = new DSRecuerdo();
        }

        #region [Obtener Recuerdos]
        /// <summary>
        /// Método para obtener recuerdos
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns>Recuerdos</returns>
        public List<Recuerdo> ObtenerRecuerdo(Recuerdo pvoRecuerdo)
        {
            try
            {
                var vloListaRecuerdo = Recuerdo.ObtenerRecuerdo(pvoRecuerdo);

                return vloListaRecuerdo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [Registrar Recuerdo]
        /// <summary>
        /// Método que permite registrar un recuerdo
        /// de la aplicación
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public bool RegistrarRecuerdo(Recuerdo pvoRecuerdo)
        {
            try
            {
                bool vlbRegistrado = false;


                
                    vlbRegistrado = Recuerdo.RegistrarRecuerdo(pvoRecuerdo);
                

                return vlbRegistrado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [Actualizar Recuerdo]
        public bool ActualizarRecuerdo(Recuerdo pvoRecuerdo)
        {
            try
            {
                bool Actualizo = false;

                Actualizo = Recuerdo.ActualizarRecuerdo(pvoRecuerdo);

                return Actualizo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [Eliminar Recuerdo]
        public bool EliminarRecuerdo(Recuerdo pvoRecuerdo)
        {
            try
            {
                bool Elimino = false;

                Elimino = Recuerdo.EliminarRecuerdo(pvoRecuerdo);

                return Elimino;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
