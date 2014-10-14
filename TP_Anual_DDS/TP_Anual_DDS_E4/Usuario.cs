using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E4
{
    public class Usuario : Entidad
    {
        public string usuario { get; set; }
        public string contrasena { get; set; }
        public Interesado Interesado { get; set; }

        public int IdUsuario
        {
            get
            {
                string consulta = string.Format("SELECT Id_Usuario FROM " +
                    " Usuario WHERE Nombre_Usuario LIKE '{0}'", this.usuario);
                return (int)new BaseDatos(consulta).ObtenerUnicoCampo();
            }
        }

        public Usuario(string nombreUsuario, string contrasena, Interesado interesado)
        {
            this.usuario = nombreUsuario;
            this.contrasena = contrasena;
            this.Interesado = interesado;
            ActualizarYGuardar();
            this.Interesado.IdUsuario = this.IdUsuario;
        }

        
        public void Actualizar()
        {
            ActualizarYGuardar();
        }

        private void ActualizarYGuardar()
        {
            List<Parametro> parametros = new List<Parametro>()
            {
                new Parametro("@Nombre_Usuario", SqlDbType.NVarChar, usuario),
                new Parametro("@Password_Usuario", SqlDbType.NVarChar, contrasena),
                new Parametro("@Usuario_Administrador", SqlDbType.Bit, false),
            };

            base.Guardar("Usuario_UI", parametros);
            //guarda en la tabla de interesado también
            this.Interesado.Guardar(this.IdUsuario);
        }
    }
}
