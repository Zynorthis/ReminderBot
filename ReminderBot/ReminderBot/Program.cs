using ReminderBot.Bot;
using System;

namespace ReminderBot
{
    class Program
    {
        static void Main(string[] args)
        {
            ReminderBotClient reminderBot = new ReminderBotClient("bot-token");
            reminderBot.StartBotAsync().GetAwaiter().GetResult();
            reminderBot.SendTestPrivateMessage(123456789012345678990).GetAwaiter().GetResult();
            reminderBot.DisconnectBotAsync().GetAwaiter().GetResult();
        }
    }
}
