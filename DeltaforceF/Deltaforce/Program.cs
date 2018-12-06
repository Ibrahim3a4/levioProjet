using Data;
using Domain.Entity;
using Service;
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
        {/** 
            LevioMapCtx lev = new LevioMapCtx();
           
            
            lev.SaveChanges();
            Console.WriteLine("Base Created with succes ");
            Console.ReadKey();**/

            ServiceRequest sr = new ServiceRequest();
            Request req1 = new Request() {
                idRequest = 1,
                requirements="fr",
                profileRequired="ing",
                career="bac+5",
                startDate=DateTime.Now,
                endDate=DateTime.Now,
                //director="marzouki",
                depositDate=DateTime.Now

              
            };

           // sr.Add(req1);
          //  sr.Commit();

            Console.WriteLine("ajout ");
            Console.ReadKey();

        }
    }
}
