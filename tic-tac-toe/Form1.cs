using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tic_tac_toe
{
    public partial class Form1 : Form
    {
        bool trun = true;
        int turn_count = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Founder of Muhammad Zubair Moosani", "Tic Tac Tio About");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (trun) { b.Text = "X"; }
            else { b.Text = "O"; }
            trun = !trun;
            b.Enabled = false;
            turn_count++;
            checkForWinner();
        }

        private void checkForWinner()
        {
            //horizontal checks
            bool there_is_a_winner = false;
            if (A1.Text == A2.Text && A2.Text == A3.Text && !A1.Enabled) { there_is_a_winner = true; }
            else if (B1.Text == B2.Text && B2.Text == B3.Text && !B1.Enabled) { there_is_a_winner = true; }
            else if (C1.Text == C2.Text && C2.Text == C3.Text && !C1.Enabled) { there_is_a_winner = true; }

            //vertical checks
            else if (A1.Text == B1.Text && B1.Text == C1.Text && !A1.Enabled) { there_is_a_winner = true; }

            else if (A2.Text == B2.Text && B2.Text == C2.Text && !A2.Enabled) { there_is_a_winner = true; }

            else if (A3.Text == B3.Text && B3.Text == C3.Text && !A3.Enabled) { there_is_a_winner = true; }

            //diagocal checks
            else if (A1.Text == B2.Text && B2.Text == C3.Text && !A1.Enabled) { there_is_a_winner = true; }
            else if (A3.Text == B2.Text && B2.Text == C1.Text && !C1.Enabled) { there_is_a_winner = true; }

            if (there_is_a_winner)
            {
                disableButtons();
                string winner = "";
                if (trun) { winner = "O"; }
                else { winner = "X"; }
                MessageBox.Show(winner + " Win!", "Yay!");
            }
            else
            {
                if (turn_count == 9) { MessageBox.Show("Draw!", "Bummer!"); }
            }
        }

        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            trun = true;
            turn_count = 0;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch { }
        }
    }
}
