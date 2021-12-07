using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Kiosk.App;

class Ask {

    public void Run(){
        Question q1 = new Question();
        q1.setTitle("what is your name?");
        q1.answers = new List<string>();

        Question q2 = new Question();
        q2.setTitle("what do you want to choose: Pissa, Lahmacun, Bitterball");
        q2.answers = new List<string>();
        

        List<Question> lists = new List<Question>();
        lists.Add(q1);
        lists.Add(q2);

        GetAnswers(lists);

    }

    public List<Question> GetAnswers(List<Question> lists) {

        if(lists != null){
            foreach (var item in lists)
                    {
                        if(item != null){
                        Console.WriteLine(item.getTitle());
                        foreach(var possibleAnswer in item.answers)
                        {
                            Console.WriteLine(possibleAnswer);
                        }            
                        item.answer = Console.ReadLine()!;
                        Console.WriteLine("The one I want is: " + item.answer);
                        }
                        

                    }
                return lists;
        }
        else{
            return null;
        }
        
        
    }
}