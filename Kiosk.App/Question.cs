public class Question{
    public string title;
    public List<string> answers;
    public string answer;

    public void setTitle(string title){
        this.title = title;
        answers = new List<string>();
    }

    public void addAnswers(string answer){
        answers.Add(answer);
    }

    public List<string> getAllAnswers(){
        return answers;
    }

    public string getTitle(){
        return title;
    }

}