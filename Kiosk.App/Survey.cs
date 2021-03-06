using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Kiosk.App;

public class Survey
{


    private string _questionFile;
    private string _resultFile;

    public Survey()
    {
        var rootDir = AppContext.BaseDirectory + "/../../../../";
        _questionFile = rootDir + "questions.txt";
        _resultFile = "result.json";
    }
    public void Run()
    {
        var read = new Read(_questionFile);
        var questions = read.getAlllQuestions();
        if (questions != null)
        {
            var ask = new Ask();
            questions = ask.GetAnswers(questions);
            Results results = new Results(questions, _resultFile);
            results.write();
            results.display();

            Report report = new Report(_resultFile);
            report.parseFile();
            report.generateHTML();

        }
        else
        {
            Console.WriteLine("questions not found");
        }
    }
}
