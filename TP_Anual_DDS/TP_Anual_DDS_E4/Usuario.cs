using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Usuario 
    {
        public string _Usuario { get; set; }
        public string Password { get; set; }
        public Interesado Interesado { get; set; }

        public int Id_Usuario
        {
            get
            {
                return (from x in new DDSDataContext().DBUsuario
                    where x.Nombre_Usuario.Contains(this._Usuario)
                    select x.Id_Usuario).SingleOrDefault();
            }
        }

        public Usuario(string nombreUsuario, string contrasena, Interesado interesado)
        {
            this._Usuario = nombreUsuario;
            this.Password = contrasena;
            this.Interesado = interesado;
        }

        public void Guardar()
        {
            DDSDataContext db = new DDSDataContext();
            db.Usuario_UI(_Usuario, Password, false);
            db.SubmitChanges();
            this.Interesado.Guardar(this.Id_Usuario);
        }
    }
}
