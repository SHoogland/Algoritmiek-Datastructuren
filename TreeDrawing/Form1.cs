using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeDrawing {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        public System.Drawing.Pen myPen;
        System.Drawing.Graphics formGraphics;

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            //drawing pen initialiseren
            myPen = new System.Drawing.Pen(Color.Black);
            formGraphics = this.CreateGraphics();

            //Boom tekenen
            drawTwigs(250, 400, 0, 200, 270);
            
            //drawing pen disposen
            myPen.Dispose();
            formGraphics.Dispose();
        }

        private void drawTwigs(int x1, int y1, int depth, int length, int angle) {
            //bepaalt kleur van de lijn op basis van de hoeveelste vertakking het is
            if (depth > 2) {
                myPen.Color = Color.Green;
            }
            else {
                myPen.Color = Color.Brown;
            }

            //tekent de lijn
            double angleRadians = (Math.PI / 180) * angle;
            int x2 = x1 + Convert.ToInt32((Math.Cos(angleRadians) * length));
            int y2 = y1 + Convert.ToInt32((Math.Sin(angleRadians) * length));
            formGraphics.DrawLine(myPen, x1, y1, x2, y2);
            
            //stuurt als we niet te diep gaan de volgende taken aan
            if (depth < 6) {
                depth++;
                length = length / 2;

                drawTwigs(x2, y2, depth, length, angle - 90);
                drawTwigs(x2, y2, depth, length, angle - 45);
                drawTwigs(x2, y2, depth, length, angle);
                drawTwigs(x2, y2, depth, length, angle + 45);
                drawTwigs(x2, y2, depth, length, angle + 90);
            }
        }
    }
}
