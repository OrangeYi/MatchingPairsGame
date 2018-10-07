using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatchingPairsGame
{
    public partial class Form1 : Form
    {
        Label firstClicked = null;
        Label secondClicked = null;
        Random random = new Random();
        List<string> icons = new List<string>()
        {
            "!","!","@","@","#","#","1","1",
            "A","A","B","B","C","C","*","*"
        };
        public Form1()
        {
            InitializeComponent();
            AssignIconsToSquares();
        }
        private void AssignIconsToSquares()
        {
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if(iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    icons.RemoveAt(randomNumber);
                    iconLabel.ForeColor = iconLabel.BackColor;
                }
            }
        }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label_click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true) return;
            //sender is the label
            Label clickedLabel = sender as Label;
            if(clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black) return;
                //clickedLabel.ForeColor = Color.Black;
                if(firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    firstClicked.ForeColor = Color.Black;
                    return;
                }
                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;
                ChickWinner();
                if (firstClicked.Text == secondClicked.Text)
                {
                    firstClicked = null;
                    secondClicked = null;
                    return;
                }
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;
            firstClicked = null;
            secondClicked = null;
        }
        private void ChickWinner()
        {
            foreach(Control control in tableLayoutPanel1.Controls)
            {
                Label iconlabel = control as Label;
                if(iconlabel != null)
                {
                    if(iconlabel.ForeColor == iconlabel.BackColor)
                    {
                        return;
                    }
                }
            }
            MessageBox.Show("You matched all the icons!", "Congratulations and well done!");
            Close();
        }
    }
}
