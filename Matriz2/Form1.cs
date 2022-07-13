using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Matriz2.Jugador;

namespace Matriz2
{
    public partial class Form1 : Form
    {
        List<Jugador> jugadores;

        public Form1()
        {
            this.jugadores = new List<Jugador>{
                new Jugador("Pepe",new Point(0,0),Color.Blue,10),
                new Jugador("juan",new Point(19,19),Color.Yellow,10),

            };
            InitializeComponent();
            Mapa mapa = new Mapa(20
            , jugadores,
            new List<Obstaculo>
            {
                new Obstaculo (new Point(1,1),Color.Red)
            });

            this.Controls.Clear();
            foreach (Label l in mapa.Dibujar())
            {
                this.Controls.Add(l);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    jugadores[0].Mover(Direccion.Arriba);
                    break;
                case Keys.Down:
                    jugadores[0].Mover(Direccion.Abajo);
                    break;
                case Keys.Left:
                    jugadores[0].Mover(Direccion.Izquierda);
                    break;
                case Keys.Right:
                    jugadores[0].Mover(Direccion.Derecha);
                    break;

            }
        }
    }
}
