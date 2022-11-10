using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace du_vyjimky_priklad2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                int vysledeksoucinu = 1;
                int convertcislo = 0;
                StreamReader cteni = new StreamReader(@"../../cisla.txt");
                while (!cteni.EndOfStream) {
                    checked
                   {
                        string cislo = cteni.ReadLine();
                        convertcislo = int.Parse(cislo);
                        listBox1.Items.Add(cislo);
                   }
                    vysledeksoucinu *= convertcislo;
                }
                cteni.Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("V souboru je špatný formát, zadej jen číslo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Moc velké číslo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor nebyl nalezen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nastala tato chyba: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Úspěšně či neúspěšně, to je jedno! Gratuluji, jste na konci :)", "Konec", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
