using System;

namespace lab1
{
    class Program
    {
        class TMatrix
        {
            public int a, b;
            public int[,] arr;

            public TMatrix()
            {
                this.a = 2;
                this.b = 3;
                this.arr = fillRand(this.a, this.b);
            }

            public TMatrix(int[,] arr)
            {
                this.a = arr.GetLength(0);
                this.b = arr.GetLength(1);
                this.arr = arr;
            }

            public TMatrix(int a, int b)
            {
                this.a = a;
                this.b = b;
                this.arr = fillRand(a, b);
            }

            public TMatrix(TMatrix m)
            {
                this.a = m.arr.GetLength(0);
                this.b = m.arr.GetLength(1);
                this.arr = m.arr;
            }

            public void findMaxMin()
            {
                int max = 0;
                int min = 0;
                for (int i = 0; i < this.a; i++)
                {
                    for (int j = 0; j < this.b; j++)
                    {
                        if (this.arr[i, j] > max) max = this.arr[i, j];
                        if (this.arr[i, j] < min) min = this.arr[i, j];
                    }
                }
                Console.WriteLine("min=" + min);
                Console.WriteLine("max=" + max);
            }

            public void findSum()
            {
                int sum = 0;
                for (int i = 0; i < this.a; i++)
                {
                    for (int j = 0; j < this.b; j++)
                    {
                        sum += arr[i, j];
                    }
                }
                Console.WriteLine("sum=" + sum);
            }

            public int[,] fillManual()
            {
                for (int i = 0; i < this.a; i++)
                {
                    for (int j = 0; j < this.b; j++)
                    {
                        Console.Write("Значення: ");
                        this.arr[i, j] = Convert.ToInt32(Console.ReadLine());
                        Console.Write("");
                    }
                }
                return arr;
            }

            public int[,] fillRand(int a, int b)
            {
                Random rnd = new Random();
                int[,] arr = new int[a, b];
                for (int i = 0; i < this.a; i++)
                {
                    for (int j = 0; j < this.b; j++)
                    {
                        arr[i, j] = rnd.Next(-9, 9);
                    }
                }
                return arr;
            }

            public void print()
            {
                if (this.a == 0) Console.WriteLine();
                else
                {
                    for (int i = 0; i < this.arr.GetLength(0); i++)
                    {
                        for (int j = 0; j < this.arr.GetLength(1); j++)
                        {
                            Console.Write(this.arr[i, j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
                Console.WriteLine();
            }

        }

        class TOpMatrix : TMatrix
        {
            public TOpMatrix() : base() { }

            public TOpMatrix(int[,] arr) : base(arr) { }

            public TOpMatrix(int a, int b) : base(a, b) { }

            public TOpMatrix(TOpMatrix m) : base(m) { }

            public static TOpMatrix operator *(TOpMatrix m1, TOpMatrix m2)
            {
                if (m2.a != m1.b)
                {
                    Console.WriteLine("Множення неможливе");
                    return new TOpMatrix(0, 0);
                }
                else
                {
                    int[,] arr = new int[m1.a, m2.b];
                    for (int i = 0; i < m1.a; i++)
                    {
                        for (int j = 0; j < m2.b; j++)
                        {
                            arr[i, j] = 0;
                            for (int k = 0; k < m1.b; k++)
                                arr[i, j] += m1.arr[i, k] * m2.arr[k, j];
                        }
                    }
                    TOpMatrix res = new TOpMatrix(arr);
                    return res;
                }
            }

            public static TOpMatrix operator +(TOpMatrix m1, TOpMatrix m2)
            {
                if (m1.a != m2.a || m1.b != m2.b)
                {
                    Console.WriteLine("Додавання неможливе");
                    return new TOpMatrix(0, 0);
                }
                else
                {
                    int[,] arr = new int[m1.a, m1.b];
                    for (int i = 0; i < m1.a; i++)
                    {
                        for (int j = 0; j < m1.b; j++)
                        {
                            arr[i, j] = m1.arr[i, j] + m2.arr[i, j];
                        }
                    }
                    TOpMatrix res = new TOpMatrix(arr);
                    return res;
                }
            }

            public static TOpMatrix operator -(TOpMatrix m1, TOpMatrix m2)
            {
                if (m1.a != m2.a || m1.b != m2.b)
                {
                    Console.WriteLine("Віднімання неможливе");
                    return new TOpMatrix(0, 0);
                }
                else
                {
                    int[,] arr = new int[m1.a, m1.b];
                    for (int i = 0; i < m1.a; i++)
                    {
                        for (int j = 0; j < m1.b; j++)
                        {
                            arr[i, j] = m1.arr[i, j] - m2.arr[i, j];
                        }
                    }
                    TOpMatrix res = new TOpMatrix(arr);
                    return res;
                }
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Довільна матриця");
            TMatrix m1 = new TMatrix();
            m1.print();
            Console.WriteLine("Ручне заповнення");
            m1.fillManual();
            Console.WriteLine();
            m1.print();
            m1.findMaxMin();
            m1.findSum();
            Console.WriteLine();
            Console.WriteLine("Матриця а");
            TOpMatrix a = new TOpMatrix(2, 3);
            a.print();
            Console.WriteLine("Матриця b");
            TOpMatrix b = new TOpMatrix(3, 4);
            b.print();
            Console.WriteLine("Матриця с");
            TOpMatrix c = new TOpMatrix(2, 3);
            c.print();
            Console.WriteLine("a + b");
            TOpMatrix res = a + b;
            res.print();
            Console.WriteLine("a * b");
            res = a * b;
            res.print();
            TOpMatrix res1 = new TOpMatrix(res);
            Console.WriteLine("b * a");
            res = b * a;
            res.print();
            Console.WriteLine("a - b");
            res = a - b;
            res.print();
            Console.WriteLine("a + c");
            res = a + c;
            res.print();
            Console.WriteLine("a - c");
            res = a - c;
            res.print();
            Console.WriteLine("Скопійована матриця");
            res1.print();
        }
    }
}
