using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_progra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //><

            //El usuario debe crear su personaje-------------------------------------------------

            //NOMBRE
            Console.WriteLine("Ingrese el nombre de su personaje:");
            string nombre = Console.ReadLine();

            //VIDA
            int vida = 0;
            while (true)
            {
                Console.WriteLine("Ingrese la vida de su personaje (MÁXIMO 100):");
                bool n = int.TryParse(Console.ReadLine(), out vida);
           
                if(n && vida > 0 && vida <= 100)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor inválido. DEBE SER UN NÚMERO ENTRE 1 Y 100 ZZZZ:");
                }
         
            }

            //DAÑO---------------------------------
            int daño = 0;
            while (true)
            {
                Console.WriteLine("Ingrese el daño de su personaje (MÁXIMO 40):");
                bool d = int.TryParse(Console.ReadLine(), out daño);
                if (d && daño > 0 && daño <= 40)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor inválido. DEBE SER UN NÚMERO ENTRE 1 Y 40 ZZZZ:");
                }
            }

            Personaje personaje = new Personaje(nombre, vida, daño);

            Console.WriteLine($"¡Personaje {personaje.obtenerNombre()} creado! con {vida} de vida y {daño} de daño.");


            //---------------------------------------------------------------------------------
            //ZOMBIES XD  //<>
            List<Enemigo> listaEnemigos = new List<Enemigo>();
            int cantidadEnemigos = 0;
            while (true)
            {
                Console.WriteLine("¿Cuántos Zombies quieres crear? (MÁXMIXO 3 XQ SI NO TE VAN A ABUSAR)");
                bool n2 = int.TryParse(Console.ReadLine(), out cantidadEnemigos);
                if (n2 && cantidadEnemigos > 0 && cantidadEnemigos <= 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Valor inválido. DEBE SER UN NÚMERO ENTRE 1 Y 3.");
                }
            }
            int creados = 0;
             while (creados < cantidadEnemigos )
             {
                 Console.WriteLine($"----------Creando Zombie {creados + 1}");
                 int vidaEnemigo = 0;
                    while (true)
                    {
                    Console.WriteLine("Ingresa la vida del zombie (MÁXIMO 100:)");
                    bool n3 = int.TryParse(Console.ReadLine(), out vidaEnemigo);
                    if (n3 && vidaEnemigo > 0 && vidaEnemigo <= 100) 
                    {
                        break;
                    }
                        else
                    {
                        Console.WriteLine("Vlor inválido. DEBE SER UN NÚMERO ENTRE 1 Y 100: ");
                    }
             }
             int dañoEnemigo = 0;
             while(true)
             {
                Console.WriteLine("Ingresa el daño del Zombie (MÁXIMO 40:)");
                bool n4 = int.TryParse(Console.ReadLine(), out dañoEnemigo);
                if (n4 && dañoEnemigo > 0 && dañoEnemigo <= 40)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Vlor inválido. DEBE SER UN NÚMERO ENTRE 1 Y 40: ");
                }                            
             }

                 Enemigo enemigo = new Enemigo(vidaEnemigo, dañoEnemigo);
                 listaEnemigos.Add(enemigo);
                 creados++;
                
             }
            Console.WriteLine($"¡Se han creado {listaEnemigos.Count} Zombies correctamente!");
            int numeroEnemigo = 1;
            foreach (Enemigo enemigo in listaEnemigos)
            {
                Console.WriteLine($"Zombie{numeroEnemigo}: Vida = {enemigo.obtenerVida()}, Daño = {enemigo.obtenerDaño()}");
                numeroEnemigo++;
            }
            //GAMEPLAY?--------------------------------------------------------------------------------------------------------
            bool gameplay = true;
            while (gameplay)  //<>
            {
                Console.WriteLine($"Tu vida actual: {personaje.obtenerVida()}");
                Console.WriteLine($"Zombies disponibles para atacar: ");
                for (int i = 0; i < listaEnemigos.Count; i++)
                {
                    if (listaEnemigos[i].estaVivo())
                    {
                        Console.WriteLine($"[{i + 1}] Enemigo { i + 1} - vida: {listaEnemigos[i].obtenerVida()}");

                    }
                }
                int seleccion = 1;
                while (true)
                {
                    Console.WriteLine($"Selecciona el número del Zombie que quieres atacar:");
                    bool eleccion = int.TryParse(Console.ReadLine(), out seleccion);
                    if (eleccion && seleccion >= 1 && seleccion <= listaEnemigos.Count && listaEnemigos[seleccion - 1].estaVivo())
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Selección invalida. Elige un zombie que esté vivo");
                    }
                }

                listaEnemigos[seleccion -1].recibirDaño(personaje.obtenerDaño());
                Console.WriteLine($"Atacaste al Zombie {seleccion}, causando {personaje.obtenerDaño()} de daño.");

                bool zombiesMuertos = true;
                foreach (Enemigo b in listaEnemigos)
                {
                    if (b.estaVivo())
                    {
                        zombiesMuertos = false;
                        break;
                    }
                }
                if (zombiesMuertos)
                {
                    Console.WriteLine($"Has derrotado a todos los zombies! ¡VICTORIA!");
                    break;
                }

                //-------------------------------------

                List<Enemigo> zombiesVivos = listaEnemigos.Where(b => b.estaVivo()).ToList();
                Random random = new Random();
                Enemigo zombieAtaque = zombiesVivos[random.Next(zombiesVivos.Count)];

                personaje.recibirDaño(zombieAtaque.obtenerDaño());
                Console.WriteLine($"¡Un zombie te ha atacando, causando {zombieAtaque.obtenerDaño()} de daño!");

                if (!personaje.estaVivo())
                {
                    Console.WriteLine("Te han matado... GAME OVER BABY...");
                    break;
                }

            }
            //REINICIAR GAME-------------------------------

            Console.WriteLine("Deseas reiniciar la partida? si - no");
            string respuesta = Console.ReadLine();
            if (respuesta == "si")
            {
                Console.Clear();
                Main(args);
            }
            else if (respuesta == "no")
            {
                Console.WriteLine("¡MUCHAS GRACIAS POR JUGAR! ^^ ");
            }
            else
            {
                Console.WriteLine("Escribre SOLO si o no ps sonso. ADIOS");
                Console.Clear();
            }
        
        
        
        }

    }

}