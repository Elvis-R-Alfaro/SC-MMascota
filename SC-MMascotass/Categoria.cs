﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SC_MMascotass
{
    class Categoria
    {
        static public List<string> GetData()
        {
            List<string> data = new List<string>();

            data.Add("Comida para perros");
            data.Add("Comida para Gatos");
            data.Add("Juguetes");
            data.Add("Jarabes");
            data.Add("Pastillas");
            data.Add("Vitaminas");
            data.Add("Correas");
            data.Add("Camas");
            data.Add("Vacunas");
            data.Add("En latados");
            data.Add("Tazones");
            data.Add("Servicio");

            return data;
        }
    }
}
