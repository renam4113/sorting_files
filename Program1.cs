using System;
using System.IO;
using System.Collections.Generic;
using System.Numerics;

namespace Сортировка_файлов
{
    class Program1
    {
        static int ReadElement(StreamReader fs)
        {
            int curNum = 0;
            if(fs.Peek() == -1)
            {
                return -1;
            }
            while (true)
            {
                int charRead = fs.Read();
                if (charRead == -1 || (char)charRead == ' ')
                {
                    return curNum;
                }

                char c = (char)charRead;
                if (c >= '0' && c <= '9')
                {
                    curNum = curNum * 10 + (c - '0');
                }
            }
        }

        static void FileSort(string file)
        {
            int step = 1;


            StreamReader fs = new StreamReader(file);
            StreamWriter streamWriter1 = new StreamWriter("f1.txt");
            StreamWriter streamWriter2 = new StreamWriter("f2.txt");

            int k = 0;

            int x = ReadElement(fs);

           while(x != -1)
            {
                if (k == 0) streamWriter1.Write(x + " ");
                else streamWriter2.Write(x + " ");
                x = ReadElement(fs);
                k = 1 - k;
            }

            streamWriter1.Close();
            streamWriter2.Close();


            bool flag1 = true;
            bool flag2 = false;




            while (flag1)
            {
                if (!flag2)
                {
                    StreamReader fs0 = new StreamReader("f1.txt");
                    StreamReader fs1 = new StreamReader("f2.txt");
                    StreamWriter writer1 = new StreamWriter("G1.txt");
                    StreamWriter writer2 = new StreamWriter("G2.txt");


                    if (fs1.Peek() == -1)
                    {
                        flag1 = false;
                    }

                    else
                    {

                        int x1 = ReadElement(fs0);
                        int x2 = ReadElement(fs1);

                        int n = 0;



                        while (x1 != -1 && x2 != -1)
                        {
                            int i = 0;
                            int j = 0;

                            while (x1 != -1 && x2 != -1 && i < step && j < step)
                            {
                                if (x1 < x2)
                                {
                                    if (n == 0) writer1.Write(x1 + " ");
                                    else writer2.Write(x1 + " ");
                                    x1 = ReadElement(fs0);
                                    i += 1;
                                }
                                else
                                {
                                    if (n == 0) writer1.Write(x2 + " ");
                                    else writer2.Write(x2 + " ");
                                    x2 = ReadElement(fs1);
                                    j += 1;
                                }
                            }

                            while (x1 != -1 && i < step)
                            {
                                if (n == 0) writer1.Write(x1 + " ");
                                else writer2.Write(x1 + " ");
                                x1 = ReadElement(fs0);
                                i += 1;
                            }

                            while (x2 != -1 && j < step)
                            {
                                if (n == 0) writer1.Write(x2 + " ");
                                else writer2.Write(x2 + " ");
                                x2 = ReadElement(fs1);
                                j += 1;
                            }

                            n = 1 - n;
                        }

                        while (x1 != -1)
                        {
                            if (n == 0) writer1.Write(x1 + " ");
                            else writer2.Write(x1 + " ");
                            x1 = ReadElement(fs0);
                        }

                        while (x2 != -1)
                        {
                            if (n == 0) writer1.Write(x2 + " ");
                            else writer2.Write(x2 + " ");
                            x2 = ReadElement(fs1);
                        }

                    }


                    fs0.Close();
                    fs1.Close();
                    writer1.Close();
                    writer2.Close();

                    flag2 = true;
                }

                else
                {
                    StreamReader fs0 = new StreamReader("G1.txt");
                    StreamReader fs1 = new StreamReader("G2.txt");
                    StreamWriter writer1 = new StreamWriter("f1.txt");
                    StreamWriter writer2 = new StreamWriter("f2.txt");


                    if (fs1.Peek() == -1)
                    {
                        flag1 = false;
                        break;
                    }

                    else
                    {
                        int x1 = ReadElement(fs0);
                        int x2 = ReadElement(fs1);

                        int n = 0;


                        while (x1 != -1 && x2 != -1)
                        {
                            int i = 0;
                            int j = 0;

                            while (x1 != -1 && x2 != -1 && i < step && j < step)
                            {
                                if (x1 < x2)
                                {
                                    if (n == 0) writer1.Write(x1 + " ");
                                    else writer2.Write(x1 + " ");
                                    x1 = ReadElement(fs0);
                                    i += 1;
                                }
                                else
                                {
                                    if (n == 0) writer1.Write(x2 + " ");
                                    else writer2.Write(x2 + " ");
                                    x2 = ReadElement(fs1);
                                    j += 1;
                                }
                            }

                            while (x1 != -1 && i < step)
                            {
                                if (n == 0) writer1.Write(x1 + " ");
                                else writer2.Write(x1 + " ");
                                x1 = ReadElement(fs0);
                                i += 1;
                            }

                            while (x2 != -1 && j < step)
                            {
                                if (n == 0) writer1.Write(x2 + " ");
                                else writer2.Write(x2 + " ");
                                x2 = ReadElement(fs1);
                                j += 1;
                            }

                            n = 1 - n;
                        }

                        while (x1 != -1)
                        {
                            if (n == 0) writer1.Write(x1 + " ");
                            else writer2.Write(x1 + " ");
                            x1 = ReadElement(fs0);
                        }

                        while (x2 != -1)
                        {
                            if (n == 0) writer1.Write(x2 + " ");
                            else writer2.Write(x2 + " ");
                            x2 = ReadElement(fs1);
                        }

                    }


                    fs0.Close();
                    fs1.Close();
                    writer1.Close();
                    writer2.Close();
                    flag2 = false;
                }

                step *= 2;
            }

            if (flag2 == false)
            {
                StreamReader fs1 = new StreamReader("f1.txt");
                string S = fs1.ReadToEnd();
                fs1.Close();
                Console.WriteLine("результат в f1.txt:  " + S);
            }
            else
            {
                StreamReader fs1 = new StreamReader("G1.txt");
                string s = fs1.ReadToEnd();
                fs1.Close();
                Console.WriteLine("результат в G1.txt: " + s);
                
            }

        }
        static void Main(string[] args)
        {

            string file = "file.txt";
            FileSort(file);
           
        }
  
    }
}