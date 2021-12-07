using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Kiosk.App;

public class Report {

    public void parseFile() {
        Console.WriteLine("Parsing file ... ");
    }

    public void generateHTML() {
        Console.WriteLine("Generating html");
    }
    public void Run() {
        parseFile();
        generateHTML();
        Console.WriteLine("Report");
    }
}