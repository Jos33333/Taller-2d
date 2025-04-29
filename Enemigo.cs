using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_progra
{
    internal class Enemigo
    {
        //><
        private int vida;
        private int daño;

        public Enemigo(int vida, int daño)
        {
            this.vida = vida;
            this.daño = daño;
        }

        public void recibirDaño(int cantidad)
        {
            vida -= cantidad;
            if(vida < 0 )
            {
                vida = 0;
            }
        }
        public int obtenerDaño()
        {
            return daño;
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
