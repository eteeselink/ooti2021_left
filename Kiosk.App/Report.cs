using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Kiosk.App;

public class Report {

    // work in progress
    private string file_path = "/workspace/ooti2021_left/Kiosk.App/result.json";
    public Report() {
    }
    public void parseFile() {
        String output = File.ReadAllText(this.file_path);
        Console.WriteLine(output);
    }

    // work in progress
    public void generateHTML() {
        Console.WriteLine("Generating html");
    }
    public void Run() {
        parseFile();
        generateHTML();
        Console.WriteLine("Report");
    }
}