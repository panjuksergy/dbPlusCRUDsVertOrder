using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TasksOrderVert1000.Model;

public class Duty
{ public int DutyId { get; set; }
    public string DutyName { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public int Priority { get; set; }
    public bool IsCompleted { get; set; }
}