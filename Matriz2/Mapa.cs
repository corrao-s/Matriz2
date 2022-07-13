using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matriz2
{
    internal class Mapa
    {
        internal const int bloque = 20;
        int size;
        List<IMappeable> objetos;

        public Mapa(int size, List<Jugador> jugadores, List<Obstaculo> obstaculos)
        {
            this.size = size;
            this.objetos = new List<IMappeable>();
            foreach(var item in jugadores)
            {
                if (!EstaLibre(item.GetPosicion()))
                {
                    throw new Exception("Error.");
                }
                if (!(item.GetPosicion().X< size && item.GetPosicion().Y< size && item.GetPosicion().X>= 0 && item.GetPosicion().Y>=0))
                {
                    throw new Exception("Fuera de la matriz");
                }
                objetos.Add(item);
                item.mapa = this;
            }
            foreach (var item in obstaculos)
            {
                if (!EstaLibre(item.GetPosicion()))
                {
                    throw new Exception("Error.");
                }
                if (!(item.GetPosicion().X < size && item.GetPosicion().Y < size && item.GetPosicion().X > 0 && item.GetPosicion().Y > 0))
                {
                    throw new Exception("Fuera de la matriz");
                }
                objetos.Add(item);
            }
        }

        internal Label[] Dibujar ()
        {
            Label[] labels = new Label[objetos.Count];
            int i = 0;
            foreach (var mappeable in objetos)
            {
                labels[i++] = mappeable.Dibujar();
            }
            return labels;
        }
        internal bool EstaLibre(Point p)
        {
            return !objetos.Any(o => o.GetPosicion() == p);
        }
    }
}
