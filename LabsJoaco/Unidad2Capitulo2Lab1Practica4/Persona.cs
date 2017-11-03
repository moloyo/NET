using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unidad2Capitulo2Lab1Practica4
{
    class Persona
    {
        private string nombre;
        private string apellido;
        private int dni;
        private int edad;

        public string Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }
        public string Apellido
        {
            set
            {
                apellido = value;
            }
            get
            {
                return apellido;
            }
        }
        public int Dni
        {
            set
            {
                dni = value;
            }
            get
            {
                return dni;
            }
        }
        public int Edad
        {
            set
            {
                edad = value;
            }
            get
            {
                return edad;
            }
        }

        public Persona(string n, string a, int doc, int anios)
        {
            nombre = n;
            apellido = a;
            dni = doc;
            edad = anios;

            Console.WriteLine("Creado " + nombre + " " + apellido + " DNI: " + dni + " Edad: " + edad);

        }

        public string GetFullName()
        {
            return nombre + " " + apellido;
        }

        ~Persona()
        {
            Console.WriteLine(nombre + " " + apellido + " se murió  a los "+ edad + " años");
        }
        public int GetAge()
        {
            return edad;
        }
    }
}
