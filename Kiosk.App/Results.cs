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

    public Results() {
        // Dummy initialization 
        List<Question> questions = new List<Question>();
        List<string> options = new List<string>(new string[] { "1", "2", "3" });
        Question question1 = new Question();
        question1.title = "question1";
        question1.answers = options;
        question1.answer = "1";
        
        Question question2 = new Question();
        question2.title = "question1";
        question2.answers = options;
        question2.answer = "1";
        
        Question question3 = new Question();
        question3.title = "question1";
        question3.answers = options;
        question3.answer = "2";

        Question question4 = new Question();
        question4.title = "question1";
        question4.answers = options;
        question4.answer = "2";

        Question question5 = new Question();
        question5.title = "question1";
        question5.answers = options;
        question5.answer = "2";

        Question question6 = new Question();
        question6.title = "question1";
        question6.answers = options;
        question6.answer = "3";

        questions.Add(question1);
        questions.Add(question2);
        questions.Add(question3);
        questions.Add(question4);
        questions.Add(question5);
        questions.Add(question6);

        // this.file_path = file_path;
        results = tranformQuestionsToResults(questions);
    }

    private List<ResultsModel> tranformQuestionsToResults(List<Question> questions) {
        Dictionary<string, Dictionary<string, int>> resultsDict = new Dictionary<string, Dictionary<string, int>>();
        foreach (Question question in questions) {
            string key = question.title;
            if (!resultsDict.ContainsKey(key)) {
                resultsDict.Add(key, new Dictionary<string, int>());
                resultsDict[key].Add(question.answer, 1);
                Console.WriteLine(key + " " + question.answer + " " + 1);
            }
            else if (!resultsDict[key].ContainsKey(question.answer)) {
                resultsDict[key].Add(question.answer, 1);
                Console.WriteLine(key + " " + question.answer + " " + 1);
            } else {
                resultsDict[key][question.answer]++;
                Console.WriteLine(key + " " + question.answer + " " + resultsDict[key][question.answer]);
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