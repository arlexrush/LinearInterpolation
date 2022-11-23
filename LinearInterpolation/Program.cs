using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace LinearInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            var interpolator = new Interpolator();
            interpolator.ShowHead();
            var datos=interpolator.GetDato();            
            interpolator.ShowDatos(datos);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Please enter value (x) to Interpolation");
            var xStr = Console.ReadLine();
            double numberX = 0;
            var canConvert = double.TryParse(xStr, out numberX);
            while (string.IsNullOrEmpty(xStr) || canConvert != true)
            {
                Console.WriteLine("Please enter value (x) to Interpolation [Max. 999.999.999]:");
                xStr = Console.ReadLine();
                canConvert = double.TryParse(xStr, out numberX);
            }
            var x = double.Parse(xStr);
            Console.WriteLine();
                        
            var (newDatos, dato) =interpolator.LinearInterpolation(datos, x);
            interpolator.ShowDatos(newDatos);
            Console.WriteLine();
            Console.WriteLine();
            Console.Write($"The result for Linear Interpolation of {dato.Xi} is: {dato.Yi}");
            Console.WriteLine();
            Console.WriteLine();
            Console.ReadLine();

        }

        public class Interpolator
        {
            public void ShowHead()
            {
                var lineThink = byte.Parse("2");
                var head = "Linear Interpolation, Vers 1.0";
                var numHeadChar = head.Length;
                var withHead = 20 + numHeadChar;
                var heigthHead = 5;
                var fI = 2;
                var fF = fI + heigthHead;
                var cI = 2;
                var cF = cI + withHead;
                int t, f, c;
                for (t = 1; t <= lineThink; t++)
                {
                    for (f = cI; f <= cF; f++)
                    {
                        Console.SetCursorPosition(f, fI);
                        Console.Write("_");
                        Console.SetCursorPosition(f, fF);
                        Console.Write("_");
                        if (t == 1)
                        {
                            Console.SetCursorPosition(cI + (10), fI + 1 + (heigthHead / 2));
                            Console.Write(head);
                        }
                    }

                    for (c = fI + 1; c <= fF; c++)
                    {
                        Console.SetCursorPosition(cI, c);
                        Console.Write("|");
                        Console.SetCursorPosition(cF, c);
                        Console.Write("|");
                    }

                    fI = fI + 1;
                    cI = cI + 2;
                    fF = fF - 1;
                    cF = cF - 2;
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine();
            }

            public List<Dato> GetDato()
            {
                Console.WriteLine();
                Console.WriteLine("Hello, wellcome to Linear Interpolation program vers 1.0");
                Console.WriteLine();
                Console.WriteLine("STEP 1. build table from your data, here we will introduce pairs of data (Xi, Yi)");
                Console.WriteLine();
                var count = 1;
                //var b = new string("");
                var moreData = true;                
                var datos = new List<Dato>();
                
                
                while (moreData)
                {
                    Console.WriteLine($"Introduce X{count}  [Max. 999.999.999]:");
                    var xIStr = Console.ReadLine();
                    double numberX = 0;
                    var canConvert = double.TryParse(xIStr, out numberX);
                    while (string.IsNullOrEmpty(xIStr) || canConvert != true)
                    {
                        Console.WriteLine($"Introduce X{count}  [Max. 999.999.999]:");
                        xIStr = Console.ReadLine();
                        canConvert = double.TryParse(xIStr, out numberX);
                    }
                    var xI = double.Parse(xIStr);
                    Console.WriteLine();

                    Console.WriteLine($"Introduce Y{count}  [Max. 999.999.999]:");
                    var yIStr = Console.ReadLine();
                    double numberY = 0;                    
                    canConvert = double.TryParse(yIStr, out numberY);
                    while (string.IsNullOrEmpty(yIStr) || canConvert != true)
                    {
                        Console.WriteLine($"Introduce Y{count}  [Max. 999.999.999]:");
                        yIStr = Console.ReadLine();
                        canConvert = double.TryParse(yIStr, out numberY);
                    }
                    var yI = double.Parse(yIStr);
                    Console.WriteLine();

                    var dato = new Dato() { Xi = xI, Yi = yI };
                    datos.Add(dato);
                    Console.WriteLine($"This is the Pair{count}: X{count}={dato.Xi}, Y{count}={dato.Yi}");
                    Console.WriteLine();

                    Console.WriteLine("would you like continue adding data? (y:yes or n:not)");
                    var b = Console.ReadLine();
                    var bx = b.Length;
                    var bb = String.IsNullOrWhiteSpace(b);
                    var bbb = b.Contains("y");                    
                    while (bb || !bbb || bx!=1)
                    {
                        var bxb = b.Contains("n");
                        if (bxb)
                        {
                            bx = 1;
                            bb = false;
                            bbb = true;
                        }
                        else
                        {
                            Console.WriteLine("would you like continue adding data? (y:yes or n:not)");
                            b = Console.ReadLine();
                            bx = b.Length;
                            bb = String.IsNullOrWhiteSpace(b);
                            bbb = b.Contains("y");
                        }
                        
                    }
                    //Console.WriteLine("prueba de y");
                    if (b == "y")
                    {
                        moreData = true;
                        count++;
                    }
                    if (b == "n")
                    {
                        moreData = false;
                    }
                    
                }


                return datos;
            }

            public void ShowDatos(List<Dato> datos)
            {
                Console.Clear();
                Console.SetCursorPosition(10, 2);
                Console.WriteLine("These are your Data".ToUpper());
                Console.WriteLine();

                var fI = 5;
                var cI = 5;
                var width = 30;
                var height = 3;
                var fF = fI + height;
                var cF = cI + width;

                //horizontal lines
                for (int f = cI; f <= cF; f++)
                {
                    Console.SetCursorPosition(f, fI);
                    Console.Write("-");

                    Console.SetCursorPosition(f, fF);
                    Console.Write("-");
                }
                
                //Vertical lines
                for (int c = fI+1; c <= fF-1; c++)
                {
                    Console.SetCursorPosition(cI, c);
                    Console.Write("|");

                    Console.SetCursorPosition(cI + (width / 2), c);
                    Console.Write("|");

                    Console.SetCursorPosition(cI + (width), c );
                    Console.Write("|");
                }

                //Content Head
                Console.SetCursorPosition(8,6 );
                Console.Write("Domain [x]");
                Console.SetCursorPosition(23, 6);
                Console.Write("Rango [Y]");

                fI = fI + 3;
                fF = fF + 3;
                // Data
                foreach(Dato dato in datos)
                {
                    //horizontal lines
                    for (int f = cI; f <= cF; f++)
                    {
                        Console.SetCursorPosition(f, fI);
                        Console.Write("-");

                        Console.SetCursorPosition(f, fF);
                        Console.Write("-");
                    }

                    //Vertical lines
                    for (int c = fI + 1; c <= fF - 1; c++)
                    {
                        Console.SetCursorPosition(cI, c);
                        Console.Write("|");

                        Console.SetCursorPosition(cI + (width / 2), c);
                        Console.Write("|");

                        Console.SetCursorPosition(cI + (width), c);
                        Console.Write("|");
                    }

                    //Content
                    Console.SetCursorPosition(cI+3, fI+1);
                    Console.Write(String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dato.Xi));
                    Console.SetCursorPosition(cI+18, fI + 1);
                    Console.Write(String.Format(CultureInfo.InvariantCulture, "{0:0.00}", dato.Yi));

                    fI = fI + 3;
                    fF = fF + 3;
                }

                Console.WriteLine();
                Console.ReadLine();
            }

            public (List<Dato>, Dato) LinearInterpolation(List<Dato> datos, double x)
            {
                //Create pair for fort List datos
                var pairX = new Dato() { Xi = x, Yi = 0 };
                datos.Add(pairX);
                var datosSort = datos.OrderBy(x => x.Xi).ToList();
                var indexX = datosSort.IndexOf(pairX);
                var count = datosSort.Count;
                var indexLast = count - 1;
                int indexPre = indexX - 1;
                int indexPost = indexX + 1;
                if (indexX == 0)
                {
                    indexPre = indexX + 1;
                }
                if (indexX == indexLast)
                {
                    indexPost = indexX - 1;
                }

                //Linear Interpolation Parameters
                var pair1 = datosSort[indexPre];
                var x1 = pair1.Xi;
                var y1 = pair1.Yi;
                var pair2 = datosSort[indexPost];
                var x2 = pair2.Xi;
                var y2 = pair2.Yi;
                var xx = pairX.Xi;

                var yx = y1 + ((xx - x1) * ((y2 - y1) / (x2 - x1)));
                datosSort.Remove(pairX);

                pairX.Yi = yx;
                datosSort.Add(pairX);

                var datosResult= datosSort.OrderBy(x => x.Xi).ToList();
                //Console.WriteLine(indexX);
                Console.ReadLine();
                return (datosResult, pairX);
            }
        }
        
        public class Dato
        {
            public double Xi { get; set; }
            public double Yi { get; set; }
        }
    }
}
