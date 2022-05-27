using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    public class Peticion
    {
        private DateTime fechaInicio;
        private DateTime fechaLimite;
        private int cantDonantes;
        private string grupoS;
        private string factorS;
        private bool t;

        public DateTime FechaInicio { get => fechaInicio; set => fechaInicio = value; }
        public DateTime FechaLimite { get => fechaLimite; set => fechaLimite = value; }
        public int CantDonantes { get => cantDonantes; set => cantDonantes = value; }
        public string GrupoS { get => grupoS; set => grupoS = value; }
        public string FactorS { get => factorS; set => factorS = value; }

        private List<Peticion> listaDePeticiones = new List<Peticion>();
        public List<Peticion> ListaDePeticiones { get => listaDePeticiones; set => listaDePeticiones = value; }

        public void DatosDePeticion()
        {
            Console.WriteLine("Fecha: " + FechaInicio + "\t" + "Fecha limite: " + FechaLimite);
            Console.WriteLine("Grupo: " + GrupoS + "\t" + "Factor: " + FactorS);
            Console.WriteLine("Se necesitan " + CantDonantes + " Donantes");
        }
        public void RegistrarPeticion(SocioAsignado sa, List<Socio> ListaDeSocios, List<Peticion> ListaDePeticiones, Peticion peticion)
        {
            try
            {
                Console.Write("Ingrese la fecha **/**/**** : ");
                fechaInicio = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Formato incorrecto");
            }
            try
            {
                Console.Write("Ingrese la fecha limite **/**/**** : ");
                fechaLimite = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Formato incorrectoi");
            }
            try
            {
                Console.Write("Ingrese la cantidad de donantes: ");
                cantDonantes = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Formato incorrecto");
            }
            do
            {
                t = false;
                Console.Write("Ingrese el grupo sanguineo: ");
                grupoS = Console.ReadLine();
                switch (grupoS)
                {
                    case "a":
                        break;
                    case "A":
                        break;
                    case "b":
                        break;
                    case "B":
                        break;
                    case "ab":
                        break;
                    case "AB":
                        break;
                    case "Ab":
                        break;
                    case "0":
                        break;
                    default:
                        Console.WriteLine("ERROR: El grupo sanguineo ingresado no existe, vuelve a intentarlo\n");
                        t = true;
                        break;
                }
            } while (t == true);
            do
            {
                t = false;
                Console.Write("Ingrese el factor RH\n[+ | -]: ");
                factorS = Console.ReadLine();
                switch (factorS)
                {
                    case "+":
                        Console.WriteLine("El círculo de sangre posee solo factor RH negativo");
                        break;
                    case "-":
                        Console.Clear();
                        Console.WriteLine("Petición registrada");
                        break;
                    default:
                        Console.WriteLine("ERROR: El factor RH ingresado no existe, vuelve a intentarlo\n");
                        t = true;
                        break;
                }
            } while (t == true);
            CargarPeticion();
            sa.AsignarSocios(ListaDeSocios, ListaDePeticiones, peticion);

            CargarPeticion();
            sa.AsignarSocios(ListaDeSocios, ListaDePeticiones, peticion);
        }
        public void CargarPeticion()
        {
            ListaDePeticiones.Add(new Peticion()
            {
                FechaInicio = fechaInicio,
                FechaLimite = fechaLimite,
                CantDonantes = cantDonantes,
                GrupoS = grupoS,
                FactorS = factorS
            });
        }
        public void MostrarPeticiones()
        {
            foreach (var item in ListaDePeticiones)
            {
                item.DatosDePeticion();
                Console.WriteLine();
            }
        }
    }
}