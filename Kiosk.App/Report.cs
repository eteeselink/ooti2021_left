using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static System.Text.Encodings.Web.HtmlEncoder;
using System.Text;

namespace Kiosk.App;

public class Report {

    // work in progress
    private string file_path = "result.json";

    private string html_file = "./report.html";
    private string output = "";
    private Report(string file_path) {
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
            byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
                // Add some information to the file.
            file.Write(info, 0, info.Length);
        }
    }
    public void Run() {
        Console.WriteLine("Report");
    }
}