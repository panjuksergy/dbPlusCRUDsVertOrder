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
        
    }

    public void DeleteTask()
    {
        
    }

    public void ListAllTasks()
    {
        
    }

    public void DisplayTaskById()
    {
        
    }

    public void MarkTaskDonteById()
    {
        
    }
}