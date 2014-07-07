﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_Anual_DDS
{
    public class CondicionLugar : ICondiciones
    {
        private string lugar;

        public CondicionLugar()
        {
            EstablecerCondicion();
        }

        public void EstablecerCondicion()
        {
            lugar = "Caballito";
        }

        public bool EvaluarCondicion(Partido partido)
        {
            return partido.Lugar == lugar;
        }
    }
}
