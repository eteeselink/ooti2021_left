using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Kiosk.App;

class Ask {

    public void Run(){
        Question q1 = new Question();
        q1.setTitle("what is your name?");

        Question q2 = new Question();
        q2.setTitle("what do you want to choose: Pissa, Lahmacun, Bitterball");
        

        List<Question> lists = new List<Question>();
        lists.Add(q1);
        lists.Add(q2);

        ask(lists);

    }


    public List<Question> ask(List<Question> lists) {

        foreach (var item in lists)
        {
            Console.WriteLine(item.getTitle());
            item.answer = Console.ReadLine()!;
            Console.WriteLine("The one I want is: " + item.answer);

        }
       return lists;
        
    }
}