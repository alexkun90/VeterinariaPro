﻿using FrontEnd.ApiMoldels;

namespace FrontEnd.ApiModels
{
    public class DesparasitacionesVacuna
    {
        public int CodigoDesparasitacionVacuna { get; set; }

        public string? Tipo { get; set; }

        public DateOnly? Fecha { get; set; }

        public string? Producto { get; set; }

        public int? MascotaId { get; set; }

        public virtual Mascota? Mascota { get; set; }

    }
}
