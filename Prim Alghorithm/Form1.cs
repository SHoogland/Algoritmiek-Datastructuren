using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prim_Alghorithm {
    public partial class Form1 : Form {
        private List<Knoop> knopen = new List<Knoop>();
        private List<Kant> kanten = new List<Kant>();

        public Form1() {
            InitializeComponent();
            Start();
        }

        private void Start() {
            // maak knopen aan (hardcoded) 
            Knoop h1 = new Knoop("H1");
            Knoop h2 = new Knoop("H2");
            Knoop h3 = new Knoop("H3");
            Knoop h4 = new Knoop("H4");
            Knoop h5 = new Knoop("H5");
            Knoop h6 = new Knoop("H6");
            Knoop h7 = new Knoop("H7");
            Knoop h8 = new Knoop("H8");
            Knoop h9 = new Knoop("H9");
            Knoop h10 = new Knoop("H10");

            knopen.Add(h1);
            knopen.Add(h2);
            knopen.Add(h3);
            knopen.Add(h4);
            knopen.Add(h5);
            knopen.Add(h6);
            knopen.Add(h7);
            knopen.Add(h8);
            knopen.Add(h9);
            knopen.Add(h10);

            // maak kanten aan (hardcoded) 
            kanten.Add(new Kant(h1, h2, 20));
            kanten.Add(new Kant(h1, h3, 45));
            kanten.Add(new Kant(h1, h10, 45));
            kanten.Add(new Kant(h2, h3, 30));
            kanten.Add(new Kant(h2, h5, 25));
            kanten.Add(new Kant(h2, h8, 100));
            kanten.Add(new Kant(h2, h10, 30));
            kanten.Add(new Kant(h3, h4, 45));
            kanten.Add(new Kant(h4, h5, 75));
            kanten.Add(new Kant(h4, h6, 40));
            kanten.Add(new Kant(h5, h6, 75));
            kanten.Add(new Kant(h5, h8, 90));
            kanten.Add(new Kant(h6, h7, 80));
            kanten.Add(new Kant(h6, h9, 40));
            kanten.Add(new Kant(h7, h8, 15));
            kanten.Add(new Kant(h8, h9, 45));
            kanten.Add(new Kant(h8, h10, 50));

            // bepaal 'Minimum Spanning Tree' via prim algoritme 
            MinimumSpanningTree(knopen, kanten);
        }

        private void MinimumSpanningTree(List<Knoop> knopen, List<Kant> kanten) {
            // 1) bouw een tabel op met [aantal knopen] rijen en [aantal knopen] kolommen, 
            // met daarin opgenomen de onderlinge afstanden 
            DataTable table = new DataTable("PrimTable");
            table.Columns.Add(new DataColumn("="));
            for (int i = 0; i < knopen.Count; i++) {
                table.Columns.Add(new DataColumn(knopen[i].Identifier));
            }

            for (int i = 1; i <= knopen.Count; i++) {
                DataRow dr = table.NewRow();
                dr["="] = "H" + i;
                for (int e = 1; e <= knopen.Count; e++) {
                    if (kanten.Any(k => k.KnoopA.Identifier == "H" + e && k.KnoopB.Identifier == "H" + i)) {
                        dr["H" + e] = kanten.SingleOrDefault(k => k.KnoopA.Identifier == "H" + e && k.KnoopB.Identifier == "H" + i).Lengte;
                    }
                    else if (kanten.Any(k => k.KnoopB.Identifier == "H" + e && k.KnoopA.Identifier == "H" + i)) {
                        dr["H" + e] = kanten.SingleOrDefault(k => k.KnoopB.Identifier == "H" + e && k.KnoopA.Identifier == "H" + i).Lengte;
                    }
                    else {
                        dr["H" + e] = "=";
                    }
                }
                table.Rows.Add(dr);
            }
            //Show table for funsiess
            var SBind = new BindingSource();
            SBind.DataSource = table;
            dataGridView1.DataSource = SBind;
            
            //Layout improvements
            foreach (DataGridViewColumn column in dataGridView1.Columns) {
                column.Width = 30;
            }

            // 2a) selecteer een willekeurige knoop en verwijder de betreffende rij 
            Random rnd = new Random();
            int randomSelecteerdeKnoop = rnd.Next(0, knopen.Count);

            var geselecteerdeKnopen = new List<Knoop>();
            geselecteerdeKnopen.Add(knopen[randomSelecteerdeKnoop]);
            var gevondenKanten = new List<Kant>();
            label1.Text = "1ste Knoop = " + knopen[randomSelecteerdeKnoop].Identifier + "\n";

            // 5) zolang niet alle knopen geselecteerd zijn, ga door... 
            while (geselecteerdeKnopen.Count < knopen.Count) {
                // 3a) selecteer vanuit de geselecteerde knopen (kolommen) de eindknoop met 
                // de laagste waarde (bij ‘meerdere ‘laagste waarden’ kies er één uit) 
                var mogelijkeKnopen = new List<Kant>();
                foreach (var kant in kanten) {
                    if (geselecteerdeKnopen.Contains(kant.KnoopA) && !geselecteerdeKnopen.Contains(kant.KnoopB)) {
                        mogelijkeKnopen.Add(kant);
                    }
                    if (geselecteerdeKnopen.Contains(kant.KnoopB) && !geselecteerdeKnopen.Contains(kant.KnoopA)) {
                        mogelijkeKnopen.Add(kant);
                    }
                }

                var gevondenKant = mogelijkeKnopen.OrderBy(k => k.Lengte).FirstOrDefault();
                if (geselecteerdeKnopen.Contains(gevondenKant.KnoopA)) {
                    geselecteerdeKnopen.Add(gevondenKant.KnoopB);
                }
                else {
                    geselecteerdeKnopen.Add(gevondenKant.KnoopA);
                }
                gevondenKanten.Add(gevondenKant);

                // 3b) voeg de kant [kolomknoop, rijknoop] toe aan de lijst geselecteerde kanten 
                // TODO... 

                // 4a) voeg de eindknoop toe aan de geselecteerde knopen en verwijder de 
                // betreffende rij uit de tabel 
                // TODO... 
            }

            // 6) de lijst met geselecteerde kanten is de oplossing, toon deze lijst 
            int totaleLengte = 0;
            foreach (var kant in gevondenKanten) {
                label1.Text += kant.Lengte + " " + kant.KnoopA.Identifier + "=" + kant.KnoopB.Identifier + "\n";
                totaleLengte = totaleLengte + kant.Lengte;
            }
            label1.Text += "Totale Lengte:" + totaleLengte;
        }
    }
}
