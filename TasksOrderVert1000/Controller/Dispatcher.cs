using TasksOrderVert1000.Model;
using TasksOrderVert1000.Repository;

namespace TasksOrderVert1000.Controller;

public class Dispatcher
{
    private static Context.Context _context = new Context.Context();
    private static View.View _view = new View.View();
    private static DutyRepository _dutyRepository = new DutyRepository(_context);
    private DutyController.Controller _controller = new DutyController.Controller(_view, _dutyRepository);

    public Dispatcher(Context.Context context)
    {
        _context = context;
    }

    public int Menu() => _view.DisplayMainMenu();

    public void CreateNewTask()
    {
        Duty newDuty = new Duty()
        {
            DutyName = _controller.ValidateNameInput(),
            Description = _controller.ValidateDescriptionInput(),
            Date = DateTime.Now,
            Priority = _controller.ValidatePriorityView(),
        };
        _dutyRepository.AddDuty(newDuty);
    }

    public void UpdateTask()
    {
        var id = _view.ChooseTasksId();
        if (_dutyRepository.GetDuty(id) != null)
        {
            var newDuty = new Duty()
            {
                DutyName = _controller.ValidateNameInput(),
                Description = _controller.ValidateDescriptionInput(),
                Priority = _controller.ValidatePriorityView()
            };
            _dutyRepository.UpdateDuty(id, newDuty);
        }
    }

    public void UpdateDoneStatus()
    {
        var id = _view.ChooseTasksId();
        if (_dutyRepository.GetDuty(id) != null)
        {
            _dutyRepository.UpdateDoneStatus(id);
        }
        else
        {
            Console.WriteLine("Task doesnt exist, try again");
            UpdateDoneStatus();
        }
    }

    public void DeleteTask()
    {
        var id = _view.ChooseTasksId();
        if (_dutyRepository.GetDuty(id) != null)
        {
            _dutyRepository.DeleteDuty(id);
        }
        else
        {
            Console.WriteLine("Task doesnt exist, try again");
            DeleteTask();
        }
    }

    public void ListAllTasks()
    {
        var duties = _dutyRepository.GetDuties();
        foreach (var duty in duties)
        {
            _view.DisplayTask(duty);
        }

        switch (_controller.ValidateListMenu())
        {
            case 1:
                var sorted1 = _controller.SortedByDate(duties);
                foreach (var duty1 in sorted1)
                {
                    _view.DisplayTask(duty1);
                }
                break;
            case 2:
                var sorted2 = _controller.SortedByPriority(duties);
                foreach (var duty2 in sorted2)
                {
                    _view.DisplayTask(duty2);
                }
                break;
            case 3:
                break;
        }
    }

    public void DisplayTaskById()
    {
        var id = _controller.ValidateId(_view.ChooseTasksId());
        if (id == -404)
        {
            Console.WriteLine("Error Input");
            DisplayTaskById();
        }
        var readDuty = _dutyRepository.GetDuty(id);
        if (readDuty != null)
        {
            _view.DisplayTask(readDuty);
        }
        else
        {
            Console.WriteLine("Task doesnt exist, try again");
            DisplayTaskById();
        }
    }

    public void MarkTaskDonteById()
    {
        
    }
}