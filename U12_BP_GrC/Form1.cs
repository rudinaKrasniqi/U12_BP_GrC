using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace U12_BP_GrC
{
    public partial class Form1 : Form
    {
        string tekstiIPerodruesit;
        public Form1()
        {
            InitializeComponent();
        }

        #region Eventet
        private void btnNrShkronja_Click(object sender, EventArgs e)
        {
            tekstiIPerodruesit = txtTeksti.Text;

            //Metoda 1
            MessageBox.Show("Shkronjat = " + 
                NrIShkronjaveNeTekst(tekstiIPerodruesit));


            //Metoda 2
            //int nrShkronja = NrIShkronjaveNeTekst(tekstiIPerodruesit);
            //MessageBox.Show("Shkronjat = " + nrShkronja);
        }

        private void btnNrNumrat_Click(object sender, EventArgs e)
        {
            tekstiIPerodruesit = txtTeksti.Text;
            MessageBox.Show("Numrat = " + 
                NrINumraveNeTekst(tekstiIPerodruesit));
        }

        private void btnNrUpper_Click(object sender, EventArgs e)
        {
            tekstiIPerodruesit = txtTeksti.Text;
            MessageBox.Show("SHkronja te medha = " +
                        NrIShkronjaveNeTekst(tekstiIPerodruesit));
        }

        private void btnNrLower_Click(object sender, EventArgs e)
        {
            tekstiIPerodruesit = txtTeksti.Text;
            int count;
            NrShkronjaveLower(tekstiIPerodruesit, out count);
            MessageBox.Show("Shkronja te vogla = " + count);
        }

        private void btnCapitalize_Click(object sender, EventArgs e)
        {
            tekstiIPerodruesit = txtTeksti.Text;
            txtTeksti.Text = CapitalizaeFirstWord(tekstiIPerodruesit);
        }

        private void btnKerko_Click(object sender, EventArgs e)
        {
            tekstiIPerodruesit = txtTeksti.Text;
            string fjala = txtWord.Text;
            if (DoesWordExist(tekstiIPerodruesit, fjala))
            {
                MessageBox.Show("Fjala ekziston");
            }
            else
            {
                MessageBox.Show("Fjala nuk ekziston");
            }
        }
        #endregion

        #region Metodat
        private int NrIShkronjaveNeTekst(string tekst)
        {
            int count = 0;
            for(int i=0; i< tekst.Length; i++)
            {
                if (Char.IsLetter(tekst[i]))
                    count++;
            }
            return count;
        }

        private int NrINumraveNeTekst(string tekst)
        {
            int count = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                if (Char.IsDigit(tekst[i]))
                    count++;
            }
            return count;
        }

        private int NrIShkronjaveUpper(string tekst)
        {
            int count = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                if (Char.IsUpper(tekst[i]))
                    count++;
            }
            return count;
        }
        //ref
        //out
        private void NrShkronjaveLower(string tekst, out int numri)
        {
            numri = 0;
            for (int i = 0; i < tekst.Length; i++)
            {
                if (Char.IsLower(tekst[i]))
                    numri++;
            }
        }

        private string CapitalizaeFirstWord(string tekst)
        {
            string firstLetter = tekst[0].ToString();
            string remainderLetter = tekst.Substring(1, tekst.Length - 1);
            return firstLetter.ToUpper() + remainderLetter.ToLower();
        }

        //Bazat e programimit 
        // pro
        private bool DoesWordExist(string text, string word)
        {
            Regex regex = new Regex(@"" + word);
            Match match = regex.Match(text);
            if(match.Success)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
