using System;
using System.Collections.Generic;
using System.Text;

namespace ReminderBot.Models
{
    public class Reminder
    {
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
    }
}
