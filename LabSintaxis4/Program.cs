using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSintaxis4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elegir ejercicio a mostrar:\n" +
                               "1) Suma de dos números.\n" +
                               "2) Año bisiesto.\n" +
                               "3) Serie de Fibonacci.\n" +
                               "4) Números pares entre 1 y 100.\n" +
                               "5) Número de un mes.\n" +
                               "6) Números romanos.\n" +
                               "7) Números primos gemelos.\n" +
                               "8) Clave.\n" +
                               "9) Triángulo.\n");
            ConsoleKeyInfo opcion = Console.ReadKey();
            char charOpc = opcion.KeyChar;
            Console.WriteLine("\n");
            switch (charOpc)
            {
                case '1':
                    {
                        Console.WriteLine("Ingrese dos números:");
                        string strNum1 = Console.ReadLine();
                        string strNum2 = Console.ReadLine();
                        if (int.TryParse(strNum1, out int intNum1) && int.TryParse(strNum2, out int intNum2))
                        {
                            int intSuma = intNum1 + intNum2;
                            Console.WriteLine("El resultado de la suma de " + intNum1 + " y " + intNum2 + " es " + intSuma + ".");
                        }
                        else Console.WriteLine("Entrada de datos errónea.");
                        break;
                    }
                case '2':
                    {
                        Console.WriteLine("Ingrese un año:");
                        string strAnio = Console.ReadLine();
                        if (int.TryParse(strAnio, out int intAnio))
                        {
                            //Un año es bisiesto si es divisible por 4, excepto aquellos divisibles por 100 y no 400
                            if (intAnio % 4 == 0)
                            {
                                if (intAnio % 100 != 0 || intAnio % 400 == 0)
                                {
                                    Console.WriteLine(intAnio + " es bisiesto");
                                }
                                else Console.WriteLine(intAnio + " no es bisiesto");
                            }
                            else Console.WriteLine(intAnio + " no es bisiesto");
                        }
                        else Console.WriteLine("Entrada de datos errónea.");
                        break;
                    }
                case '3':
                    {
                        int intNum1 = 1;
                        int intNum2 = 2;
                        int intNum3;
                        int intCont = 3;
                        Console.WriteLine("Elemento número 1: " + intNum1);
                        Console.WriteLine("Elemento número 2: " + intNum2);
                        bool boolBucle = true;
                        while (boolBucle)
                        {
                            intNum3 = intNum1 + intNum2;
                            intNum1 = intNum2;
                            intNum2 = intNum3;
                            Console.WriteLine("Elemento número " + intCont + ": " + intNum3 + "\n\nPresione 'f' para ver el siguiente número o cualquier otra tecla para salir.");
                            ConsoleKeyInfo ckiCheck = Console.ReadKey();
                            char charCheck = ckiCheck.KeyChar;
                            if (charCheck != 'f') boolBucle = false;
                            Console.WriteLine("\n");
                            intCont++;
                        };
                        break;
                    }
                case '4':
                    {
                        for (int i = 1; i <= 100; i++)
                        {
                            if (i % 2 == 0) Console.WriteLine(i);
                        };
                        break;
                    }
                case '5':
                    {
                        string[] strAnio = { "None", "enero", "febrero", "marzo", "abril",
                                             "mayo", "junio", "julio", "agosto", 
                                             "septiembre", "octubre", "noviembre", "diciembre"};
                        Console.WriteLine("Ingrese nombre del mes:");
                        string strMes = Console.ReadLine();
                        strMes = strMes.ToLower();
                        bool boolComp = true;
                        int intCont = 1;
                        int intComp;
                        while (boolComp)
                        {
                            intComp=string.Compare(strMes, strAnio[intCont]);
                            intCont++;
                            if (intComp == 0||intCont>12) boolComp = false;
                            if (intComp == 0) Console.WriteLine(strMes + " " + (intCont - 1));
                        };    
                        break;
                    }
                case '6':
                    {
                        Console.WriteLine("Ingrese número entero:");
                        string strNum = Console.ReadLine();
                        bool boolCheck=int.TryParse(strNum, out int intNum);
                        int intCont;
                        if (boolCheck == false||intNum>3999) Console.WriteLine("Entrada de datos incorrecta.");
                        else
                        {
                            strNum="";
                            for (intCont = intNum / 1000; intCont>0; intCont--)
                            {
                                strNum=string.Concat(strNum, 'M');
                            };
                            intNum %= 1000;
                            if (intNum / 900 == 1)
                            {
                                strNum = string.Concat(strNum, "CM");
                                intNum %= 900;
                            };
                            for (intCont=intNum/500;intCont>0;intCont--)
                            {
                                strNum = string.Concat(strNum, 'D');
                            };
                            intNum %= 500;
                            if (intNum / 400 == 1)
                            {
                                strNum = string.Concat(strNum, "CD");
                                intNum %= 400;
                            };
                            for (intCont=intNum/100;intCont>0;intCont--)
                            {
                                strNum = string.Concat(strNum, 'C');
                            };
                            intNum %= 100;
                            if (intNum / 90 == 1)
                            {
                                strNum = string.Concat(strNum, "XC");
                                intNum %= 90;
                            };
                            for (intCont=intNum/50;intCont>0;intCont--)
                            {
                                strNum = string.Concat(strNum, 'L');
                            };
                            intNum %= 50;
                            if (intNum / 40 == 1)
                            {
                                strNum = string.Concat(strNum, "XL");
                                intNum %= 40;
                            };
                            for (intCont=intNum/10;intCont>0;intCont--)
                            {
                                strNum = string.Concat(strNum, 'X');
                            };
                            intNum %= 10;
                            if (intNum / 9 == 1)
                            {
                                strNum = string.Concat(strNum, "IX");
                                intNum %= 900;
                            };
                            for (intCont=intNum/5;intCont>0;intCont--)
                            {
                                strNum = string.Concat(strNum, 'V');
                            };
                            if (intNum / 4 == 1)
                            {
                                strNum = string.Concat(strNum, "IV");
                                intNum %= 900;
                            };
                            for (intCont=intNum%=5;intCont>0;intCont--)
                            {
                                strNum = string.Concat(strNum, 'I');
                            };
                            Console.WriteLine(strNum);
                        }
                        break;
                    }
                case '7':
                    {
                        int i = 2;
                        Console.WriteLine("Ingresar cantidad de números primos gemelos a mostrar:");
                        bool boolCheck=int.TryParse(Console.ReadLine(), out int intCont);
                        if (boolCheck==false) Console.WriteLine("Entrada de datos incorrecta.");
                        else
                        {
                            while (intCont>0)
                            {
                                if (true)
                                    {
                                        Console.WriteLine(i +" "+ (i + 2));
                                        intCont--;
                                    };
                                i++;
                            };
                        };
                        break;
                    }
                default: Console.WriteLine("\nOpción no disponible."); break;
            }
            Console.WriteLine("\nPresione una tecla para continuar...");
            Console.ReadKey();
        }
    }
}
