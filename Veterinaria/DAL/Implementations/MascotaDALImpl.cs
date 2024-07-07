using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class MascotaDALImpl : DALGenericoImpl<Mascota>, IMascotaDAL
    {
        private VeterinariaProContext context;
        public MascotaDALImpl(VeterinariaProContext context) : base(context)
        {
            this.context = context;   
        }
    }
}
