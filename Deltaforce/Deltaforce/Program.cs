using Data;
using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deltaforce
{
    class Program
    {
        static void Main(string[] args)
        {
            LevioMapCtx lev = new LevioMapCtx();
           
            
            lev.SaveChanges();
            Console.WriteLine("Base Created with succes ");
            Console.ReadKey();
        }
    }
}
