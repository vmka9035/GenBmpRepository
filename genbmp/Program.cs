using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace genbmp
{
    class Program
    {

        static void Main(string[] args)
        {

            GenerateBmp gmp = new GenerateBmp(500);
        }

    }
    class GenerateBmp
    {
        StreamWriter fs = new StreamWriter("D:\\filw.txt");
        Random r;
        Color color;

        public GenerateBmp(int count)
        {
            r = new Random();
            color = Color.FromArgb(GetRandomByte(), GetRandomByte(), GetRandomByte());
            for (int i = 0; i < 10; i++)
            {
                GenerateBitmap(count).Save($"D:\\b{i}.bmp");

            }

        }


        Color GetRandomColor()
        {

            Color c = Color.FromArgb(GetRandomByte(), GetRandomByte(), GetRandomByte());
            return c;

        }
        int GetRandomByte()
        {
            return r.Next(0, 255);
        }
        int GetByteFromByte(int b)
        {
            int v = r.Next(0, 100);
            int value = b;
            //if (v <= 20) value = b - 2;
            //if (v > 20 && v <= 40) value = b - 1;
            //if (v > 40 && v <= 60) value = b;
            //if (v > 60 && v <= 80) value = b + 1;
            //if (v > 80 && v <= 100) value = b + 2;
            if (b > 71 && b <= 183)
            {
                if (v > 50)
                {
                    value = b + 1;
                }
                else
                {
                    value = b - 1;
                }
            }
            if (b > 43 && b <= 71)
            {
                if (v > 50)
                {
                    value = b + 2;
                }
                else
                {
                    value = b - 2;
                }
            }
            if (b > 15 && b <= 43)
            {
                if (v > 50)
                {
                    value = b + 3;
                }
                else
                {
                    value = b - 3;
                }
            }
            if (b >= 0 && b <= 15)
            {
                if (v > 50)
                {
                    value = b + 4;
                }
                else
                {
                    value = b - 4;
                }
            }

            if (b > 183 && b <= 211)
            {
                if (v > 50)
                {
                    value = b + 2;
                }
                else
                {
                    value = b - 2;
                }
            }

            if (b > 211 && b <= 240)
            {
                if (v > 50)
                {
                    value = b + 3;
                }
                else
                {
                    value = b - 3;
                }
            }

            if (b > 240 && b <= 255)
            {
                if (v > 50)
                {
                    value = b + 4;
                }
                else
                {
                    value = b - 4;
                }
            }

            if (value < 0) { return 0; }
            else if (value >= 255) { return 255; }
            else { return value; }
        }

        Bitmap GenerateBitmap(int a)
        {
            Bitmap bmp = new Bitmap(a, a);
            //int[] res = new int[(int)Math.Pow(a, 2)];
            int x = 0;
            int y = 0;
            //int count = 1;
            int c = 0;
            bool toLeft = false;
            for (int k = 0; k < 2 * a - 1; k++)
            {
                //y = -x + k;
                while (x < 2 * a - 1)
                {
                    c++;
                    y = -x + k;
                    if (x >= 0 && x < a && y < a && y >= 0)
                    {
                        if (toLeft)
                        {
                            SetPixelAndColor(bmp, x, y);
                            
                        }
                        else
                        {
                            SetPixelAndColor(bmp, y, x);
                            //res[y, x] = count++;
                        }
                        //res[x, y] = count++;
                    }
x++;
                }
                toLeft = !toLeft;
            x = 0;
            }
            return bmp;
        }

        private void SetPixelAndColor(Bitmap bmp, int x, int y)
        {
            //rnd = new Random();
            //

            int r = GetByteFromByte(color.R);
            int g = GetByteFromByte(color.G);
            int b = GetByteFromByte(color.B);
            color = Color.FromArgb(r, g, b);
            bmp.SetPixel(x, y, color);
            
            fs.Write($"{x} - {y}: {r}-{g}-{b}" + Environment.NewLine);
            
            //bmp.SetPixel(j, i, color);

        }
        void WriteInConsole(int[,] mass)
        {
            for (int i = 0; i < mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass.GetLength(1); j++)
                {

                    int val = mass[i, j];
                    if (val < 10) Console.Write(" " + val + " ");
                    else Console.Write(val + " ");
                }
                Console.WriteLine();
            }
        }

    }

}
