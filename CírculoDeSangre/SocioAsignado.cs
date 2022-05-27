using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    public class SocioAsignado
    {
        private string tDni;
        private string tNombre;
        private string tApellido;

        private List<SocioAsignado> sociosAsignados = new List<SocioAsignado>();
        public List<SocioAsignado> SociosAsignados { get => sociosAsignados; set => sociosAsignados = value; }
        public string TNombre { get => tNombre; set => tNombre = value; }
        public string TApellido { get => tApellido; set => tApellido = value; }
        public string TDni { get => tDni; set => tDni = value; }

        public void DatoSocioAsignado()
        {
            Console.WriteLine("DNI: " + TDni + "\n" + TNombre + " " + TApellido);
        }
        string gs;
        public void AsignarSocios(List<Socio> ListaDeSocios, List<Peticion> ListaDePeticiones, Peticion peticion)
        {
            gs = peticion.GrupoS + peticion.FactorS;

            foreach (var item in ListaDeSocios)
            {
                if (item.GrupoSanguineo == gs && item.Condicion == "Disponible")
                {
                    SociosAsignados.Add(new SocioAsignado()
                    {
                        TDni = item.Dni,
                        TNombre = item.Nombre,
                        TApellido = item.Apellido
                    });
                }
            }
        }
        public void MostrarSociosAsignados()
        {
            foreach (var item in SociosAsignados)
            {
                item.DatoSocioAsignado();
            }
        }
    }
}