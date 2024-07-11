using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class CitasDALImpl : DALGenericoImpl<Cita>, ICitasDAL
    {
        private VeterinariaProContext context;
        public CitasDALImpl(VeterinariaProContext context) : base(context)
        {
            this.context = context;
        }
    }
}
