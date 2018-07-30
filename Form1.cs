using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taxikosten
{
    public partial class Form1 : Form
    {

        decimal inputOne;
        int arth_operator;
        


        public Form1()
        {

            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Text1_TextChanged(object sender, EventArgs e)
        {
           // per gereden km is gelijk aan 1 euro (double)

            double d1 = 1.0;
          
            
                    
            TextBox Text1 = new TextBox();
        

            if (!string.IsNullOrEmpty(Text1.Text) && !string.IsNullOrEmpty(Text2.Text))
                Text3.Text = (Convert.ToInt32(Text1.Text) + Convert.ToInt32(Text2.Text)).ToString();

             
        }

    


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // vrijdag 22:00 tot maandag 7:00  komt toeslag van 15% ( normaal bedrag 8 115%)

        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            //reset button

            Text1.Text = "";
            Text2.Text = "";
            Text3.Text = "";


            {
                void ResetAllControls(Control form)
                {
                    foreach (Control control in form.Controls)
                    {
                        if (control is TextBox);
                        {
                            TextBox textBox = (TextBox)control;
                            textBox.Text = null;
                        }
                    }
                }
            }
        }

        private void Text2_TextChanged(object sender, EventArgs e)
        {
            // per min gereden komt bedrag van 0.25 euro (double) 
            // per min gereden tussen 8:00 en 18:00 uur komt bedrag van 0.45 euro (double)

            double geredenkm = Convert.ToDouble(Text1.Text);
            double minuten = Convert.ToDouble(Text2.Text);
            DayOfWeek dag = dateTimePicker1.Value.DayOfWeek;
            TimeSpan tijd = dateTimePicker1.Value.TimeOfDay;
            int uur = tijd.Hours;
            int min= tijd.Minutes;

            double dagtoeslag = 0.25;
            double avondtoeslag = 0.45;
            double total = 0;

            if (uur > 8 && uur < 18)
            {
                total = minuten * dagtoeslag;
            }
            else
            {
                total = minuten * avondtoeslag;
            }

            total = total + geredenkm;

            bool isWeekend = (  dag.Equals(DayOfWeek.Friday) && uur >= 22) ||
                                dag.Equals(DayOfWeek.Saturday) ||
                                (dag.Equals(DayOfWeek.Monday) && uur <= 7);
            if (isWeekend)
            {
                total *= 1.15; // verhoog totaal met 15%
            }

            
            Text3.Text = Convert.ToString(total);
                
        }
       
    }
}

    

