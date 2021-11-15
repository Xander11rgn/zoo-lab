using CM.ZooLab.ConsoleApp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace CM.ZooLab.ClassLibrary
{
    public class MainProgramTests
    {
        [Fact]
        public void ShouldBeAbleToRunTheMainProgram()
        {
            var input = new StringReader("n");
            Console.SetIn(input);
            Program.Main(new string[] { });
        }
    }
}
