using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day40_Task.Models
{
    internal class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public string Address { get; set; }
        public DateOnly StartDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public override string ToString()
        {
            return $"Id - {Id}, Name - {Name}, Desc - {Desc}, Address - {Address}, StartDate - {StartDate}, StartTime - {StartTime}, EndTime - {EndTime}";
        }
    }
}
