using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMSNEW.UI
{
    class MenuUI
    {
        static public void header()
        {
            Console.WriteLine("________________________________________________");
            Console.WriteLine("                                                ");
            Console.WriteLine("----------         UAMS                 --------");
            Console.WriteLine("________________________________________________");
            Console.WriteLine("                                                ");
        }
        static public string menu()
        {
            header();
            Console.WriteLine("[1]-Add Student");
            Console.WriteLine("[2]-Add Degree Program");
            Console.WriteLine("[3]-Generate Merit");
            Console.WriteLine("[4]-View Registered Students");
            Console.WriteLine("[5]-View Student of Specific Program");
            Console.WriteLine("[6]-Register Subject of Specific Student");
            Console.WriteLine("[7]-Caluclulate Fees for all Registered Students");
            Console.WriteLine("[8]-Exit");
            Console.Write("Your Option......");
            string op = Console.ReadLine();
            return op;
        }
        public static void clearscreen()
        {
            Console.WriteLine("Press any to Continue........");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
