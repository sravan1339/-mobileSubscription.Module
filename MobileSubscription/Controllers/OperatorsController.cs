using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MobileSubscription.Models;
using MobileSubscription.Models.ViewModels;

namespace MobileSubscription.Controllers
{
    public class OperatorsController : Controller
    {
        [HttpGet]
        public ActionResult Manage()
        {
            return View(GetOperatorsManagementViewModel());
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(GetAddOperatorViewModel());
        }

        [HttpPost]
        public ActionResult Add(AddOperatorViewModel newOperator)
        {
            return View(GetAddOperatorViewModel());
        }

        private OperatorsManagementViewModel GetOperatorsManagementViewModel()
        {
            var dummyViewModel = new OperatorsManagementViewModel
            {
                CountryOperatorses = new List<CountryOperators> 
                {
                    new CountryOperators
                    {
                        Country = new Country { Id = 1, Name = "United Kingdom" },
                        Operators = new List<Operator> {
                            new Operator { Id = 0, Name = "O2" },
                            new Operator { Id = 1, Name = "Three" },
                            new Operator { Id = 2, Name = "Vodafone" },
                            new Operator { Id = 3, Name = "EE" },
                            new Operator { Id = 4, Name = "Orange" },
                            new Operator { Id = 5, Name = "GiffGaff" },
                            new Operator { Id = 6, Name = "Virgin Media" },
                            new Operator { Id = 7, Name = "Tesco Mobile" },
                            new Operator { Id = 8, Name = "T-Mobile" },
                            new Operator { Id = 9, Name = "TalkTalk" }
                        }
                    },
                    new CountryOperators
                    {
                        Country = new Country { Id = 2, Name = "Viet Nam" },
                        Operators = new List<Operator> 
                        {
                            new Operator { Id = 10, Name = "Mobifone" },
                            new Operator { Id = 11, Name = "Vinaphone" },
                            new Operator { Id = 12, Name = "Viettel Mobile" },
                            new Operator { Id = 13, Name = "Vietnamobile" },
                            new Operator { Id = 14, Name = "Beeline" },
                            new Operator { Id = 15, Name = "S-Fone" }
                        }
                    }
                }
            };

            return dummyViewModel;
        }

        private AddOperatorViewModel GetAddOperatorViewModel()
        {
            var countries = new List<Country>
                {
                    new Country { Id = 1, Name = "United Kingdom" },
                    new Country { Id = 2, Name = "Viet Nam" }
                };

            var viewModel = new AddOperatorViewModel
            {
                Countries = countries.Select(c => new SelectListItem
                {
                    Selected = false,
                    Text = c.Name,
                    Value = c.Id.ToString(CultureInfo.InvariantCulture)
                }).ToList()
            };

            return viewModel;
        }
    }
}