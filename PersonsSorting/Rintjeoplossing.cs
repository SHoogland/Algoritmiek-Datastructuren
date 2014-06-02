//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace PersonsSorting {
//    class Rintjeoplossing {
//         public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        //Array met personen
//        public IComparable[] personen = new IComparable[6];
//        public IComparable[] gesorteerdePersonen = new IComparable[6];

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            //Vullen van de personen array met de verschillende personen (leeftijd en naam)
//            personen[0] = new Persoon(21, "Aron");
//            personen[1] = new Persoon(26, "Pieter");
//            personen[2] = new Persoon(23, "Geert");
//            personen[3] = new Persoon(16, "Johan");
//            personen[4] = new Persoon(28, "Bas");
//            personen[5] = new Persoon(25, "Tomas");
            
//            //Alle personen op de niet-gesorteerde-personen-label laten zien
//            lblArrayNotSorted.Text = "Personen:" + "\r\n";
//            for (int persoonid = 0; persoonid < personen.Length; persoonid++) 
//            {
//                Persoon persoon = (Persoon)personen[persoonid];
//                lblArrayNotSorted.Text += persoon.naam + "(" + persoon.leeftijd + ")" +  "\r\n";                
//            }
//        }

//        private void btnSorteerPersonen_Click(object sender, EventArgs e)
//        {
//            //Sorteer de personen uit de array
//            SorteerPersonen();
//        }

//        private void SorteerPersonen()
//        {
//            //Verdeel de personen in twee arrays
//            IComparable[] personenarray1 = new IComparable[3];
//            IComparable[] personenarray2 = new IComparable[3];
//            personenarray1 = personen.Take(personen.Length / 2).ToArray();
//            personenarray2 = personen.Skip(personen.Length / 2).ToArray();

//            //Sorteer de twee arrays op leeftijd
//            Array.Sort(personenarray1, Persoon.sortLeeftijdAscending());
//            Array.Sort(personenarray2, Persoon.sortLeeftijdAscending());

//            //Vergelijk de personen
//            //Geef de eerste en de tweede array mee
//            //Geef de personenid's mee die moeten worden vergeleken met elkaar
//            VergelijkPersonen(personenarray1,personenarray2, 0, 0, 0);
//        }

//        private void VergelijkPersonen(IComparable[] personenarray1, IComparable[] personenarray2, int persoon1 , int persoon2, int teller)
//        {
//            //Bekijken of de lijst van persoon 1 al volledig bekeken is
//            if (persoon1 == personenarray1.Length)
//            {
//                //Bekijken hoeveel personen er nog moet worden toegevoegd
//                int personenNogLaden = personenarray2.Length - persoon2;

//                //Personen toegevoegd aan de array
//                for (int i = 0; i < personenNogLaden; i++)
//                {
//                    //Haal het persoon op
//                    Persoon Persoon2 = (Persoon)personenarray2[persoon2 + i];
//                    //Stop de persoon in de array
//                    gesorteerdePersonen[teller+i] = Persoon2;
//                }
//            }

//            //Bekijken of de lijst van persoon 2 al volledig bekeken is 
//            if (persoon2 == personenarray2.Length)
//            {
//                //Bekijken hoeveel personen er nog moet worden toegevoegd
//                int personenNogLaden = personenarray1.Length - persoon1;

//                //Personen toegevoegd aan de array
//                for (int i = 0; i < personenNogLaden; i++)
//                {
//                    //Haal het persoon op
//                    Persoon Persoon1 = (Persoon)personenarray1[persoon1+i];
//                    //Stop de persoon in de array
//                    gesorteerdePersonen[teller + i] = Persoon1;
//                }
//            }

//            //Wanneer de personenlijsten niet worden overschreven
//            if (persoon1 < personenarray1.Length && persoon2 < personenarray2.Length)
//            {
//                //Haal het persoon op
//                Persoon Persoon1 = (Persoon)personenarray1[persoon1];

//                //Haal het persoon op
//                Persoon Persoon2 = (Persoon)personenarray2[persoon2];

//                //Vergelijk de leeftijden van de personen die hierboven zijn opgehaald.
//                int uitkomst = Persoon1.CompareTo(Persoon2);

//                //Als de leeftijd van persoon 1 groter is dan persoon2
//                if (uitkomst == 1)
//                {
//                    //Dan wordt persoon 2 in de gesorteerde personen array gegooid.
//                    gesorteerdePersonen[teller] = Persoon2;

//                    //En persoon 1 verder vergeleken met de volgende uit de tweede array. 
//                    VergelijkPersonen(personenarray1, personenarray2, persoon1, persoon2+1, teller+1);
//                }

//                //Als de leeftijd van persoon 2 groter is dan persoon 2
//                else if (uitkomst == -1)
//                {
//                    //Dan wordt persoon 1 in de array gegooid.
//                    gesorteerdePersonen[teller] = Persoon1;
//                    //Dan wordt de volgende uit de eerste array vergeleken met de persoon van de tweede array.
//                    VergelijkPersonen(personenarray1, personenarray2, persoon1 + 1, persoon2, teller + 1);
//                }

//                //Laat de personen gesorteerd zien op het label
//                ShowGeordendePersonen();
//            }
    
//        }

//        public void ShowGeordendePersonen()
//        {
//            //Alle personen op de niet-gesorteerde-personen-label laten zien
//            lblArraySorted.Text = "Personen:" + "\r\n";
//            for (int persoonid = 0; persoonid < gesorteerdePersonen.Length; persoonid++)
//            {
//                Persoon persoon = (Persoon)gesorteerdePersonen[persoonid];
//                lblArraySorted.Text += persoon.naam + "(" + persoon.leeftijd + ")" + "\r\n";
//            }
//        }
//    }
//}
