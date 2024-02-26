using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day40_Task.Models
{
    internal class Speaker
    {

        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Company { get; set; }
        public string ImageURL { get; set; }

        public override string ToString()
        {
            return $"Id - {Id}, Fullname - {Fullname}, Position - {Position}, Company - {Company}, ImageURL - {ImageURL}";
        }

    }
}
