using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChecklistComputation
{
    class Program
    {

        public int ComputeCheckdigit(string scanList)
        {
            int sum = 0;
            int temp = 0;
            int chkdigit = 0;
            char[] arrayScanList = scanList.ToCharArray();

            for (int i = 0; i < arrayScanList.Length; i++)
            {
                char ch = arrayScanList[i];

                int digit = Int32.Parse(ch.ToString());
                int weight;
                if (i % 2 == 0)
                    weight = 2;
                else
                    weight = 1;

                temp = digit * weight;
                sum = sum + temp;
            }

            chkdigit = sum % 10;
            chkdigit = 10 - chkdigit;

            //Console.WriteLine("The Check digit is {0} ", chkdigit);
            return chkdigit;
        }
        
        static void Main(string[] args)
        {

            int chkigit = 0;
            // 15+1(chkdigit) - for 3 fields
            Program p = new Program();
            string scanList1 = "000000000800200";

            chkigit = p.ComputeCheckdigit(scanList1);
            Console.WriteLine("1st Check digit is: {0} ",chkigit);

            string scanList2 = "000001008000002";

            chkigit = p.ComputeCheckdigit(scanList2);
            Console.WriteLine("2nd Check digit is: {0} ", chkigit);

            string scanList3 = "000000000800020";

            chkigit = p.ComputeCheckdigit(scanList3);
            Console.WriteLine("3rd Check digit is: {0} ", chkigit);

            //#region Using Arrays
            //int[][] scanlist = new int[4][];
            //scanlist[0] = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2, 0 };
            //scanlist[1] = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2, 0 };
            //scanlist[2] = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2, 0 };
            //scanlist[3] = new int[11] { 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2 };

            ////int[,] scanList = {{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 2,0 },{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 2,0 },
            ////                   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 0, 2,0 }};

            //int[][] tempscanlist = new int[4][];
            //tempscanlist[0] = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2, 0 };
            //tempscanlist[1] = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2, 0 };
            //tempscanlist[2] = new int[14] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2, 0 };
            //tempscanlist[3] = new int[11] { 0, 0, 0, 0, 0, 0, 0, 8, 0, 0, 2 };

            //// step 1: assign weights // 2 1 2 1...
            ////step 2 : add , sum = 12
            //// step 3: divide by constant = 10 , = 12/10, remainder = 2
            ////step 4: 10 - remainder 
            //int weight = 0;
            //int sum = 0;
            //int chkdigit = 0;

            //for (int i = 0; i < 4; i++)
            //{
            //    if (i <= 3)
            //    {
            //        Console.WriteLine(i);
            //        for (int j = 0; j < 14; j++)
            //        {
            //            Console.Write(scanlist[i][j]);
            //            //Console.Write(scanList[i, j]);
            //            if (j % 2 == 0)
            //                weight = 2;
            //            else
            //                weight = 1;
            //            tempscanlist[i][j] = scanlist[i][j] * weight;
            //            //Console.WriteLine("");
            //            //Console.Write("Temporary Scan List: {0} ",tempscanlist[i][j]);


            //        }
            //        Console.WriteLine("");
            //        for (int p = 0; p < 4; p++)
            //        {
            //            for (int j = 0; j < 14; j++)
            //            {
            //                foreach (int a in tempscanlist[j])
            //                {
            //                    sum = sum + a;
            //                }
            //                chkdigit = sum % 10;
            //                chkdigit = 10 - chkdigit;
            //            }

            //        }

            //    }
            //    else
            //    {
            //        //if (i > 3)
            //        //{
            //        //    for (int j = 0; j < 11; j++)
            //        //    {
            //        //        Console.Write(scanList[i][j]);

            //        //    }
            //        //}
            //    }
            //}


            //#endregion
        }
    }
}
