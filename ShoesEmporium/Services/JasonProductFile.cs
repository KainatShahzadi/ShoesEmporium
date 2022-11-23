using Microsoft.AspNetCore.Hosting;
using ShoesEmporium.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShoesEmporium.Services
{
    public class JasonProductFile
    {
        public JasonProductFile(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }
        public IWebHostEnvironment WebHostEnvironment { get; }

        public string JsonFilePath
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "products.json");
            }
        }
        public IEnumerable<Product> getProductsData()
        {
            using (var json_file = File.OpenText(JsonFilePath))
            {
                return JsonSerializer.Deserialize<Product[]>(json_file.ReadToEnd());
            }
        }




    }
}
