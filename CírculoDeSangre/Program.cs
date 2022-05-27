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
            int x = 1;
            int z = 0;
            int opcion;
            bool valid = false;
            
            Console.WriteLine("BIENVENIDO AL CÍRCULO DE SANGRE\n");
            
            //MENÚ PRINCIPAL CON VALIDACIÓN DE OPCIONES
            do
            {
                do
                {
                    Console.WriteLine("-Para registrarse, presione 1\n-Para ingresar, presione 2\n-Para ver el reglamento y condiciones, presione 3\n");
                    opcion = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    if (opcion == 1 || opcion == 2 || opcion == 3)
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
                    case 1:
                        if (socio.ValidarGrupoSanguineo() == '-')
                        {
                            socio.CargaDatos();
                            if (socio.Registro == "si" || socio.Registro == "Si")
                            {
                                socio.RegistrarSocio(z);
                                z++;
                            }
                        }
                        socio.Retorno(x);
                        break;
                    case 2:
                        socio.InicioSesion(z);
                        socio.Retorno(x);
                        break;
                    case 3:
                        Console.WriteLine(socio.Reglamento());
                        socio.Retorno(x);
                        break;
                }
            } while (x != 0);
        }
    }
}