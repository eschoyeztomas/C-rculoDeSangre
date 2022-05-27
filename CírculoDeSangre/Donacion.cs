using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CírculoDeSangre
{
    public class Donacion
    {
        public List<Donacion> ListaDeDonaciones = new List<Donacion>();
        private DateTime fechaDonacion;
        private string dniD;
        private string nombreD;
        private string apellidoD;

        public DateTime FechaDonacion { get => fechaDonacion; set => fechaDonacion = value; }
        public string DniD { get => dniD; set => dniD = value; }
        public string NombreD { get => nombreD; set => nombreD = value; }
        public string ApellidoD { get => apellidoD; set => apellidoD = value; }

        public void RegistrarDonacion()
        {
            try
            {
                Console.WriteLine("Ingrese la fecha en la que se realizó la donación\n**/**/****: ");
                fechaDonacion = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Vuelve a intentarlo");
            }
            do
            {
                Console.WriteLine("Ingrese el DNI del donante: ");
                dniD = Console.ReadLine();
            } while (!Regex.Match(dniD, @"^\d{8}$").Success);
            do
            {
                Console.WriteLine("Ingrese el nombre del donante: ");
                nombreD = Console.ReadLine();
            } while (nombreD == "");
            do
            {
                Console.WriteLine("Ingrese el apellido del donante: ");
                apellidoD = Console.ReadLine();
            } while (apellidoD == "");
        }
        public void CargarDonacion()
        {
            ListaDeDonaciones.Add(new Donacion() 
            {
                FechaDonacion = fechaDonacion,
                DniD = dniD,
                NombreD = nombreD,
                ApellidoD = apellidoD,
            });
        }
        public void DatosDonacion()
        {
            Console.WriteLine("Nombre del donante: " + NombreD);
            Console.WriteLine("Apellido del donante: " + ApellidoD);
            Console.WriteLine("DNI del donante: " + DniD);
            Console.WriteLine("Fecha de donación: " + FechaDonacion);
        }
        public void MostrarListado()
        {
            foreach(var item in ListaDeDonaciones)
            {
                item.DatosDonacion();
            }
        }
    }
}