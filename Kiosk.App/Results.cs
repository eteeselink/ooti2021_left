using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kiosk.App;

class OptionResultModel {
    private string name;
    private int value;

    public OptionResultModel(string name, int value) {
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

    public void addOptionResult(string name, int value) {
        OptionResultModel optionResult = new OptionResultModel(name, value);
        this.options.Add(optionResult);
    }
}

class Results {
    private string file_path = "result.json";
    private List<ResultsModel> results;
    public Results(List<Question> questions, string file_path) {
        this.file_path = file_path;
        Dictionary<string, string> resultsDict = new Dictionary<string, string>();
        results = tranformQuestionsToResults(questions);
    }

    public List<ResultsModel> tranformQuestionsToResults(List<Question> questions) {
        // Dummy initiation of results, rewrite to implementation
        List<ResultsModel> results = new List<ResultsModel>();
        ResultsModel resultItem1 = new ResultsModel("test question");
        resultItem1.addOptionResult("option1", 2);
        resultItem1.addOptionResult("option2", 3);

        ResultsModel resultItem2 = new ResultsModel("test question1");
        resultItem2.addOptionResult("option1", 4);
        resultItem2.addOptionResult("option2", 5);

        results.Add(resultItem1);
        results.Add(resultItem2);
        return results;
    }
    public void Run() {
        Console.WriteLine("Results");
        //write();
        //display();
    }

    public void write() {
        Console.WriteLine("Save results to file");
        string json = JsonSerializer.Serialize(results);
        File.WriteAllText(this.file_path, json);
    }

    public List<ResultsModel> display() {
        Console.WriteLine("Display results to console");
        return results;
    }
}