using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalleryAPP.ET.DatosUsuario
{
    public class Recuerdo
    {
        public int Id_Usuario { get; set; }

        public int Id_Recuerdo { get; set; }

        public string DescripcionRecuerdo { get; set; }

        public DateTime FechaRecuerdo { get; set; }

        public byte[] Foto { get; set; }

        
    }
}
