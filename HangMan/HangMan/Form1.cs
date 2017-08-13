using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace HangMan
{
   
    public partial class Form1 : Form
    {
        string Word;
        List<Label> Labels = new List<Label>();
        int amount=0;
        public Form1()
        {
            InitializeComponent();
          
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        enum Body
        {
            Head,Left_eye,Right_eye,Mouth,Right_arm,Left_arm,Body,Right_leg,Left_leg
        };
        string GetrandomWord()
        {
            WebClient wc = new WebClient();
            string words ;//= wc.DownloadString("http://www-01.sil.org/linguistics/wordlists/english/wordlist/wordsEn.txt");
            words = "apple "; 
            string[] WordList = words.Split('\n');
            Random r = new Random();
            int Val = r.Next(0, WordList.Length-1);

            return WordList[Val];

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();       //Instantiaing graphics object for drawing hangman
            Pen p = new Pen(Color.Brown, 10);               //SInce we are drawing Lines so Pen
            /**
             * Simple Coordinates of Lines
             * to Draw Hang
             * */
            g.DrawLine(p, new Point(174, 260), new Point(174, 20));
            g.DrawLine(p, new Point(179, 20), new Point(90, 20));
            g.DrawLine(p, new Point(90, 15), new Point(90, 80));
           /* DrawBodyParts(Body.Head);
            DrawBodyParts(Body.Left_eye);
            DrawBodyParts(Body.Right_eye);
            DrawBodyParts(Body.Mouth);
            DrawBodyParts(Body.Body);
            DrawBodyParts(Body.Right_arm);
            DrawBodyParts(Body.Left_arm);
            DrawBodyParts(Body.Left_leg);
            DrawBodyParts(Body.Right_leg); */
            //MessageBox.Show(GetrandomWord());
            MakeLabel();
        }
        void MakeLabel()
        {
            Word = GetrandomWord(); //Getting the list of words
            textBox2.MaxLength = Word.Length;
            char[] array=Word.ToCharArray();    //Converting to Character Array
            int between = ((groupBox2.Width-6)/array.Length)-1; //For spacing between the labels

            for (int i = 0; i < array.Length - 1; i++)      //Adding to label list so that we can put them and identify them
            {
                Labels.Add(new Label());                    //Adding new Label Object to the List for each character
                Labels[i].Location = new Point(i*between+10,80); //Putting the labels in equally spaced position
                Labels[i].Text = "_";                       //So that it looks Dash in the starting
                Labels[i].Parent = groupBox2;               //Putting the correct position of the label
                Labels[i].BringToFront();                   //Brings control to the front(Frame layout android)
                Labels[i].CreateControl();                  //Creates Control
            }
            label1.Text += " : "+(Word.Length - 1).ToString();
        }
        void DrawBodyParts(Body bp)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black,2);
            if (bp == Body.Head)
            {
                g.DrawEllipse(p,70,79,40,40);
            }
            else if (bp == Body.Left_eye)
            {
                SolidBrush s = new SolidBrush(Color.Brown);
                g.FillEllipse(s, 77, 90, 8, 4);
            }
            else if (bp == Body.Right_eye)
            {
                SolidBrush s = new SolidBrush(Color.Brown);
                g.FillEllipse(s, 95, 90, 8, 4);    
            }
            else if (bp == Body.Mouth)
            {
               //g.DrawArc(
                g.DrawArc(p, 77, 90, 25, 20, 0, 180);
            }
            else if (bp == Body.Body)
            {
                g.DrawLine(p, 90, 120, 90, 180);
            }
            else if (bp == Body.Right_arm)
            {
                g.DrawLine(p, 90, 140, 130, 100);
            }
            else if (bp == Body.Left_arm)
            {
                g.DrawLine(p, 90, 140, 50, 100);
            }
            else if (bp == Body.Left_leg)
            {
                g.DrawLine(p, 90, 180, 50, 210);
            }
            else if (bp == Body.Right_leg)
            {
                g.DrawLine(p, 90, 180, 130, 210);
            }
        }
        public void ResetGame()
        {
            Graphics gt = panel1.CreateGraphics();
            gt.Clear(Color.FromKnownColor(KnownColor.Control));
            Graphics g = panel1.CreateGraphics();       //Instantiaing graphics object for drawing hangman
            Pen p = new Pen(Color.Brown, 10);               //SInce we are drawing Lines so Pen
            /**
             * Simple Coordinates of Lines
             * to Draw Hang
             * */
            label1.Text = "Word Length";
            label2.Text = "Missed letters :";
            g.DrawLine(p, new Point(174, 260), new Point(174, 20));
            g.DrawLine(p, new Point(179, 20), new Point(90, 20));
            g.DrawLine(p, new Point(90, 15), new Point(90, 80));
            /* DrawBodyParts(Body.Head);
             DrawBodyParts(Body.Left_eye);
             DrawBodyParts(Body.Right_eye);
             DrawBodyParts(Body.Mouth);
             DrawBodyParts(Body.Body);
             DrawBodyParts(Body.Right_arm);
             DrawBodyParts(Body.Left_arm);
             DrawBodyParts(Body.Left_leg);
             DrawBodyParts(Body.Right_leg); */
            //MessageBox.Show(GetrandomWord());
            MakeLabel();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            char letter = Convert.ToChar(textBox1.Text.ToLower());      //Convert string entered into Character
            if (char.IsLetter(letter))
            {
                if (Word.Contains(letter))
                {
                    char[] arr = Word.ToCharArray();

                    for (int i = 0; i < Word.Length; i++)
                    {
                        if (arr[i] == letter)
                            Labels[i].Text = letter.ToString();
                    }
                    bool won = true;
                    foreach (Label l in Labels)
                    {
                        if (l.Text == "_")
                        {
                            won = false;
                            break;
                        }
                    }
                    if (won)
                    {
                        MessageBox.Show("You Won");
                        ResetGame();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry letter not present");
                    label2.Text += " "+ letter.ToString()+",";
                    DrawBodyParts((Body)amount);
                    amount++;
                    if (amount >= 9)
                    {
                        MessageBox.Show("You lost","Sorry",MessageBoxButtons.AbortRetryIgnore,MessageBoxIcon.Exclamation);
                        ResetGame();
                    }
                }
            }
            else {
                MessageBox.Show("You must enter a Letter","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(Word))
            {
                int i = 0;
                foreach (char c in Word)
                {
                    Labels[i++].Text = c.ToString();
                }
                MessageBox.Show("You Won");
                ResetGame();
            }
            else {
                
                MessageBox.Show("The Word that you Wrote is wrong");
                DrawBodyParts((Body)amount);
                amount++;
                if (amount >= 9)
                {
                    MessageBox.Show("You lost", "Sorry", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Exclamation);
                    ResetGame();
                }
            }
        }
    }
}
