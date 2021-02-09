using ConfPageC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ConfPageC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            MySqlConnectionStringBuilder connectionBuilder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",
                Port = 3307,
                UserID = "root",
                Password = "",
                Database = "conf_post"

               /** Server = "localhost",
                Port = 3306,
                UserID = "julien",
                Password = "root",
                Database = "conf_post"
               */
            };
            string hello = null;

            using (MySqlConnection connection = new MySqlConnection(connectionBuilder.ToString()))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM hellotable WHERE libelle = 'Hello world'", connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                            hello = reader.GetString("libelle");
                    }
                }
            }

            ViewBag.hello = hello;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
