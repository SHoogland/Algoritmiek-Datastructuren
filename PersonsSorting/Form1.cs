using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonsSorting {
    public class Person : IComparable {
        public int Age;
        public string Name;

        public Person(int a, string n) {
            this.Age = a;
            this.Name = n;
        }

        public int CompareTo(object obj) {
            var p2 = (Person)obj;
            if (this.Age > p2.Age)
                return (1);
            else if (this.Age < p2.Age)
                return (-1);
            else
                return (0);
        }

    }

    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        public int depth = 0;

        private void Form1_Load(object sender, EventArgs e) {
            int length = 10;
            Person[] persons = new Person[length];

            persons[0] = new Person(28, "Dirk");
            persons[1] = new Person(19, "Steven");
            persons[2] = new Person(20, "Luuk");
            persons[3] = new Person(20, "Joop");
            persons[4] = new Person(26, "Jan");
            persons[5] = new Person(17, "Klaas");
            persons[6] = new Person(23, "Gerard");
            persons[7] = new Person(21, "Tomas");
            persons[8] = new Person(19, "Lukas");
            persons[9] = new Person(24, "Johan");

            lbl_Input.Text = "QuickSort By Recursive Method";

            MergeSort_Recursive(persons, 0, length - 1);

            for (int i = 0; i < length; i++)
                lbl_Input.Text += "\n" + persons[i].Age;

        }

        static public void DoMerge(Person[] persons, int left, int mid, int right) {
            Person[] temp = new Person[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right)) {
                if (persons[left].CompareTo(persons[mid]) < 1)
                    temp[tmp_pos++] = new Person(persons[left++].Age, "");
                else
                    temp[tmp_pos++] = new Person(persons[mid++].Age, "");
            }

            while (left <= left_end)
                temp[tmp_pos++] = new Person(persons[left++].Age, "");

            while (mid <= right)
                temp[tmp_pos++] = new Person(persons[mid++].Age, "");

            for (i = 0; i < num_elements; i++) {
                persons[right] = new Person(temp[right].Age, "");
                right--;
            }
        }

        public void MergeSort_Recursive(Person[] persons, int left, int right) {

            if (right > left) {
                int mid = (right + left) / 2;
                MergeSort_Recursive(persons, left, mid);
                MergeSort_Recursive(persons, (mid + 1), right);

                DoMerge(persons, left, (mid + 1), right);
            }
        }
    }
}
