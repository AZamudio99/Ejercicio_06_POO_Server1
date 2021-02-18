using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ejercicio_06_POO_Server1.addNeg
{
    public class NegUsuario
    {
        public int idUsuario { get; set; }
        public String Nombre { get; set; }
        public int edad { get; set; }
        public String telefono { get; set; }
        public String correo { get; set; }

        public NegUsuario() { 
        }

        
         
        public NegUsuario(int idUsuario,string nombre,int Edad,String Telefono,String Correo)
        {
            this.idUsuario = idUsuario;
            this.Nombre = nombre;
            this.edad = Edad;
            this.telefono = Telefono;
            this.correo = Correo;
        }

        public NegUsuario(string nombre, int Edad, String Telefono, String Correo) {
            this.Nombre = nombre;
            this.edad = Edad;
            this.telefono = Telefono;
            this.correo = Correo;
        }
    }
}