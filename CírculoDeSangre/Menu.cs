using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    public class Menu
    {
        public void IniciarApp(Socio socio, List<Socio> ListaDeSocios, BancoDeSangre bds, Peticion peticion, Donacion donacion, List<Peticion> ListaDePeticiones, SocioAsignado sa)
        {
            int codAdmin = 1111;
            int codAdmin1;
            int x = 1;
            int t;
            int opcion;
            bool valid = false;

            Console.WriteLine("BIENVENIDO AL CÍRCULO DE SANGRE\n");

            //MENÚ PRINCIPAL CON VALIDACIÓN DE OPCIONES
            do
            {
                do
                {
                    Console.WriteLine("-Para registrarse, presione 1\n-Para ingresar, presione 2\n-Para ver el reglamento y condiciones, presione 3\n-Ingresar como Banco de Sangre, presione 4\n-Ingresar como administrador, presione 5\n\n-Para finalizar, presione 0\n");
                    opcion = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    if (opcion == 0 || opcion == 1 || opcion == 2 || opcion == 3 || opcion == 4 || opcion == 5)
                    {
                        valid = true;
                    }
                    else
                    {
                        Console.WriteLine("Opción incorrecta, vuelve a intentarlo\n");
                    }
                } while (valid == false);
                switch (opcion)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        if (socio.ValidarGrupoSanguineo() == '-')
                        {
                            socio.CargaDatos();
                            if (socio.Registro == "si" || socio.Registro == "Si")
                            {
                                socio.RegistrarSocio();
                            }
                        }
                        x = socio.RetornoMenu(x);
                        break;
                    case 2:
                        socio.InicioSesion(x);
                        if (x != 1)
                        {
                            x = socio.RetornoMenu(x);
                        }
                        break;
                    case 3:
                        Console.WriteLine(socio.Reglamento());
                        x = socio.RetornoMenu(x);
                        break;
                    case 4:
                        bds.IniciarSesionBds(peticion, sa, donacion, ListaDeSocios, ListaDePeticiones);
                        break;
                    case 5:
                        do
                        {
                            Console.WriteLine("Ingrese el código de seguridad: ");
                            codAdmin1 = Convert.ToInt16(Console.ReadLine());
                        } while (codAdmin1 != codAdmin);
                        Console.WriteLine("\nPara ver los datos de los socios, presione 1\n");
                        t = Convert.ToInt16(Console.ReadLine());
                        if (t == 1)
                        {
                           Console.Clear();
                           socio.VerDatos();
                           x = socio.RetornoMenu(x);
                        }
                        break;
                }
            } while (x != 0);
        }
    }
}
