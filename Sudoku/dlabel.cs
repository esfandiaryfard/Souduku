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
    class dlabel
    {
        public Label[] label = new Label[19];
        public int id;
        public dlabel(int id,int x,int y,Form form)
        {
            id = id;
            initlabel(x,y,form);
        }
        public void initlabel(int x, int y,Form form)
        {
            
            for (int i = 0; i < 3; i++)
            {
             label[i] = new Label();
             label[i].Location = new Point(x+((i)) * 20, y);
             label[i].BackColor = Color.Red;
             label[i].Height = 19;
             label[i].Width = 19;
             form.Controls.Add(label[i]);

            }

        }

        public void text(int cnt,int ln)
        {
            
                label[ln].Text = cnt.ToString();
			 
		
            
        }

        public int sum(int i)
        {
            
            return int.Parse(label[i].Text) ;
            
        }
        public void clear()
        {
            for (int l = 0; l < 3; l++)
            {
                label[l].Text=string.Empty;
            }
        }

        public int sum1(int a)
        {

            for (int i = 0; i < 3; i++)
            {
                a += int.Parse(label[i].Text);

            }

            return a;
        }

    }
}
