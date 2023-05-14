using TasksOrderVert1000.Model;
using TasksOrderVert1000.Repository;

namespace TasksOrderVert1000.Controller.DutyController;

public class Controller
{
    private View.View _view;
    private DutyRepository _dutyRepository;
    public Controller(View.View view, DutyRepository dutyRepository)
    {
        _view = view;
        _dutyRepository = dutyRepository;
    }

    public IEnumerable<Duty> SortedByPriority(List<Duty> inList)
    {
        return inList.OrderBy(d => d.Priority);
    }

    public IEnumerable<Duty> SortedByDate(List<Duty> inList)
    {
        return inList.OrderBy(d => d.Date);
    }

    public string ValidateNameInput()
    {
        string input = _view.WriteNewTaskName();
        if (input.Length <= 30)
        {
            return input;
        }
        ValidateNameInput();
        return "";
    }

    public string ValidateDescriptionInput()
    {
        string input = _view.WriteNewTaskDescription();
        if (input.Length <= 300)
        {
            return input;
        }
        ValidateDescriptionInput();
        return "";
    }

    public int ValidatePriorityView()
    {
        int input = _view.ChooseTasksPriority();
        for (int i = 0; i < 10; i++)
        {
            if (input == i)
            {
                return input;
            }
        }

        ValidatePriorityView();
        return -1;
    }
}