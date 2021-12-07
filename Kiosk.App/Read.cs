using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Kiosk.App;

class Read {

    private List<Question> allQuestions;
    private string path;

    public Read(string path){
        this.path = path;
        allQuestions = new List<Question>();
        Console.WriteLine("Questions file contains:");
        ReadQuestionsFile();

    }

    public List<Question> getAlllQuestions(){
        return allQuestions;
    }

    // this is just an example of how to read a file,
    // modify/delete as you see fit.
    private void ReadQuestionsFile() {
        // we run in <root>/Kiosk.App/bin/Debug/net6.0, so gotta go up 4 levels
        string[] lines = File.ReadAllLines(this.path);

        int index = 0;

        while(index < lines.Length){
            
            string line = lines[index];
            if(String.IsNullOrEmpty(line)){
                index++;
                continue;
            }

             Console.WriteLine(line);
            if(line.Contains("?")){
                Question newQuestion = new Question();
                newQuestion.setTitle(line);
                index++;
                while(index < lines.Length && lines[index].Contains("-") ){
                    newQuestion.addAnswers(lines[index].Substring(1));
                    index++;
                }
                allQuestions.Add(newQuestion);
            }
        }
    }
}