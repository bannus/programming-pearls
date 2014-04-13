using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingPearls
{
    public static class ListExtension
    {
        public static void PrettyPrint(this int[] list)
        {
            int n = list.Length;
            Console.Write("[");
            foreach (int x in list.Take(n - 1))
                Console.Write("{0}, ", x);
            Console.WriteLine("{0}]", list[n - 1]);
        }
    }

    static class Util
    {
        static public void Swap(ref int x, ref int y)
        {
            int tmp = x;
            x = y;
            y = tmp;
        }
    }
}
