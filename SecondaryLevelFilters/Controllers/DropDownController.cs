using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SecondaryLevelFilters.Models;

namespace SecondaryLevelFilters.Controllers 
{
    public class DropDownController : Controller
    {
        public List<Test> Countries;
        public List<Test2> States;
        public List<Test3> Cities;

        public DropDownController()
        {
            Countries = new List<Test> {
                new Test(1, "bla"),
                new Test(2, "bla1"),
                new Test(3, "bla2"),
                new Test(4, "bla3")
            };

            States = new List<Test2>
            {
                  new Test2(1, "bla"),
                  new Test2(2, "bla1"),
                  new Test2(3, "bla2"),
                  new Test2(4, "bla3")
            };

            Cities = new List<Test3>
            {
                  new Test3(1, "bla"),
                  new Test3(2, "bla1"),
                  new Test3(3, "bla2"),
                  new Test3(4, "bla3")
            };
        }

        // GET: Home
        public ActionResult Index()
        {
            CascadingModel model = new CascadingModel();
            model.Countries = CreateSelectList(Countries, x => x.Id, x => x.Name);
            var selected = Countries.FirstOrDefault().Id;
            model.States = GetStatesListByCountryId(selected);

            model.Cities = CreateSelectList(Cities, x => x.Id, x => x.Name);
            return View(model);
        }

        public List<SelectListItem> GetStatesListByCountryId(int countryid)
        {
          //var list = States.Where(x => x.Country.Id == countryid).ToList();
            return CreateSelectList(States, x => x.Id, x => x.Name);
        }


        public List<SelectListItem> CreateSelectList<T>(IList<T> entities, Func<T, object> funcToGetValue, Func<T, object> funcToGetText)
        {
            return entities
                    .Select(x => new SelectListItem
                    {
                        Value = funcToGetValue(x).ToString(),
                        Text = funcToGetText(x).ToString()
                    }).ToList();
        }

       
        [HttpPost]
        public JsonResult AjaxMethod(string type, int value)
        {
            CascadingModel model = new CascadingModel();
            switch (type)
            {
                case "CountryId":
                    model.States = CreateSelectList(States.Take(2).ToList(), x => x.Id, x => x.Name);
                    break;
                case "StateId":
                    model.Cities = CreateSelectList(Cities.Take(2).ToList(), x => x.Id, x => x.Name);
                    break;
            }
            return Json(model);
        }
    }
}