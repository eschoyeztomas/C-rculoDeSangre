using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    class Program
    {
        static void Main(string[] args)
        {
            Socio socio = new Socio();
            socio.SociosRegistrados();

            Menu menu = new Menu();

            Peticion peticion = new Peticion();

            Donacion donacion = new Donacion();

            BancoDeSangre bds = new BancoDeSangre();
            bds.BancosDeSangreYaRegistrados();

            SocioAsignado sa = new SocioAsignado();

            menu.IniciarApp(socio, socio.ListaDeSocios, bds, peticion, donacion, peticion.ListaDePeticiones, sa);
        }
    }
}