using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kiosk.App;

class OptionResultModel {
    private string name;
    private string value;

    public OptionResultModel(string name, string value) {
        this.name = name;
        this.value = value;
    }
}

class ResultsModel {
    private string title;
    private List<OptionResultModel> options;

    public ResultsModel(string title) {
        this.title = title;
        options = new List<OptionResultModel>();
    }

    public void addOptionResult(string name, string value) {
        OptionResultModel optionResult = new OptionResultModel(name, value);
        this.options.Add(optionResult);
    }
}

class Results {
    private string file_path;
    public Results(string result_file_path) {
        file_path = result_file_path;
    }
    public void Run() {
        Console.WriteLine("Results");
        
    }

    // WIP: work in progress
    public void write(List<ResultsModel> results) {
        string json = JsonSerializer.Serialize(results);
        File.WriteAllText(this.file_path, json);
    }

    public List<ResultsModel> display(List<ResultsModel> results) {
        return results;
    }
}