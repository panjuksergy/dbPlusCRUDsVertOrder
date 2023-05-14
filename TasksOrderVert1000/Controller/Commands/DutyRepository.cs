using System.Collections.Generic;
using System.Linq;
using TasksOrderVert1000.Context;
using TasksOrderVert1000.Model;

namespace TasksOrderVert1000.Repository
{
    public class DutyRepository
    {
        private readonly Context.Context _context;

        public DutyRepository(Context.Context context)
        {
            _context = context;
        }

        public IEnumerable<Duty> GetDuties()
        {
            return _context.Tasks.ToList();
        }

        public Duty GetDuty(int id)
        {
            return _context.Tasks.FirstOrDefault(d => d.DutyId == id);
        }

        public void AddDuty(Duty duty)
        {
            _context.Tasks.Add(duty);
            _context.SaveChanges();
        }

        public void UpdateDuty(int id, Duty duty)
        {
            var existingDuty = _context.Tasks.FirstOrDefault(d => d.DutyId == id);

            if (existingDuty != null)
            {
                existingDuty.DutyName = duty.DutyName;
                existingDuty.Description = duty.Description;
                existingDuty.Date = duty.Date;
                existingDuty.Priority = duty.Priority;

                _context.SaveChanges();
            }
        }

        public void UpdateDoneStatus(int id)
        {
            var existingDuty = _context.Tasks.FirstOrDefault(d => d.DutyId == id);
            if (existingDuty != null)
            {
                existingDuty.IsCompleted = true;
                _context.SaveChanges();
            }
        }

        public void DeleteDuty(int id)
        {
            var duty = _context.Tasks.FirstOrDefault(d => d.DutyId == id);
            if (duty != null)
            {
                _context.Tasks.Remove(duty);
                _context.SaveChanges();
            }
        }
    }
}