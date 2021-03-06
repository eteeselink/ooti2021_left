using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Text.Encodings.Web.HtmlEncoder;
using System.Text;

namespace Kiosk.App;

public class Report {
    private string file_path = "result.json";

    private string html_file = "report.html";
    private string output = "";

    // This is the constructor that has been commented out
    // Use this
    public Report(string file_path) {
        this.file_path = file_path;
    }

    public void parseFile() {
        output = File.ReadAllText(file_path);
    }

    // work in progress
    public void generateHTML() {
        // create file
        using (FileStream file = File.Create(html_file))
        {
            
            byte[] info = new UTF8Encoding(true).GetBytes("<html><h1>Results</h1><br><h2> " + output + "</h2></html>");

                // Add some information to the file.
            file.Write(info, 0, info.Length);
        }
    }
    public void Run() {
        Console.WriteLine("Printing file ...");
        parseFile();
        Console.WriteLine("Generating report ...");
        generateHTML();
        Console.WriteLine("Report generated ...");
    }
}