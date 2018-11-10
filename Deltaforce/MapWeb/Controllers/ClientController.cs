using Data;
using Domain.Entity;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MapWeb.Controllers
{
    public class ClientController : Controller
    {
        ServiceClient sc = null;
        LevioMapCtx db = new LevioMapCtx();
      public ClientController()
        {
            sc = new ServiceClient();
        }

        // GET: Client
        public ActionResult Index(string searchString)
        {
            var students = from s in db.Client
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                students = students.Where(s => s.LastName.Equals(searchString)
                                       || s.FirstName.Equals(searchString));
            }
            var res = sc.GetMany();
            return View(students.ToList());
        }

        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
        [HttpPost]
        public ActionResult Create(Client c)
        {
            try
            {
                Client ca = new Client
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Category = c.Category,
                    Type = c.Type,
                    Addresse = c.Addresse,
                    OrganizationalChart = c.OrganizationalChart,
                    Logo = c.Logo,
                    NbProjAf = c.NbProjAf,
                    NbResInServ = c.NbResInServ,
                    Email = c.Email

                };
                sc.Add(ca);
                sc.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Client/Edit/5
        public ActionResult Edit(String id)
        {
            Client c = sc.GetById(id);
            Client c1 = new Client();

          
            c1.FirstName = c.FirstName;
            c1.LastName = c.LastName;
            c1.Category = c.Category;
            c1.Type = c.Type;
            c1.Addresse = c.Addresse;
            c1.OrganizationalChart = c.OrganizationalChart;
            c1.Logo = c.Logo;
            c1.NbProjAf = c.NbProjAf;
            c1.NbResInServ = c.NbResInServ;
            c1.Email = c.Email;
            if (c1==null) {
                return HttpNotFound();
            
        }
            return View(c1);
            

        }

        // POST: Client/Edit/5
        [HttpPost]
        public ActionResult Edit(String id, Client c)
        {
            Client c1 = sc.GetById(id);
          
            c1.FirstName = c.FirstName;
            c1.LastName = c.LastName;
            c1.Category = c.Category;
            c1.Type = c.Type;
            c1.Addresse = c.Addresse;
            c1.OrganizationalChart = c.OrganizationalChart;
            c1.Logo = c.Logo;
            c1.NbProjAf = c.NbProjAf;
            c1.NbResInServ = c.NbResInServ;
            c1.Email = c.Email;
            sc.Update(c1);
            sc.Commit();
            return RedirectToAction("Index");
        }

        // GET: Client/Delete/5
        public ActionResult Delete(String id)
        {
            Client c = sc.GetById(id);
            Client c1 = new Client();


            c1.FirstName = c.FirstName;
            c1.LastName = c.LastName;
            c1.Category = c.Category;
            c1.Type = c.Type;
            c1.Addresse = c.Addresse;
            c1.OrganizationalChart = c.OrganizationalChart;
            c1.Logo = c.Logo;
            c1.NbProjAf = c.NbProjAf;
            c1.NbResInServ = c.NbResInServ;
            c1.Email = c.Email;
            if (c1 == null)
            {
                return HttpNotFound();

            }
            return View(c1);

        }
        // POST: Client/Delete/5
        [HttpPost]
        public ActionResult Delete(String id, Client c)
        {
            Client c1 = sc.GetById(id);

            c1.FirstName = c.FirstName;
            c1.LastName = c.LastName;
            c1.Category = c.Category;
            c1.Type = c.Type;
            c1.Addresse = c.Addresse;
            c1.OrganizationalChart = c.OrganizationalChart;
            c1.Logo = c.Logo;
            c1.NbProjAf = c.NbProjAf;
            c1.NbResInServ = c.NbResInServ;
            c1.Email = c.Email;
            sc.Delete(c1);
            sc.Commit();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Recherche(ClientType name)
        {
            
            return View(sc.GetClientsByType(name));
        }
       
    }

}
