namespace TasksOrderVert1000.View;

public class View
{
    public int DisplayMainMenu()
    {
        Console.WriteLine("Hello>. .<, this is Task Planner.\n" +
                          "Choose action which u want to do:\n" +
                          "1-Create new Task\n" +
                          "2-Update existing Task\n" +
                          "3-Delete existing Task\n" +
                          "4-Check all Tasks\n" +
                          "5-Display task by id\n" +
                          "6-Mark task done by id");
        var choosed = Console.ReadLine();
        int ch;
        bool check = false;
        int.TryParse(choosed, out ch);
        return ch;
    }

    public int ChooseTasksId()
    {
        Console.WriteLine("Please enter task`s Id");
        var choosed = Console.ReadLine();
        int ch;
        int.TryParse(choosed, out ch);
        return ch;
    }

    public string WriteNewTaskName()
    {
        Console.WriteLine("Please enter taks`s Name");
        var choosed = Console.ReadLine();
        return choosed;
    }

    public string WriteNewTaskDescription()
    {
        Console.WriteLine("Please enter taks`s Description");
        var choosed = Console.ReadLine();
        return choosed;
    }

    public int ChooseTasksPriority()
    {
        {
            Console.WriteLine("Please choose ur Taks`s priority (0-10)");
            var choosed = Console.ReadLine();
            int ch;
            bool check = false;
            int.TryParse(choosed, out ch);
            return ch;
        }
    }
}