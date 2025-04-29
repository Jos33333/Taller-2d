using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_progra
{
    internal class Personaje
    {
        private int vida;
        private int daño;
        private string nombre;

        public Personaje(string nombre, int vida, int daño)
        {
            this.vida = vida;
            this.daño = daño;
            this.nombre = nombre;
        }

        //><

        public void recibirDaño(int cantidad)
        {
            vida -= cantidad;
            if (vida < 0 )
            {
                vida = 0;
            }
        }
        
        public int obtenerDaño()
        {
            return daño;
        }

        public string obtenerNombre()
        {
            return nombre;
        }

        public int obtenerVida()
        {
            return vida;
        }

        public bool estaVivo()
        {
            return vida > 0;
        }
    }
}
