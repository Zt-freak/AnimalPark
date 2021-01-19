using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimalPark
{
    public partial class Form : System.Windows.Forms.Form
    {
        private List<Visitor> visitors = new List<Visitor>();
        public Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.visitors.Add(new Visitor(this.textBox1.Text, this.dateTimePicker1.Value));
            this.dataGridView1.Rows.Add(this.textBox1.Text, this.dateTimePicker1.Value);
            this.updateSub();
        }

        private void updateSub()
        {
            this.dataGridView2.Rows.Clear();
            this.dataGridView2.Rows.Add();

            DateTime today = DateTime.Today;
            int adultCount = 0;
            int childCount = 0;
            foreach (Visitor visitor in this.visitors)
            {
                int age = (new DateTime(1, 1, 1) - (today - visitor.birthday)).Year - 1;
                Console.WriteLine(age);
                if (age > 18)
                {
                    adultCount++;
                }
                else
                {
                    childCount++;
                }
            }
            this.dataGridView2.Rows.Add("No. of adults", adultCount);
            this.dataGridView2.Rows.Add("No. of children", childCount);
            if (adultCount == 2 && childCount == 0)
            {
                this.dataGridView2.Rows.Add("cost", 61);
            }
            else if (adultCount == 2 && childCount > 0)
            {
                if (childCount == 1)
                {
                    this.dataGridView2.Rows.Add("cost", 71);
                }
                else if(childCount == 2)
                {
                    this.dataGridView2.Rows.Add("cost", 82);
                }
                else
                {
                    this.dataGridView2.Rows.Add("cost", 82+(childCount-2)*11);
                }
            }
            else if(adultCount == 2 && childCount == 2)
            {
                this.dataGridView2.Rows.Add("cost", 82);
            }
            else if(adultCount == 1 && childCount == 0 && (new DateTime(1, 1, 1) - (today - visitors[0].birthday)).Year - 1 < 65)
            {
                this.dataGridView2.Rows.Add("cost", 30);
            }
            else if (adultCount == 1 && childCount == 0 && (new DateTime(1, 1, 1) - (today - visitors[0].birthday)).Year - 1 > 65)
            {
                this.dataGridView2.Rows.Add("cost", 26);
            }
            else if (adultCount == 2 && childCount == 0 && (new DateTime(1, 1, 1) - (today - visitors[0].birthday)).Year - 1 > 65 && (new DateTime(1, 1, 1) - (today - visitors[2].birthday)).Year - 1 > 65)
            {
                this.dataGridView2.Rows.Add("cost", 65);
            }
            else
            {
                this.dataGridView2.Rows.Add("cost", adultCount*30+childCount*11);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = this.dataGridView1.CurrentCell.RowIndex;

            this.dataGridView1.Rows.RemoveAt(index);
            this.visitors.RemoveAt(index);
            this.updateSub();
        }
    }

    public class Visitor
    {
        public string name;
        public DateTime birthday;

        public Visitor(string name, DateTime birthday) {
            this.name = name;
            this.birthday = birthday;
        }
    }
}
