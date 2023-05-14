using TasksOrderVert1000.Controller;

namespace TasksOrderVert1000;

public class Program
{
    public static void Main()
    {
        while (true)
        {
            using (var _context = new Context.Context())
            {
                
                var _dispatcher = new Dispatcher(_context);
                switch (_dispatcher.Menu())
                {
                    case 1:                   
                        _dispatcher.CreateNewTask();
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        _dispatcher.DisplayTaskById();
                        break;
                    case 6:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}