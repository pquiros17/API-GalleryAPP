using GalleryAPP.BL.LogicaRecuerdo;
using GalleryAPP.ET.DatosUsuario;
using System;
using System.Web.Http;

namespace GalleryAPP.API.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("api/Recuerdo")]
    public class RecuerdoController : ApiController
    {
        private BLRecuerdo vcoRecuerdo; 


        public RecuerdoController()
        {
            vcoRecuerdo = new BLRecuerdo();
        }


        #region [Obtener Recuerdo]
        /// <summary>
        /// Api Action para obtener recuerdos
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public IHttpActionResult ObtenerRecuerdo([FromBody]Recuerdo pvoRecuerdo)
        {
            try
            {
                var vloRecuerdos = vcoRecuerdo.ObtenerRecuerdo(pvoRecuerdo);

                return Ok(vloRecuerdos);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
        #endregion

        #region [Registrar Recuerdo]
        /// <summary>
        /// Método para realizar el registro de un recuerdo
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public IHttpActionResult RegistrarRecuerdo([FromBody]Recuerdo pvoRecuerdo)
        {
            try
            {
                bool vlbRegistrado = false;

                vlbRegistrado = vcoRecuerdo.RegistrarRecuerdo(pvoRecuerdo);

                return Ok(vlbRegistrado);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
        #endregion

        #region [Actualizar Recuerdo]
        /// <summary>
        /// Método API que permite actualizar la información de un recuerdo
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public IHttpActionResult ActualizarRecuerdo([FromBody]Recuerdo pvoRecuerdo)
        {
            try
            {
                bool vlbActualizo = false;

                vlbActualizo = vcoRecuerdo.ActualizarRecuerdo(pvoRecuerdo);

                return Ok(vlbActualizo);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
                throw;
            }
        }
        #endregion


        #region [Eliminar Recuerdo]
        /// <summary>
        /// Método API que permite eliminar la información de un recuerdo
        /// </summary>
        /// <param name="pvoRecuerdo"></param>
        /// <returns></returns>
        public IHttpActionResult EliminarRecuerdo([FromBody]Recuerdo pvoRecuerdo)
        {
            try
            {
                bool vlbEliminado = false;

                vlbEliminado = vcoRecuerdo.EliminarRecuerdo(pvoRecuerdo);

                return Ok(vlbEliminado);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
                throw;
            }
        }
        #endregion
    }
}
