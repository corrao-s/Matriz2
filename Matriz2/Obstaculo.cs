using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matriz2
{
    internal class Obstaculo : IMappeable
    {

        Point posicion;
        Color color;

        public Obstaculo(Point posicion, Color color)
        {
            this.posicion = posicion;
            this.color = color;
        }

        public Label Dibujar()
        {
            Label label = new Label();
            label.BorderStyle = BorderStyle.FixedSingle;
            label.Text = 1.ToString();
            label.Location = new Point(Mapa.bloque * posicion.X, Mapa.bloque * posicion.Y);
            label.Size = new Size(Mapa.bloque, Mapa.bloque);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.BackColor = color;
            return label;
        }

        public Point GetPosicion()
        {
            return this.posicion;
        }
    }
}
