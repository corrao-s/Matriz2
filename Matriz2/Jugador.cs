using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matriz2
{
    internal class Jugador : IMappeable
    {

        private Label label;
        string name;
        Point posicion;
        int? defensa;
        int? ataque;
        Color color;
        int vida;
        internal Mapa mapa;

        public Jugador(string name, Point posicion, Color color, int vida)
        {
            this.name = name;
            this.posicion = posicion;
            this.color = color;
            this.vida = vida;
        }

        public void Mover(Direccion direccion)
        {
            Point final = new Point(posicion.X, posicion.Y);
            switch (direccion)
            {
                case Direccion.Arriba:
                    final = new Point(posicion.X, posicion.Y - 1);
                    break;
                case Direccion.Abajo:
                    final = new Point(posicion.X, posicion.Y + 1);
                    break;
                case Direccion.Derecha:
                    final = new Point(posicion.X + 1, posicion.Y);
                    break;
                case Direccion.Izquierda:
                    final = new Point(posicion.X - 1, posicion.Y);
                    break;
            }
            if (mapa.EstaLibre(final))
            {
                this.posicion = final;
                label.Location = new Point(Mapa.bloque * posicion.X, Mapa.bloque * posicion.Y);

            }
        }
        public void Atacar()
        {

        }
        public void ActivarDefensa()
        {

        }
        public void DesactivarDefensa()
        {

        }
        public Label Dibujar()
        {
            if (label == null)
            {
                label = new Label();
                label.BorderStyle = BorderStyle.FixedSingle;
                label.Text = 1.ToString();
                label.Location = new Point(Mapa.bloque * posicion.X, Mapa.bloque * posicion.Y);
                label.Size = new Size(Mapa.bloque, Mapa.bloque);
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.BackColor = color;
            }
            return label;
        }

        public Point GetPosicion()
        {
            return posicion;
        }
        public enum Direccion
        {
            Arriba, Abajo, Derecha, Izquierda
        }
    }
}
