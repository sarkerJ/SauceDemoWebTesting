using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoWebTestingSolution
{
    public class Shared_SD_Website
    {
        public SD_Website<ChromeDriver> SD_Website { get; } = new SD_Website<ChromeDriver>();
    }
}
