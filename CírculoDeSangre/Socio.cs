using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    public class Socio
    {

        //DECLARACION DE VARIABLES
        private string nombre;
        private string apellido;
        private string grupoSanguineo;
        private string dni;
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
        private DateTime fechaDeUltimaDonacion;
        private string condicion;
        private int cantDeDonaciones;

        //ENCAPSULAMIENTO DE VARIABLES
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string GrupoSanguineo { get => grupoSanguineo; set => grupoSanguineo = value; }
        public string Domicilio { get => domicilio; set => domicilio = value; }
        public string Localidad { get => localidad; set => localidad = value; }
        public string Email { get => email; set => email = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Enfermedad { get => enfermedad; set => enfermedad = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public char FactorRH { get => factorRH; set => factorRH = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Medicamento { get => medicamento; set => medicamento = value; }
        public string Medicacion { get => medicacion; set => medicacion = value; }
        public string Registro { get => registro; set => registro = value; }
        public int MetodoPago { get => metodoPago; set => metodoPago = value; }
        public string Dni { get => dni; set => dni = value; }
        public DateTime FechaDeUltimaDonacion { get => fechaDeUltimaDonacion; set => fechaDeUltimaDonacion = value; }
        public string Condicion { get => condicion; set => condicion = value; }
        public int CantDeDonaciones { get => cantDeDonaciones; set => cantDeDonaciones = value; }

        private List<Socio> listaDeSocios = new List<Socio>();
        public List<Socio> ListaDeSocios { get => listaDeSocios; set => listaDeSocios = value; }

        

        public void SociosRegistrados()
        {
            ListaDeSocios.Add(new Socio()
            {
                Nombre = "Tomás",
                Apellido = "Eschoyez",
                Dni = "42182580",
                FechaNacimiento = new DateTime(1999, 12, 10),
                Domicilio = "Honduras 534",
                Localidad = "Brinkmann",
                GrupoSanguineo = "A",
                FactorRH = '-',
                Enfermedad = "No",
                Medicamento = "No",
                Medicacion = "",
                Email = "eschoyeztomas@gmail.com",
                Contraseña = "123",
                FechaDeUltimaDonacion = new DateTime(25 / 02 / 2019),
                CantDeDonaciones = 6,
                Categoria = AsignarCategoria(),
                Condicion = CalcularCondicion(),
                MetodoPago = 1
            });
            ListaDeSocios.Add(new Socio()
            {
                Nombre = "Matias",
                Apellido = "Morero",
                Dni = "42182581",
                FechaNacimiento = new DateTime(2000, 08, 08),
                Domicilio = "Cabrera 1678",
                Localidad = "San Francisco",
                GrupoSanguineo = "AB",
                FactorRH = '-',
                Enfermedad = "Si",
                Medicamento = "Si",
                Medicacion = "Ibuprofeno",
                Email = "moreromatias@gmail.com",
                Contraseña = "1234",
                FechaDeUltimaDonacion = new DateTime(10 / 03 / 2022),
                CantDeDonaciones = 2,
                Categoria = AsignarCategoria(),
                Condicion = CalcularCondicion(),
                MetodoPago = 2
            });
            ListaDeSocios.Add(new Socio()
            {
                Nombre = "Constanza",
                Apellido = "Garello",
                Dni = "42182582",
                FechaNacimiento = new DateTime(2005, 06, 06),
                Domicilio = "Italia 999",
                Localidad = "Devoto",
                GrupoSanguineo = "0",
                FactorRH = '-',
                Enfermedad = "no",
                Medicamento = "no",
                Email = "garelloconstanza@gmail.com",
                Contraseña = "12345",
                FechaDeUltimaDonacion = new DateTime(10/02/2021),
                CantDeDonaciones = 1,
                Categoria = AsignarCategoria(),
                Condicion = CalcularCondicion(),
                MetodoPago = 3
            });
        }
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
                grupoSanguineo = Console.ReadLine();
                switch (grupoSanguineo)
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
                        error = true;
                        break;
                }
            } while (error == true);
            do
            {
                error = false;
                Console.Write("Ingrese su factor RH\n[+ | -]: ");
                factorRH = Convert.ToChar(Console.ReadLine());
                switch (factorRH)
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
            do
            {
                Console.Write("Ingrese su nombre: ");
                nombre = Console.ReadLine();
            } while (!Regex.Match(nombre, @"^[A-Za-z]{3,10}$|^[A-Za-z]{3,10}\s[A-Za-z]{3,10}$").Success);
            do {
                Console.Write("Ingrese su apellido: ");
                apellido = Console.ReadLine();
            } while (!Regex.Match(apellido, @"^[A-Za-z]{2,10}$|^[A-Za-z]{2,10}\s[A-Za-z]{2,10}$").Success);
            do {
                Console.Write("Ingrese su número de DNI: ");
                dni = Console.ReadLine();
            } while (!Regex.Match(dni, @"^\d{8}$").Success);
            try
            {
                Console.Write("Ingrese su fecha de nacimiento **/**/**** : ");
                fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
            }
            catch(Exception)
            {
                Console.WriteLine("Vuelve a intentarlo");
            }
            do
            {
                Console.Write("Ingrese su domicilio: ");
                domicilio = Console.ReadLine();
            } while (!Regex.Match(domicilio, @"^[a-zA-Z]{3,15}\s[0-9]+$|^[a-zA-Z]{3,15}\s[a-zA-Z]{3,15}\s[0-9]+$").Success);
            do {
                Console.Write("Ingrese su localidad: ");
                localidad = Console.ReadLine();
            } while (!Regex.Match(localidad, @"^[a-zA-Z]{3,15}$|^[a-zA-Z]{3,15}\s[a-zA-Z]{3,15}$").Success);
            do
            {
                Console.Write("Ingrese su email: ");
                email = Console.ReadLine();
            } while (!Regex.Match(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success);
            do
            {
                Console.Write("¿Padece de alguna enfermedad crónica?\n[Si | No]: ");
                enfermedad = Console.ReadLine();
                if (enfermedad != "si" && enfermedad != "Si" && enfermedad != "no" && enfermedad != "No")
                {
                    Console.WriteLine("ERROR: intente nuevamente\n");
                }
            } while (enfermedad != "si" && enfermedad != "Si" && enfermedad != "no" && enfermedad != "No");
            do
            {
                Console.Write("¿Toma alguna medicación de forma permanente?\n[Si | No]: ");
                medicamento = Console.ReadLine();
                if (medicamento != "si" && medicamento != "Si"  && medicamento != "no" && medicamento != "No")
                {
                    Console.WriteLine("ERROR: intente nuevamente\n");
                }
            } while (medicamento != "si" && medicamento != "Si"  && medicamento != "no" && medicamento != "No");
            if (medicamento == "si" || medicamento == "Si")
            {
                Console.Write("Indicar la medicación que toma: ");
                medicacion = Console.ReadLine();
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
                registro = Console.ReadLine();
            } while (registro != "si" && registro != "no" && registro != "Si" && registro != "No");
            if (registro == "Si" || registro == "si")
            {
                do
                {
                    Console.WriteLine("\nSeleccione un método de pago:\n1_EFECTIVO\n2_TARJETA DE CRÉDITO\n3_TARJETA DE DÉBITO\n");
                    metodoPago = Convert.ToInt16(Console.ReadLine());
                    if (metodoPago != 1 && metodoPago != 2 && metodoPago != 3)
                    {
                        Console.WriteLine("Opción inválida, intente nuevamente\n");
                    }
                } while (metodoPago != 1 && metodoPago != 2 && metodoPago != 3);
                Console.WriteLine("\nIntroduzca una contraseña para el inicio de sesión: ");
                contraseña = Console.ReadLine();
                Console.WriteLine("\nREGISTRO EXITOSO");
            }
        }
        public string AsignarCategoria()
        {
            int edad = DateTime.Today.AddTicks(-FechaNacimiento.Ticks).Year - 1;
            if (edad >= 18 && edad <= 56 && (Enfermedad == "no" || Enfermedad == "No" || Enfermedad == "NO"))
            {
                Categoria = "Su categoría es: ACTIVO\n";
            }
            else
            {
                Categoria = "Su categoría es: PASIVO\n";
            }
            return Categoria;
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
                        "asociar y pagar una cuota de manera mensual.\n\nEl costo de la cuota para la categoría ACTIVO es de: $8.500\n" +
                        "El costo de la cuota para la categoría PASIVO es de: $12.300\n";
            return reglamento;
        }
        public void InicioSesion(int x)
        {
            bool usuarioExistente = false;
            bool contraseñaCorrecta = false;
            int opcion;
            string id;

            do
            {
                Console.Write("Ingrese su DNI: ");
                id = Console.ReadLine();
                foreach (Socio item in ListaDeSocios)
                {
                    if (id == item.Dni)
                    {
                        do
                        {
                            Console.Write("Ingrese su contraseña: ");
                            string contraseña1 = Console.ReadLine();
                            if (contraseña1 == item.Contraseña)
                            {
                                Console.WriteLine("\n¡INGRESO EXITOSO!\n");
                                contraseñaCorrecta = true;
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
            Console.Clear();
            bool valid = false;
            bool volver = false;
            do
            {
                do
                {
                    Console.WriteLine("-Para ver su información, presione 1\n-Para modificar sus datos, presione 2\n-Para salir, presione 0\n");
                    opcion = Convert.ToInt16(Console.ReadLine());
                    Console.Clear();
                    if (opcion == 0 || opcion == 1 || opcion == 2)
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
                        x = 1;
                        volver = false;
                        break;
                    case 1:
                        foreach (var item in ListaDeSocios)
                        {
                            if (item.Dni == id)
                            {
                                item.DatosSocio();
                            }
                        }
                        volver = true;
                        Console.WriteLine("Presione Enter para volver");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        ModificarDatos(id);
                        volver = true;
                        break;
                    case 3:
                        break;
                }
            } while (volver == true);
        }
        public void ModificarDatos(string id)
        {
            int opcion;
            bool valid = false;
            do
            {
                Console.WriteLine("-Para modificar sus datos personales, presione 1\n-Para modificar su estado de salud, presione 2\n-Para cambiar su contraseña, presione 3\n-Para salir, presione 0\n");
                opcion = Convert.ToInt16(Console.ReadLine());
                Console.Clear();
                if (opcion == 0 || opcion == 1 || opcion == 2 || opcion == 3)
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Opción incorrecta, vuelve a intentarlo\n");
                }
            } while (valid == false);
            switch(opcion)
            {
                case 1:
                    Console.Clear();
                    string op;
                    do
                    {
                        Console.WriteLine("1_ Cambiar Nombre");
                        Console.WriteLine("2_ Cambiar Apellido");
                        Console.WriteLine("3_ Cambiar DNI");
                        Console.WriteLine("4_ Cambiar Fecha de Nacimiento");
                        Console.WriteLine("5_ Cambiar Domicilio");
                        Console.WriteLine("6_ Cambiar Localidad");
                        Console.WriteLine("Ingrese una opción: ");
                        op = Console.ReadLine();
                        Console.Clear();
                        switch (op)
                        {
                            case "1":
                                foreach (var item in ListaDeSocios)
                                {
                                    if (id == item.Dni)
                                    {
                                        Console.Write("Ingrese el nuevo nombre: ");
                                        item.Nombre = Console.ReadLine();
                                    }
                                }
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                break;
                            case "2":
                                foreach (var item in ListaDeSocios)
                                {
                                    if (id == item.Dni)
                                    {
                                        Console.Write("Ingrese el nuevo apellido: ");
                                        item.Apellido = Console.ReadLine();
                                    }
                                }
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                break;
                            case "3":
                                foreach (var item in ListaDeSocios)
                                {
                                    if (id == item.Dni)
                                    {
                                        Console.Write("Ingrese el nuevo DNI: ");
                                        item.Dni = Console.ReadLine();
                                    }
                                }
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                break;
                            case "4":
                                foreach (var item in ListaDeSocios)
                                {
                                    if (id == item.Dni)
                                    {
                                        Console.Write("Ingrese la nueva fecha de nacimiento: ");
                                        item.FechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                                        item.Categoria = item.AsignarCategoria();
                                    }
                                }
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                break;
                            case "5":
                                foreach (var item in ListaDeSocios)
                                {
                                    if (id == item.Dni)
                                    {
                                        Console.Write("Ingrese el nuevo domicilio: ");
                                        item.Domicilio = Console.ReadLine();
                                    }
                                }
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                break;
                            case "6":
                                foreach (var item in ListaDeSocios)
                                {
                                    if (id == item.Dni)
                                    {
                                        Console.Write("Ingrese la nueva localidad: ");
                                        item.Localidad = Console.ReadLine();
                                    }
                                }
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("ERROR: La opcion ingresada no es valida.\n");
                                break;
                        }
                    } while (op != "1" && op != "2" && op != "3" && op != "4" && op != "5" && op != "6");
                    break;
                case 2:
                    Console.Clear();
                    foreach (var item in ListaDeSocios)
                    {
                        if (id == item.Dni)
                        {
                            Console.Write("Ingrese nuevamente si posee una enfermedad [ Si | No ]: ");
                            item.Enfermedad = Console.ReadLine();
                            Console.WriteLine("\nCambios guardados exitosamente.\n");
                            if (item.Enfermedad == "Si" || item.Enfermedad == "si")
                            {
                                item.Categoria = "Pasivo";
                                Console.Write("Ingrese nuevamente si toma medicacion [ Si | No ]: ");
                                item.Medicamento = Console.ReadLine();
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                if (item.Medicamento == "Si" || item.Medicamento == "si")
                                {
                                    Console.Write("Ingrese el nuevo medicamento que toma: ");
                                    item.Medicacion = Console.ReadLine();
                                    Console.WriteLine("\nCambios guardados exitosamente.\n");
                                    Console.Clear();
                                }
                                else
                                {
                                    item.Medicacion = "No consume ninguna medicacion";
                                }
                            }
                            else
                            {
                                item.Categoria = item.AsignarCategoria();
                                item.Medicamento = "No";
                                item.Medicacion = "No consume ninguna medicacion";
                                Console.WriteLine("\nCambios guardados exitosamente.\n");
                                Console.Clear();
                            }
                        }
                    }
                    Console.Clear();
                    break;
                case 3:
                    Console.Clear();
                    foreach (var item in ListaDeSocios)
                    {
                        if (id == item.Dni)
                        {
                            Console.Write("Ingrese la nueva contraseña: ");
                            item.Contraseña = Console.ReadLine();
                        }
                    }
                    Console.WriteLine("\nCambios guardados exitosamente.\n");
                    break;
            }
        }
        public void RegistrarSocio()
        {
            ListaDeSocios.Add(new Socio()
            {
                Nombre = nombre,
                Apellido = apellido,
                Dni = dni,
                FechaNacimiento = fechaNacimiento,
                Domicilio = domicilio,
                Localidad = localidad,
                Email = email,
                GrupoSanguineo = grupoSanguineo,
                FactorRH = factorRH,
                Enfermedad = enfermedad,
                Medicamento = medicamento,
                Medicacion = medicacion,
                MetodoPago = metodoPago,
                Contraseña = contraseña,
                FechaDeUltimaDonacion = new DateTime(01/01/2000),
                Categoria = AsignarCategoria(),
                Condicion = CalcularCondicion(),
            });
        }
        public int RetornoMenu(int x)
        {
            do
            {
                Console.WriteLine("Para finalizar, presione 0\nPara volver al menú, presione 1\n");
                x = Convert.ToInt16(Console.ReadLine());
            } while (x < 0 || x > 1);
            Console.Clear();
            return x;
        }
        public void VerDatos()
        {
            foreach (var item in ListaDeSocios)
            {
                item.DatosSocio();
            }
        }
        public void DatosSocio()
        {
            Console.WriteLine("Nombre: " + Nombre);
            Console.WriteLine("Apellido: " + Apellido);
            Console.WriteLine("DNI: " + Dni);
            Console.WriteLine("Fecha de Nacimiento: " + FechaNacimiento);
            Console.WriteLine("Domicilio: " + Domicilio);
            Console.WriteLine("Localidad: " + Localidad);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Grupo Sangruíneo: " + GrupoSanguineo);
            Console.WriteLine("Factor RH: " + FactorRH);
            Console.WriteLine("Posee enfermedad: " + Enfermedad);
            Console.WriteLine("Toma medicamento: " + Medicamento);
            if(Medicamento == "si" || Medicamento == "Si" || Medicamento == "SI")
            {
                Console.WriteLine("Cuál?: " + Medicacion);
            }
            Console.WriteLine(AsignarCategoria());
            Console.WriteLine("Condición: " + Condicion);
            Console.WriteLine("Fecha de ultima donacion: " + FechaDeUltimaDonacion);
            Console.WriteLine("Cantidad de donaciones en el año: " + CantDeDonaciones);
            Console.WriteLine("Método de Pago: " + MetodoPago);
            Console.WriteLine("Contraseña: " + Contraseña);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("\n");
        }
        public string CalcularCondicion()
        {
            int plazo;
            if (FechaDeUltimaDonacion == new DateTime(1, 1, 1))
            {
                plazo = 4;
            }
            else
            {
                plazo = DateTime.Today.AddTicks(-FechaDeUltimaDonacion.Ticks).Month - 1;
            }

            if (Categoria == "Su categoría es: ACTIVO\n" && plazo >= 4 && CantDeDonaciones < 2)
            {
                Condicion = "Disponible";
            }
            else
            {
                Condicion = "No disponible";
            }
            return Condicion;
        }
    }
}