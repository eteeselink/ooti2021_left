using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Kiosk.App;

class OptionResultModel {
    private string name;
    private int value;

    public OptionResultModel(string name, int value) {
        this.name = name;
        this.value = value;
    }

    public string getName() {
        return name;
    }

    public int getValue() {
        return value;
    }

    public string toString() {
        return "Option " + name + ":" + value + "\n";
    }
}

class ResultsModel {
    private string title;
    private List<OptionResultModel> options;

    public string getTitle() {
        return title;
    }

    public List<OptionResultModel> GetOptions() {
        return options;
    }

    public ResultsModel(string title) {
        this.title = title;
        options = new List<OptionResultModel>();
    }

    public void addOptionResult(string name, int value) {
        OptionResultModel optionResult = new OptionResultModel(name, value);
        this.options.Add(optionResult);
    }

    public string toString() {
        string result = "";
        result = result + title + "\n";
        foreach (OptionResultModel option in options) {
                result = result + option.toString();
        }
        return result;
    }
}

class Results {
    private string file_path;
    private List<ResultsModel> results;

    public Results(List<Question> questions, string file_path) {
        this.file_path = file_path;
        results = tranformQuestionsToResults(questions);
    }

    private List<ResultsModel> tranformQuestionsToResults(List<Question> questions) {
        Dictionary<string, Dictionary<string, int>> resultsDict = new Dictionary<string, Dictionary<string, int>>();
        foreach (Question question in questions) {
            string key = question.getTitle();
            if (!resultsDict.ContainsKey(key)) {
                resultsDict.Add(key, new Dictionary<string, int>());
                resultsDict[key].Add(question.answer, 1);
            }
            else if (!resultsDict[key].ContainsKey(question.answer)) {
                resultsDict[key].Add(question.answer, 1);
            } else {
                resultsDict[key][question.answer]++;
            }
        }

        

        List<ResultsModel> results = new List<ResultsModel>();
        foreach(KeyValuePair<string, Dictionary<string, int>> entry in resultsDict)
        {
            ResultsModel resultItem = new ResultsModel(entry.Key);
            foreach(KeyValuePair<string, int> innerEntry in entry.Value) {
                resultItem.addOptionResult(innerEntry.Key, innerEntry.Value);
            }
            results.Add(resultItem);
        }
        return results;
    }

    public void Run() {
        Console.WriteLine("Results");
        write();
        display();
    }

    private string toString() {
        string res = "";
        foreach (ResultsModel result in results) {
            res = res + result.toString();
        }
        return res;
    }

    public void write() {
        Console.WriteLine("Save results to file");
        File.WriteAllText(this.file_path, toString());
    }

    public void display() {
        Console.WriteLine("Display results to console");    
        Console.Write(toString());
    }
}