using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    public class BancoDeSangre
    {
        private string nombre;
        private string ubicacion;
        private string bdsEmail;
        private string bdsContraseña;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Ubicacion { get => ubicacion; set => ubicacion = value; }
        public string BdsEmail { get => bdsEmail; set => bdsEmail = value; }
        public string BdsContraseña { get => bdsContraseña; set => bdsContraseña = value; }

        private List<BancoDeSangre> listaDeBds = new List<BancoDeSangre>();
        public List<BancoDeSangre> ListaDeBds { get => listaDeBds; set => listaDeBds = value; }

        public void DatosBds()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Ubicacion: " + Ubicacion);
            Console.WriteLine("Email: " + BdsEmail + "\tContraseña: " + BdsContraseña);
        }
        public void BancosDeSangreYaRegistrados()
        {
            ListaDeBds.Add(new BancoDeSangre()
            {
                Nombre = "Instituto de Hematologia y Hemoterapia",
                Ubicacion = "Enf. Gordillo Gomez",
                BdsEmail = "ihh@bancodesangre.com.ar",
                BdsContraseña = "ihh123"
            });
            ListaDeBds.Add(new BancoDeSangre()
            {
                Nombre = "Hospital Garrahan",
                Ubicacion = "Combate de los Pozos 1881",
                BdsEmail = "fundaciogarrahan@bancodesangre.com.ar",
                BdsContraseña = "fg123"
            });
        }
        public void MostrarListaDeBancos()
        {
            foreach (var item in ListaDeBds)
            {
                item.DatosBds();
            }
        }
        public void IniciarSesionBds(Peticion peticion, SocioAsignado sa, Donacion donacion, List<Socio> ListaDeSocios, List<Peticion> ListaDePeticiones)
        {
            string isEmail;
            Console.Clear();
            bool emailExiste, usuarioExistente, contraCorrecta;
            do
            {
                emailExiste = true;
                usuarioExistente = false;
                Console.Write("Ingrese su email: ");
                isEmail = Console.ReadLine();
                foreach (BancoDeSangre item in ListaDeBds)
                {
                    if (isEmail == item.BdsEmail)
                    {
                        do
                        {
                            contraCorrecta = true;
                            Console.Write("Ingrese su contraseña: ");
                            string isContraseña = Console.ReadLine();
                            if (isContraseña == item.BdsContraseña)
                            {
                                Console.Clear();
                                Console.WriteLine("Banco logueado correctamente.\n");
                                usuarioExistente = true;
                            }
                            else
                            {
                                Console.WriteLine("\nContraseña incorrecta.\n");
                                contraCorrecta = false;
                            }
                        } while (contraCorrecta == false);
                    }
                    else
                    {
                        emailExiste = false;
                    }
                }
                if (usuarioExistente == true)
                {
                    contraCorrecta = true;
                    emailExiste = true;
                }
                else if (emailExiste == false)
                {
                    Console.Clear();
                    Console.WriteLine("Banco Inexistente\n");
                }
            } while (emailExiste == false);
            bool volver = false;
            do
            {
                Console.WriteLine("1_ Para registrar una peticion");
                Console.WriteLine("2_ Para registrar una donacion");
                Console.WriteLine("3_ Para ver los socios asignados para donar");
                Console.WriteLine("0_ Para salir");
                Console.WriteLine("Ingrese una opción: ");
                string o = Console.ReadLine();
                if (o == "0")
                {
                    volver = false;
                }
                else if (o == "1")
                {
                    Console.Clear();
                    peticion.RegistrarPeticion(sa, ListaDeSocios, ListaDePeticiones, peticion);
                    volver = true;
                }
                else if (o == "2")
                {
                    Console.Clear();
                    donacion.RegistrarDonacion();
                    volver = true;
                }
                else if (o == "3")
                {
                    Console.Clear();
                    sa.MostrarSociosAsignados();
                    volver = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("La opcion ingresa no es valida.\n");
                    volver = true;
                }
            } while (volver == true);
            Console.Clear();
        }
    }
}