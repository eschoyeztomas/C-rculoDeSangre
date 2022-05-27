using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    public class Socio
    {
        private string[,] listaSocios = new string[100, 14];

        //DECLARACION DE VARIABLES
        private string nombre;
        private string apellido;
        private string grupoSanguineo;
        private int DNI;
        private DateTime fechaNacimiento;
        private string domicilio;
        private string localidad;
        private string email;
        private string categoria;
        private string enfermedad;
        private char factorRH;
        private string contraseña;
        private string medicamento;
        private string medicacion;
        private string registro;
        private int metodoPago;

        //ENCAPSULAMIENTO DE VARIABLES
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Enfermedad { get => enfermedad; set => enfermedad = value; }
        public int DNI1 { get => DNI; set => DNI = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public char FactorRH { get => factorRH; set => factorRH = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string[,] ListaSocios { get => listaSocios; set => listaSocios = value; }
        public string Medicamento { get => medicamento; set => medicamento = value; }
        public string Medicacion { get => medicacion; set => medicacion = value; }
        public string Registro { get => registro; set => registro = value; }
        public int MetodoPago { get => metodoPago; set => metodoPago = value; }

        public char ValidarGrupoSanguineo()
        {
            bool error = false;
            string msgRechazar = "\nSu RH es positivo, por lo tanto no podrá ingresar al Círculo\n";
            string msgAceptar = "\nSu grupo sanguíneo es aceptado\n";
            //VALIDACIÓN DEL GRUPO SANGUÍNEO Y RH NEGATIVO
            do
            {
                error = false;
                Console.Write("Ingrese su grupo sanguineo: ");
                GrupoSanguineo = (Console.ReadLine());
                switch (GrupoSanguineo)
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
                    case "0":
                        break;
                    default:
                        Console.WriteLine("ERROR: El grupo sanguineo ingresado no existe, vuelve a intentarlo\n");
                        error = true;
                        break;
                }
            } while (error == true);
            do
            {
                error = false;
                Console.Write("Ingrese su factor RH\n[+ | -]: ");
                FactorRH = Convert.ToChar(Console.ReadLine());
                switch (FactorRH)
                {
                    case '+':
                        Console.WriteLine(msgRechazar);

                        break;
                    case '-':
                        Console.WriteLine(msgAceptar);
                        break;
                    default:
                        Console.WriteLine("ERROR: El factor RH ingresado no existe, vuelve a intentarlo\n");
                        error = true;
                        break;
                }
            } while (error == true);
            Console.Write("Presione cualquier tecla para continuar ");
            Console.ReadKey();
            Console.Clear();
            return factorRH;
        }
        public void CargaDatos()
        {
            //INGRESO DE DATOS PERSONALES
            Console.Write("Ingrese su nombre: ");
            Nombre = Console.ReadLine();
            Console.Write("Ingrese su apellido: ");
            Apellido = Console.ReadLine();
            Console.Write("Ingrese su número de DNI: ");
            DNI1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese su fecha de nacimiento **/**/**** : ");
            FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Ingrese su domicilio: ");
            Domicilio = Console.ReadLine();
            Console.Write("Ingrese su localidad: ");
            Localidad = Console.ReadLine();
            Console.Write("Ingrese su email: ");
            Email = Console.ReadLine();
            do
            {
                Console.Write("¿Padece de alguna enfermedad crónica?\n[Si | No]: ");
                Enfermedad = Console.ReadLine();
                if (Enfermedad != "si" && Enfermedad != "Si" && Enfermedad != "no" && Enfermedad != "No")
                {
                    Console.WriteLine("ERROR: intente nuevamente\n");
                }
            } while (Enfermedad != "si" && Enfermedad != "Si" && Enfermedad != "no" && Enfermedad != "No");
            do
            {
                Console.Write("¿Toma alguna medicación de forma permanente?\n[Si | No]: ");
                Medicamento = Console.ReadLine();
                if (Medicamento != "si" && Medicamento != "Si" && Medicamento != "no" && Medicamento != "No")
                {
                    Console.WriteLine("ERROR: intente nuevamente\n");
                }
            } while (Medicamento != "si" && Medicamento != "Si" && Medicamento != "no" && Medicamento != "No");
            if (Medicamento == "si" || Medicamento == "Si")
            {
                Console.Write("Indicar la medicación que toma: ");
                Medicacion = Console.ReadLine();
            }
            Console.WriteLine("\nMUCHAS GRACIAS POR COMPLETAR CON SUS DATOS\n\n");
            Console.WriteLine(AsignarCategoria());
            Console.Write("Presione cualquier tecla para continuar ");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(Reglamento());
            do
            {
                Console.Write("\n¿Acepta registrarse como socio?\n[Si | No]: ");
                Registro = Console.ReadLine();
            } while (Registro != "si" && Registro != "no" && Registro != "Si" && Registro != "No");
            if (Registro == "Si" || Registro == "si")
            {
                do
                {
                    Console.WriteLine("\nSeleccione un método de pago:\n1_EFECTIVO\n2_TARJETA DE CRÉDITO\n3_TARJETA DE DÉBITO\n");
                    MetodoPago = Convert.ToInt16(Console.ReadLine());
                    if (MetodoPago != 1 && MetodoPago != 2 && MetodoPago != 3)
                    {
                        Console.WriteLine("Opción inválida, intente nuevamente\n");
                    }
                } while (MetodoPago != 1 && MetodoPago != 2 && MetodoPago != 3);
                Console.WriteLine("\nIntroduzca una contraseña para el inicio de sesión: ");
                Contraseña = Console.ReadLine();
                Console.WriteLine("\nREGISTRO EXITOSO");
            }
        }
        public string AsignarCategoria()
        {
            int edad = DateTime.Today.AddTicks(-fechaNacimiento.Ticks).Year - 1;
            if (edad >= 18 && edad <= 56 && (enfermedad == "no" || enfermedad == "No"))
            {
                categoria = "Su categoría es: ACTIVO\n";
            }
            else
            {
                categoria = "Su categoría es: PASIVO\n";
            }
            return categoria;
        }
        public string Reglamento()
        {
            string reglamento = "El circulo de sangre RH Negativo reúne a todas las personas que posean el factor RH Negativo, sea" +
                        "cual fuera su grupo sanguíneo, logrando de esta manera un sistema de autoprotección mediante el" +
                        "cual los asociados, podrán donarse sangre entre si para el momento en que así lo necesiten. Existen" +
                        "dos categorías de socios, activos y pasivos, los activos son quienes están en condiciones de donar" +
                        "sangre y se determina por la edad, mayores de 18 hasta 56 años inclusive; los pasivos son los" +
                        "menores de 18 años y mayores a 56 años.Además de la edad, se considera como pasivos a quienes" +
                        "con la edad de una persona activa tenga enfermedad crónica y deba tomar determinados" +
                        "medicamentos de forma permanente.Para poder pertenecer al círculo, las personas se deben" +
                        "asociar y pagar una cuota de manera mensual.\n\nEl costo de la cuota para la categoría ACTIVO es de: $12.300\n" +
                        "El costo de la cuota para la categoría PASIVO es de: $8.500\n";
            return reglamento;
        }
        public void InicioSesion(int z)
        {
            bool usuarioExistente = false;
            bool contraseñaCorrecta = false;
            
            do
            {
                Console.Write("Ingrese su DNI: ");
                string id = Console.ReadLine();
                for (int i = 0; i < z; i++)
                {
                    if (id == listaSocios[i, 2])
                    {
                        do
                        {
                            Console.Write("Ingrese su contraseña: ");
                            string contraseña1 = Console.ReadLine();
                            if (contraseña1 == listaSocios[i, 8])
                            {
                                Console.WriteLine("\n¡INGRESO EXITOSO!");
                                contraseñaCorrecta = true;
                                i = z;
                            }
                            else
                            {
                                Console.WriteLine("Contraseña incorrecta, intente nuevamente");
                            }
                        } while (contraseñaCorrecta == false);
                        usuarioExistente = true;
                    }
                }
                if (usuarioExistente == false)
                {
                    Console.WriteLine("\nUsuario inexistente, intente nuevamente\n");
                }
            } while (usuarioExistente == false);
        }
        public void RegistrarSocio(int z)
        {
            listaSocios[z, 0] = Nombre;
            listaSocios[z, 1] = Apellido;
            listaSocios[z, 2] = DNI1.ToString();
            listaSocios[z, 3] = FechaNacimiento.ToString();
            listaSocios[z, 4] = Domicilio;
            listaSocios[z, 5] = Localidad;
            listaSocios[z, 6] = Email;
            listaSocios[z, 7] = Enfermedad;
            listaSocios[z, 8] = Contraseña;
            listaSocios[z, 9] = GrupoSanguineo;
            listaSocios[z, 10] = FactorRH.ToString();
            listaSocios[z, 11] = Categoria;
            listaSocios[z, 11] = Medicamento;
            listaSocios[z, 12] = Medicacion;
            Console.WriteLine("\n");
        }
        public void Retorno(int x)
        {
            do
            {
                Console.WriteLine("Para finalizar, presione 0\nPara volver al menú, presione 1\n");
                x = Convert.ToInt16(Console.ReadLine());
            } while (x < 0 || x > 1);
            Console.Clear();
        }
    }
}