using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;

namespace Sudoku
{
    class Square
    {
        public TextBox[] textbox = new TextBox[9];
        public int Id;
        int[] temp = new int[2];
        int[] temp1 = new int[2];
        bool gray = false;
        int[] en = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        int[] fill = new int[9];
        int[] view = new int[9];
        public Square(int id,int x, int y,Form form)
        {
            Id = id;
            inittextbox(x,y,form);
        }

        public void inittextbox(int x, int y,Form form)
        {
            
            for (int i = 0; i < 9; i++)
			{
                textbox[i]=new TextBox();
                textbox[i].Name = "textBox" + i.ToString();
                textbox[i].Height = 18;
                textbox[i].Width = 18;
                textbox[i].Location = new Point(x + ((i)%3)*20, y+((i)/3)*20);
                form.Controls.Add(textbox[i]);
			 
			}           
        }
        public void settextvalue(int[] value)
        {
            for (int j = 0; j < 9; j++)
            {

                fill[j] = value[j];
            }   
        }       
        public int [] show
        {
            get
			{
			    return fill; 
			}
            
        }
        public int[] existnumber()
        {
            
            
            for (int k = 0; k < 9; k++)
            {
                if (textbox[k].Text != "")
                {
                    textbox[k].BackColor = Color.LightGray;
                    textbox[k].Font = new Font(textbox[k].Font, FontStyle.Bold);
                    en[k] = int.Parse(textbox[k].Text);
                }
            }
            return en;
        }
        public int[] checkempty()
        {
            int[] emp = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };

            for (int k = 0; k < 9; k++)
            {
                if (textbox[k].Text !="")
                {
                    emp[k] = 1;
                }
            }
            return emp;

        }
        public void clear()
        {
            for (int l = 0; l < 9; l++)
            {
                textbox[l].Clear();
                textbox[l].BackColor = Color.White;
                textbox[l].Font = new Font(textbox[l].Font , FontStyle.Regular);           
            }
        }
        public int [] rullback()
        {

            for (int k = 0; k < 9; k++)
            {
                if (textbox[k].BackColor != Color.LightGray)
                {
                    textbox[k].Clear();
                }
             }
            existnumber();
                    return en;
         }

        public void text(int[] txt)
        {
            for (int i = 0; i < 9; i++)
            {
                textbox[i].Text = txt[i].ToString();
            }
        }

            }
}
