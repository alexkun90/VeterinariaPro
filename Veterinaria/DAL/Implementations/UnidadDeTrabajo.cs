using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        public IMascotaDAL MascotaDAL { get; set; }
        public ICitasDAL CitasDAL { get; set; }

        public IDesparasitacionesVacunaDAL DesparasitacionesVacunaDAL { get; set; } 
      

        private VeterinariaProContext _veterinariaProContext;

        public UnidadDeTrabajo(VeterinariaProContext veterinariaProContext,
                        IMascotaDAL mascotaDAL,
                        ICitasDAL citasDAL,
                        IDesparasitacionesVacunaDAL desparasitacionesVacunaDAL
            ) 
        {
                this._veterinariaProContext = veterinariaProContext;
                this.MascotaDAL = mascotaDAL;
                this.CitasDAL = citasDAL;
            this.DesparasitacionesVacunaDAL = desparasitacionesVacunaDAL;
        }
       

        public bool Complete()
        {
            try
            {
                _veterinariaProContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }

        public void Dispose()
        {
            this._veterinariaProContext.Dispose();
        }
    }
}
