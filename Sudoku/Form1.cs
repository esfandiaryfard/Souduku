using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sudoku
{
    public partial class Form1 : Form
    {
        Square s1, s2, s3, s4, s5, s6, s7, s8, s9;
        int[] save = new int[82];
        Label sumlbl = new Label();
        int[,] str = new int[100, 82];
        int[,] str1 = new int[100, 82];
        int[,] str2 = new int[50, 82];
        int[,] str3 = new int[25, 82];
        int[,] str4 = new int[25, 82];
        int[,] str5 = new int[100, 82];
        //
        int[,] str6 = new int[3, 82];
        int[,] str7 = new int[2, 82];
        int[,] str8 = new int[1, 82];
        int h = 0, sum = 0, min = 0, counter = 0, a = 0, f = 0, k = 0, cnt = 0, m=0,n=9,d=9,dsum=0,rsum=0,co=0,t=0;
        int[] one = new int[9];
        int[] two = new int[9];
        int[] three = new int[9];
        int[] four = new int[9];
        int[] five = new int[9];
        int[] six = new int[9];
        int[] seven = new int[9];
        int[] eight = new int[9];
        int[] nine = new int[9];
        int[] aa = new int[9];
        int[] b = new int[9];
        int[] temp1Arr = new int[82];
        int[] temp2Arr = new int[82];
        bool[] remove = new  bool[100];
        bool[] remove1 = new bool [25];
        //
        bool[] remove3 = new[]  { true, true, true, true, true, true, true, true, true, true,true, true};  
        bool[]remove4= new []{ true, true, true, true, true, true};
        bool[] lost = new bool[9];
        int[] ch1 = new int[9];
        int[] del = new int[81];
        public Form1()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(220, 290);
            button1.Location = new Point(9, 215);
            button2.Location = new Point(139, 215);
            s1 = new Square(1, 10, 10, this);
            s2 = new Square(2, 75, 10, this);
            s3 = new Square(3, 140, 10, this);
            //--------------ENDOF Line 1--------------
            s4 = new Square(4, 10, 80, this);
            s5 = new Square(5, 75, 80, this);
            s6 = new Square(6, 140, 80, this);
            //-------------ENDOF Line 2---------------
            s7 = new Square(7, 10, 150, this);
            s8 = new Square(8, 75, 150, this);
            s9 = new Square(9, 140, 150, this);
            
        }
        Random rand = new Random();
        private int[] next(int[] filed = null)
        {
            int myrand = 0;
            bool[] rnd = new[] { true, true, true, true, true, true, true, true, true };
            int[] num = new int[9];

            for (int i = 0; i < 9; i++)
            {
                if (filed[i] != -1)
                {
                    rnd[filed[i] - 1] = false;
                }
            }
            for (int j = 9; j > 0; j--)
            {
                if (filed[9 - j] == -1)
                {
                    myrand = rand.Next(1, j + 1);
                    if (!rnd[myrand - 1])
                    {
                        for (int k = myrand + 1; k <= 9; k++)
                        {
                            if (rnd[k - 1])
                            { num[9 - j] = k; rnd[k - 1] = false; break; }
                        }
                    }
                    else
                    {
                        num[9 - j] = myrand;
                        rnd[myrand - 1] = false;
                    }
                }
                else
                {
                    num[9 - j] = filed[9 - j];
                }
            }
            return num;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            s1.settextvalue(empt(s1.checkempty()));
            s2.settextvalue(empt(s2.checkempty()));
            s3.settextvalue(empt(s3.checkempty()));
            s4.settextvalue(empt(s4.checkempty()));
            s5.settextvalue(empt(s5.checkempty()));
            s6.settextvalue(empt(s6.checkempty()));
            s7.settextvalue(empt(s7.checkempty()));
            s8.settextvalue(empt(s8.checkempty()));
            s9.settextvalue(empt(s9.checkempty()));
            for (int j = 0; j < 3; j++)
              {
                del[j] = s1.show[j];
              }
            for (int j = 9; j < 12; j++)
            {
                del[j] = s1.show[j - 6];
            }
            for (int j = 18; j < 21; j++)
            {
                del[j] = s1.show[j - 12];
            }
            
            for (int j = 3; j < 6; j++)
            {
                del[j] = s2.show[j - 3];
            }
            for (int j = 12; j < 15; j++)
            {
                del[j] = s2.show[j - 9];
            }
            for (int j = 21; j < 24; j++)
            {
                del[j] = s2.show[j - 15];
            }
            for (int j = 6; j < 9; j++)
            {
                del[j] = s3.show[j - 6];
            }
            for (int j = 15; j < 18; j++)
            {
                del[j] = s3.show[j - 12];
            }
            for (int j = 24; j < 27; j++)
            {
                del[j] = s3.show[j - 18];
            }
            for (int j = 27; j < 30; j++)
            {
                del[j] = s4.show[j - 27];
            }
            for (int j = 36; j < 39; j++)
            {
                del[j] = s4.show[j - 33];
            }
            for (int j = 45; j < 48; j++)
            {
                del[j] = s4.show[j - 39];
            }
            for (int j = 30; j < 33; j++)
            {
                del[j] = s5.show[j - 30];
            }
            for (int j = 39; j < 42; j++)
            {
                del[j] = s5.show[j - 36];
            }
            for (int j = 48; j < 51; j++)
            {
                del[j] = s5.show[j - 42];
            }
            for (int j = 33; j < 36; j++)
            {
                del[j] = s6.show[j - 33];
            }
            for (int j = 42; j < 45; j++)
            {
                del[j] = s6.show[j - 39];
            }
            for (int j = 51; j < 54; j++)
            {
                del[j] = s6.show[j - 45];
            }
            for (int j = 54; j < 57; j++)
            {
                del[j] = s7.show[j - 54];
            }
            for (int j = 63; j < 66; j++)
            {
                del[j] = s7.show[j - 60];
            }
            for (int j = 72; j < 75; j++)
            {
                del[j] = s7.show[j - 66];
            }
            for (int j = 57; j < 60; j++)
            {
                del[j] = s8.show[j - 57];
            }
            for (int j = 66; j < 69; j++)
            {
                del[j] = s8.show[j - 63];
            }
            for (int j = 75; j < 78; j++)
            {
                del[j] = s8.show[j - 69];
            }
            for (int j = 60; j < 63; j++)
            {
                del[j] = s9.show[j - 60];
            }
            for (int j = 69; j < 72; j++)
            {
                del[j] = s9.show[j - 66];
            }
            for (int j = 78; j < 81; j++)
            {
                del[j] = s9.show[j - 72];
            }
            //
            s1.settextvalue(next(s1.existnumber()));

            for (int i = 0; i < 9; i++)
            {
                one[i] = s1.show[i];
            }
            s2.settextvalue(next(s2.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                two[i] = s2.show[i];
            }
            s3.settextvalue(next(s3.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                three[i] = s3.show[i];
            }
            s4.settextvalue(next(s4.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                four[i] = s4.show[i];

            }
            s5.settextvalue(next(s5.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                five[i] = s5.show[i];

            }
            s6.settextvalue(next(s6.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                six[i] = s6.show[i];

            }
            s7.settextvalue(next(s7.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                seven[i] = s7.show[i];

            }
            s8.settextvalue(next(s8.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                eight[i] = s8.show[i];

            }
            s9.settextvalue(next(s9.existnumber()));
            for (int i = 0; i < 9; i++)
            {
                nine[i] = s9.show[i];

            }
            sarray();
            sort();
         while (str1[0, 81] != 0 )
           {
              
             a = 0;
             k = 0;
             t++;
             bestfifty();         
          }
         for (int j = 0; j < 3; j++)
         {
             one[j]=str1[0,j];
         }
         for (int j = 9; j < 12; j++)
         {
             one[j - 6] = str1[0, j];
         }
         for (int j = 18; j < 21; j++)
         {
             one[j - 12] = str1[0, j];
         }
         //
         for (int j = 3; j < 6; j++)
         {
             two[j - 3] = str1[0, j];
         }
         for (int j = 12; j < 15; j++)
         {
             two[j - 9] = str1[0, j];
         }
         for (int j = 21; j < 24; j++)
         {
             two[j - 15] = str1[0, j];
         }
            //
         for (int j = 6; j < 9; j++)
         {
             three[j - 6] = str1[0, j];
         }
         for (int j = 15; j < 18; j++)
         {
             three[j - 12] = str1[0, j];
         }
         for (int j = 24; j < 27; j++)
         {
             three[j - 18] = str1[0, j];
         }
            //
         for (int j = 27; j < 30; j++)
         {
             four[j - 27] = str1[0, j];
         }
         for (int j = 36; j < 39; j++)
         {
             four[j - 33] = str1[0, j];
         }
         for (int j = 45; j < 48; j++)
         {
             four[j - 39] = str1[0, j];
         }
            //
         for (int j = 30; j < 33; j++)
         {
             five[j - 30] = str1[0, j];
         }
         for (int j = 39; j < 42; j++)
         {
             five[j - 36] = str1[0, j];
         }
         for (int j = 48; j < 51; j++)
         {
             five[j - 42] = str1[0, j];
         }
            //
         for (int j = 33; j < 36; j++)
         {
             six[j - 33] = str1[0, j];
         }
         for (int j = 42; j < 45; j++)
         {
             six[j - 39] = str1[0, j];
         }
         for (int j = 51; j < 54; j++)
         {
             six[j - 45] = str1[0, j];
         }
            //
         for (int j = 54; j < 57; j++)
         {
             seven[j - 54] = str1[0, j];
         }
         for (int j = 63; j < 66; j++)
         {
             seven[j - 60] = str1[0, j];
         }
         for (int j = 72; j < 75; j++)
         {
             seven[j - 66] = str1[0, j];
         }
            //
         for (int j = 57; j < 60; j++)
         {
             eight[j - 57] = str1[0, j];
         }
         for (int j = 66; j < 69; j++)
         {
             eight[j - 63] = str1[0, j];
         }
         for (int j = 75; j < 78; j++)
         {
             eight[j - 69] = str1[0, j];
         }
         for (int j = 60; j < 63; j++)
         {
             nine[j - 60] = str1[0, j];
         }
         for (int j = 69; j < 72; j++)
         {
             nine[j - 66] = str1[0, j];
         }
         for (int j = 78; j < 81; j++)
         {
             nine[j - 72] = str1[0, j];
         }
         s1.text(one);
         s2.text(two);
         s3.text(three);
         s4.text(four);
         s5.text(five);
         s6.text(six);
         s7.text(seven);
         s8.text(eight);
         s9.text(nine);
         MessageBox.Show(t.ToString());      
         }
        private void sarray()
        {
            int tsum = 0;  
            for (int j = 0; j < 3; j++)
            {
                save[j] = one[j];
            }
            for (int j = 9; j < 12; j++)
            {
                save[j] = one[j-6];
            }
            for (int j = 18; j < 21; j++)
            {
                save[j] = one[j-12];
            }
            for (int j = 3; j <6; j++)
            {
                save[j] = two[j-3];
            }
            for (int j =12; j < 15; j++)
            {
                save[j] = two[j-9];
            }
            for (int j = 21; j < 24; j++)
            {
                save[j] = two[j-15];
            }
            for (int j = 6; j < 9; j++)
            {
                save[j] = three[j-6];
            }
            for (int j = 15; j < 18; j++)
            {
                save[j] = three[j-12];
            }
            for (int j = 24; j < 27; j++)
            {
                save[j] = three[j-18];
            }
            for (int j = 27; j < 30; j++)
            {
                save[j] = four[j-27];
            }
            for (int j = 36; j < 39; j++)
            {
                save[j] = four[j-33];
            }
            for (int j = 45; j < 48; j++)
            {
                save[j] = four[j-39];
            }
            for (int j = 30; j < 33; j++)
            {
                save[j] = five[j-30];
            }
            for (int j = 39; j < 42; j++)
            {
                save[j] = five[j-36];
            }
            for (int j = 48; j < 51; j++)
            {
                save[j] = five[j-42];
            }
            for (int j = 33; j < 36; j++)
            {
                save[j] = six[j-33];
            }
            for (int j = 42; j < 45; j++)
            {
                save[j] = six[j-39];
            }
            for (int j = 51; j < 54; j++)
            {
                save[j] = six[j-45];
            }
            for (int j = 54; j < 57; j++)
            {
                save[j] = seven[j-54];
            }
            for (int j = 63; j < 66; j++)
            {
                save[j] = seven[j-60];
            }
            for (int j = 72; j < 75; j++)
            {
                save[j] = seven[j-66];
            }
            for (int j = 57; j < 60; j++)
            {
                save[j] = eight[j-57];
            }
            for (int j = 66; j < 69; j++)
            {
                save[j] = eight[j-63];
            }
            for (int j = 75; j < 78; j++)
            {
                save[j] = eight[j-69];
            }
            for (int j = 60; j < 63; j++)
            {
                save[j] = nine[j-60];
            }
            for (int j = 69; j < 72; j++)
            {
                save[j] = nine[j-66];
            }
            for (int j = 78; j < 81; j++)
            {
                save[j] = nine[j-72];
            }
            initlbl();
            lbl1();
            tsum = sum + dsum;
                for (int l = 0; l < 81; l++)
                {
                        str[k, l] = save[l];
                }
           str[k,81]=tsum;   
        while (k < 99)
            {
                k++;
                rullback();
                sarray();
            }
        }
        private void sort()
        {
            for (int i = 0; i < 100; i++)
            {
                remove[i] = true;
            }
            int a = 0, temp1 = 0,b=0;
            int cnt = 0;
        step1:
            for (int i = 0; i < 99; i++)
            {
                if (remove[i] != false)
                {
                    temp1 = str[i,81];
                    b = i;
                    break;
                }
            }
            for (int j = 0; j < 99; j++)
            {
                if (remove[j + 1] != false)
                {
                    int temp2 = str[j + 1, 81];
                    if (temp1 > temp2 || temp1 == temp2)
                    {
                        temp1 = temp2;
                        a = j + 1;
                    }
                }
            }
            if (!remove[a])
            {
                a = b;
            }
            remove[a] = false;
                for (int j = 0; j < 82; j++)
                {
                    str1[cnt, j] = str[a, j];
                }
                cnt++;
                if (cnt<100)
                {
                    goto step1;    
                }
                bestfifty();
        }
        private void bestfifty()
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 82; j++)
			{
                str2[i, j] = str1[i, j];
			}
            }
            k = 0;
            crossover();     
        }    
        private void crossover()
        {
            while (k < 25)
            {
            for (int i = 0; i < 82; i++)
            {
                temp1Arr[i] = str2[a, i];
                temp2Arr[i] = str2[a + 1, i];
            }
            min = temp1Arr[81];
            //two minimum fitness has found and two first answer with least fitneess has choosen
          
            while (counter < 9)
            {
                for (int j = 0+f*3; j < 3+f*3; j++)
                {
                    temp1Arr[j] = temp2Arr[j];
                    temp1Arr[j + 9] = temp2Arr[j + 9];
                    temp1Arr[j + 18] = temp2Arr[j + 18];
                }
                //replace first squre of temp2 into temp1
                int tsum = 0;
                chk();
                dchk();
                tsum = dsum + sum;
                if (tsum > min)
                //min is equal to least fitness of 100 try for first search
                {
                    for (int j = 0 + f * 3; j < 3 + f * 3; j++)
                    {
                        temp1Arr[j] = str2[a, j];
                        temp1Arr[j + 9] = str2[a, j + 9];
                        temp1Arr[j + 18] = str2[a, j + 18];
                        chk();
                        dchk();
                        tsum = dsum + sum;
                    }
                    f++;
                    counter++;
                    if (counter == 2)
                    {
                        f = 8;
                    }
                    if (counter == 5)
                    {
                        f = 17;
                    }
                }
                else
                {
                    min = tsum;
                    f++;
                    counter++;
                }
            }
            for (int i = 0; i < 81; i++)
            {
                str3[k, i] = temp1Arr[i];
            }
            str3[k, 81] = min;
            k++;
            if (a<48)
            {
                a += 2;
            }
        }
            
            mutation();
        }
        private void dchk()
        {
            dsum = 0;
            ch1 = new int[9];
            int a = 0;
            int n = 1;
            int b = 0;
            cnt = 0;
            while (b < 9)
            {
                bool[] lost = new[] { true, true, true, true, true, true, true, true, true };
                while (n < 10)
                {
                    for (int i = 0 + b; i < 73 + b; i += 9)
                    {
                        if (temp1Arr[i] == n)
                        {
                            lost[n - 1] = false;
                            break;
                        }

                    }
                    n++;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (lost[j])
                    {
                        cnt++;
                    }
                }
                ch1[a] = cnt;
                a++;
                b++;
                n = 1;
                cnt = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                dsum = dsum + ch1[i];
            }
        }
        private void chk()
        {
            sum = 0;
            int a = 0;
            int[] ch = new int[9];
            int n = 1;
            int b = 0;
            while (b < 81)
            {
                for (int i = 0; i < 9; i++)
                {
                    lost[i] = true;
                }
                while (n < 10)
                {
                    for (int i = 0 + b; i < 9 + b; i++)
                    {
                        if (temp1Arr[i] == n)
                        {
                            lost[n - 1] = false;
                            break;
                        }

                    }
                    n++;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (lost[j])
                    {
                        cnt++;
                    }
                }
                ch[a] = cnt;
                a++;
                b += 9;
                n = 1;
                cnt = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                sum = sum + ch[i];
            }
        }
        private void mutation()
        {
            int tsum = 0;
            f = 0;
            counter = 0;
            k = 0;
            int ch = 0;
            int step = 9;
            while (k < 25)
            {
                while (ch < 9)
                {
                    if (del[ch] == 0 && del[ch+9]==9)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch++;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch++;
                        }
                    }
                    else
                    {
                        if (ch < 9)
                            ch++;

                    }
                }
                //

                ch = 0;
                step = 18;
            step0:

                while (ch < 9)
                {
                    if (del[ch] == 0 && del[ch+18]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch++;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch++;
                        }
                    }
                    else
                    {
                        if (ch < 9)
                            ch++;
                    }
                }
            //
            ch = 9;
            step = 9;
                while (ch < 18)
                {
                    if (del[ch] == 0 && del[ch+9]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch++;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch++;
                        }
                    }
                    else
                    {
                        if (ch < 18)
                            ch++;
                    }
                }    
                ch = 27;
                while (ch < 36)
                {
                    if (del[ch] == 0 && del[ch+9]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (sum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            sum = sum + dsum;
                            ch++;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch++;
                        }
                    }
                    else
                    {
                        ch++;
                    }
                }
                ch = 27;
                step = 18;
            step2:
                while (ch < 36)
                {
                    if (del[ch] == 0 && del[ch+18]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            sum = sum + dsum;
                            ch++;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch++;
                        }
                    }
                    else
                    {
                        ch++;
                    }
                }
            ch = 36;
            step = 9;
            while (ch < 45)
            {
                if (del[ch] == 0 && del[ch+9]==0)
                {
                    int temp = 0;
                    temp = str3[k, ch];
                    str3[k, ch] = str3[k, ch + step];
                    str3[k, ch + step] = temp;
                    check();
                    dcheck();
                    tsum = sum + dsum;
                    if (tsum > str3[k, 81])
                    {
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        sum = sum + dsum;
                        ch++;
                    }
                    else
                    {
                        str3[k, 81] = tsum;
                        ch++;
                    }
                }
                else
                {
                    ch++;
                }
            }
                ch = 54;
                step = 9;
                while (ch < 63)
                {
                    if (del[ch] == 0 && del[ch+9]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (sum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch++;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch++;
                        }
                    }
                    else
                    {
                        ch++;
                    }
                }
                ch = 54;
                step = 18;
            step4:
                while (ch < 63)
                {
                    if (del[ch] == 0 && del[ch+18]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch++;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch++;
                        }
                    }
                    else
                    {
                        ch++;
                    }
                }
                /////////////////////////////////
            ch = 63;
            step = 9;
            while (ch < 72)
            {
                if (del[ch] == 0 && del[ch+9]==0)
                {
                    int temp = 0;
                    temp = str3[k, ch];
                    str3[k, ch] = str3[k, ch + step];
                    str3[k, ch + step] = temp;
                    check();
                    dcheck();
                    tsum = sum + dsum;
                    if (tsum > str3[k, 81])
                    {
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        ch++;
                    }
                    else
                    {
                        str3[k, 81] = tsum;
                        ch++;
                    }
                }
                else
                {
                    ch++;
                }
            }
                ch = 0;
                step = 1;
                while (ch < 73)
                {
                    if (del[ch] == 0 && del[ch+1]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (sum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch += 9;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch += 9;
                        }
                    }
                    else
                    {
                        ch+=9;
                    }
                }
                ch = 0;
                step = 2;
                while (ch < 73)
                {
                    if (del[ch] == 0 && del[ch+2]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch += 9;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch += 9;
                        }
                    }
                    else
                    {
                        ch += 9;
                    }
                }
                    ch = 1;
                    step = 1;
                    while (ch < 74)
                    {
                        if (del[ch] == 0 && del[ch+1]==0)
                        {
                            int temp = 0;
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            if (tsum > str3[k, 81])
                            {
                                temp = str3[k, ch];
                                str3[k, ch] = str3[k, ch + step];
                                str3[k, ch + step] = temp;
                                check();
                                dcheck();
                                tsum = sum + dsum;
                                ch += 9;
                            }
                            else
                            {
                                str3[k, 81] = tsum;
                                ch += 9;
                            }
                        }
                        else
                        {
                            ch += 9;
                        }
                    }
                ch = 3;
                while (ch < 76)
                {
                    if (del[ch] == 0 && del[ch+1]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch += 9;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch += 9;
                        }
                    }
                    else
                    {
                        ch += 9;
                    }
                }
                ch = 3;
                step = 2;
                while (ch < 76)
                {
                    if (del[ch] == 0 && del[ch+2]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch += 9;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch += 9;
                        }
                    }
                    else
                    {
                        ch += 9;
                    }
                }
                    ch = 4;
                    step = 1;
                    while (ch < 77)
                    {
                        if (del[ch] == 0 && del[ch+1]==0)
                        {
                            int temp = 0;
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            if (tsum > str3[k, 81])
                            {
                                temp = str3[k, ch];
                                str3[k, ch] = str3[k, ch + step];
                                str3[k, ch + step] = temp;
                                check();
                                dcheck();
                                tsum = sum + dsum;
                                ch += 9;
                            }
                            else
                            {
                                str3[k, 81] = tsum;
                                ch += 9;
                            }
                        }
                        else
                        {
                            ch += 9;
                        }
                    }
                ch = 6;
                while (ch < 79)
                {
                    if (del[ch] == 0 && del[ch+1]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch += 9;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch += 9;
                        }
                    }
                    else
                    {
                        ch += 9;
                    }
                }
                ch = 6;
                step = 2;
                while (ch < 79)
                {
                    if (del[ch] == 0 && del[ch+2]==0)
                    {
                        int temp = 0;
                        temp = str3[k, ch];
                        str3[k, ch] = str3[k, ch + step];
                        str3[k, ch + step] = temp;
                        check();
                        dcheck();
                        tsum = sum + dsum;
                        if (tsum > str3[k, 81])
                        {
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            ch += 9;
                        }
                        else
                        {
                            str3[k, 81] = tsum;
                            ch += 9;
                        }

                    }
                    else
                    {
                        ch += 9;
                    }
                }
                ///////////////////
                    ch = 7;
                    step = 1;
                    while (ch < 80)
                    {
                        if (del[ch] == 0 && del[ch + 1] == 0)
                        {
                            int temp = 0;
                            temp = str3[k, ch];
                            str3[k, ch] = str3[k, ch + step];
                            str3[k, ch + step] = temp;
                            check();
                            dcheck();
                            tsum = sum + dsum;
                            if (tsum > str3[k, 81])
                            {
                                temp = str3[k, ch];
                                str3[k, ch] = str3[k, ch + step];
                                str3[k, ch + step] = temp;
                                check();
                                dcheck();
                                tsum = sum + dsum;
                                ch += 9;
                            }
                            else
                            {
                                str3[k, 81] = tsum;
                                ch += 9;
                            }
                        }
                        else
                        {
                            ch += 9;
                        }
                    }
                /////////////////////////////////////////
                ch = 0;
                step = 9;
                k++;
            }
            sortfifty();
        }
        private void sortfifty()
        {
            for (int i = 0; i < 25; i++)
            {
                remove1[i] = true;
            }
            int a = 0, temp1 = 0, b = 0;
            int cnt = 0;
        step1:
            for (int i = 0; i < 25; i++)
            {
                if (remove1[i] != false)
                {
                    temp1 = str3[i, 81];
                    b = i;
                    break;
                }
            }
            for (int j = 0; j < 24; j++)
            {
                if (remove1[j + 1] != false)
                {
                    int temp2 = str3[j + 1, 81];
                    if (temp1 > temp2 || temp1 == temp2)
                    {
                        temp1 = temp2;
                        a = j + 1;
                    }
                }
            }
            if (!remove1[a])
            {
                a = b;
            }
            remove1[a] = false;
            for (int j = 0; j < 82; j++)
            {
                str4[cnt, j] = str3[a, j];
            }
            cnt++;
            if (cnt < 25)
            {
                goto step1;
            }
            restore();
        }
        private void restore()
        {
            int i = 0;
            while (i < 25)
            {
                for (int j = 0; j < 82; j++)
                {
                    str5[i, j] = str4[i, j];
                }
                i++;
            }
            while (i<100)
            {
                for (int j = 0; j < 82; j++)
                {
                    str5[i, j] = str1[i - 25, j];
                }
                i++;
            }
            i = 0;
            while (i<100)
            {
                for (int j = 0; j < 82; j++)
                {
                    str1[i, j] = str5[i, j];
                }
                i++;
            }
           
        }
        private void dcheck()
        {
            dsum = 0;
            ch1 = new int[9];
            int a = 0;
            int n = 1;
            int b = 0;
            cnt = 0;
            while (b < 9)
            {
                bool[] lost = new[] { true, true, true, true, true, true, true, true, true };
                while (n < 10)
                {
                    for (int i = 0 + b; i < 73 + b; i+=9)
                    {
                        if (str3[k, i] == n)
                        {
                            lost[n - 1] = false;
                            break;
                        }

                    }
                    n++;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (lost[j])
                    {
                        cnt++;
                    }
                }
                ch1[a] = cnt;
                    a++;
                b ++;
                n = 1;
                cnt = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                dsum = dsum + ch1[i];
            }
        }
        private int[] empt(int[] fill = null)
        {
            int[] ad = new int[9];
            for (int i = 0; i < 9; i++)
            {
                if (fill[i]!=-1)
                {
                    ad[i] = fill[i];
                }
                
            }
            return ad;
        }
        private void check(int[] c1=null)
        {
            sum = 0;
            int a = 0;
            int[] ch = new int[9];
            int n = 1;
            int b = 0;
            while (b < 81)
            {
                for (int i = 0; i < 9; i++)
                {
                    lost[i] = true;
                }
                while (n < 10)
                {
                    for (int i = 0 + b; i < 9 + b; i++)
                    {
                        if (str3[k,i] == n)
                        {
                            lost[n - 1] = false;
                            break;
                        }

                    }
                    n++;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (lost[j])
                    {
                        cnt++;
                    }
                }
                ch[a] = cnt;
                a++;
                b += 9;
                n = 1;
                cnt = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                sum = sum + ch[i];
            }
        }
        private void rullback()
        {
            
           s1.settextvalue(next(s1.rullback()));
             for (int i = 0; i < 9; i++)
            {
                one[i] = s1.show[i];
            }

            s2.settextvalue(next(s2.rullback()));
            for (int i = 0; i < 9; i++)
            {
                two[i] = s2.show[i];
            }
            s3.settextvalue(next(s3.rullback()));
            for (int i = 0; i < 9; i++)
            {
                three[i] = s3.show[i];
            }
            s4.settextvalue(next(s4.rullback()));
            for (int i = 0; i < 9; i++)
            {
                four[i] = s4.show[i];

            }

            s5.settextvalue(next(s5.rullback()));
            for (int i = 0; i < 9; i++)
            {
                five[i] = s5.show[i];

            }
            s6.settextvalue(next(s6.rullback()));
            for (int i = 0; i < 9; i++)
            {
                six[i] = s6.show[i];

            }
            s7.settextvalue(next(s7.rullback()));
            for (int i = 0; i < 9; i++)
            {
                seven[i] = s7.show[i];

            }
            s8.settextvalue(next(s8.rullback()));
            for (int i = 0; i < 9; i++)
            {
                eight[i] = s8.show[i];

            }
            s9.settextvalue(next(s9.rullback()));
            for (int i = 0; i < 9; i++)
            {
                nine[i] = s9.show[i];

            }

        }
        private void lbl1()
        {
            sum = 0;
            int a = 0;
            int[] ch = new int[9];
            int n = 1;
            int b = 0;
            while (b < 81)
            {
                for (int i = 0; i < 9; i++)
                {
                    lost[i] = true;
                }
                while (n < 10)
                {
                    for (int i = 0 + b; i < 9 + b; i++)
                    {
                        if (save[i] == n)
                        {
                            lost[n - 1] = false;
                            break;
                        }

                    }
                    n++;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (lost[j])
                    {
                        cnt++;
                    }
                }
                ch[a] = cnt;
                a++;
                b += 9;
                n = 1;
                cnt = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                sum = sum + ch[i];
            }
        }
        private void initlbl()
        {
            dsum = 0;
            ch1 = new int[9];
            int a = 0;
            int n = 1;
            int b = 0;
            cnt = 0;
            while (b < 9)
            {
                bool[] lost = new[] { true, true, true, true, true, true, true, true, true };
                while (n < 10)
                {
                    for (int i = 0 + b; i < 73 + b; i += 9)
                    {
                        if (save[i] == n)
                        {
                            lost[n - 1] = false;
                            break;
                        }

                    }
                    n++;
                }
                for (int j = 0; j < 9; j++)
                {
                    if (lost[j])
                    {
                        cnt++;
                    }
                }
                ch1[a] = cnt;
                a++;
                b++;
                n = 1;
                cnt = 0;
            }
            for (int i = 0; i < 9; i++)
            {
                dsum = dsum + ch1[i];
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            s1.clear();
            s2.clear();
            s3.clear();
            s4.clear();
            s5.clear();
            s6.clear();
            s7.clear();
            s8.clear();
            s9.clear();
        }
    }
}