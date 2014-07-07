using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS_E2
{
    public class Partido
    {
        #region Propiedades
        public DateTime fechaHora { get; set; }
        public string lugar { get; set; }
        public List<Interesado> listaInteresados {get;set;}
        private List<Interesado> listaInfractores { get; set; }
        #endregion

        public Interesado Interesado
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        #region Constructores

        public Partido() { }
        public Partido(string lugar, DateTime fechaHora) 
        {
            this.listaInteresados = new List<Interesado>();
            this.listaInfractores = new List<Interesado>();
            this.fechaHora = fechaHora;
            this.lugar = lugar;
        }
        #endregion

        #region Métodos públicos

        public bool AgregarInteresado(Interesado interesado) 
        {
            if (interesado.Tipo.PuedoJugarEn(this))
            {
                if (listaInteresados.Count < 10)
                {
                    listaInteresados.Add(interesado);
                    interesado.EstasIncriptoEn(this);
                    if (listaInteresados.Count == 10)
                        Console.WriteLine("La lista está completa.");
                }
                else
                {
                    if (interesado.Tipo.Prioridad == Interesado.EnumPrioridad.Solidario)//Si quiere ingresar un solidario
                    {
                        BuscarYEliminar(interesado, Interesado.EnumPrioridad.Condicional);//Busca si hay condicional y los cambia.
                    }
                    if (interesado.Tipo.Prioridad == Interesado.EnumPrioridad.Estandar)//Si quiere ingresar un estandar
                    {
                        //Si hay un condicional, lo saca. Si no, busca si hay un solidario para sacarlo.
                        if(!BuscarYEliminar(interesado, Interesado.EnumPrioridad.Condicional))//Busca si hay condicional.
                            BuscarYEliminar(interesado, Interesado.EnumPrioridad.Solidario);//Busca si hay solidario.
                    }
                }
                ChequearCondicionales();
            }
            return true;
        }

        public void DarBaja(Interesado interesadoBaja) 
        {
            this.listaInteresados.Remove(interesadoBaja);
            this.listaInfractores.Add(interesadoBaja);//Se agrega a una lista de infractores.
        }

        public void DarBaja(Interesado interesadoBaja, Interesado interesadoAlta)
        {
            this.listaInteresados.Remove(interesadoBaja);
            this.listaInteresados.Add(interesadoAlta);
        }
        #endregion

        #region Métodos privados

        private void ChequearCondicionales() 
        {
            foreach (Interesado interes in this.listaInteresados)
            {
                if (!interes.Tipo.PuedoJugarEn(this))
                {
                    this.listaInteresados.Remove(interes);
                    Console.WriteLine("Fue sacado de la lista: " + interes.Nombre + " por dejar de cumplir sus condiciones.");
                }
            }
        }
        /// <summary>
        /// Busca en la lista de interesados inscriptos los que tienen menor prioridad y los vuela.
        /// </summary>
        /// <param name="interesadoAIngresar"></param>
        /// <param name="prioridadDeIngresanteAVolar">Busca interesados segun esto</param>
        private bool BuscarYEliminar(Interesado interesadoAIngresar, Interesado.EnumPrioridad prioridadDeIngresanteAVolar) 
        {
            foreach (Interesado interes in this.listaInteresados)
            {
                if (interes.Tipo.Prioridad == prioridadDeIngresanteAVolar)
                {
                    listaInteresados.Remove(interes);
                    listaInteresados.Add(interesadoAIngresar);
                    interesadoAIngresar.EstasIncriptoEn(this);
                    if (listaInteresados.Count == 10)
                        Console.WriteLine("La lista está completa.");
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
