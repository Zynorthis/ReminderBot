using DSharpPlus;
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderBot.Bot
{
    public class ReminderBotClient
    {
        private static string _token = "bot-token";
        private ulong _guildId;
        private DiscordClient _discordClient;

        public ReminderBotClient(string token)
        {
            _token = token;
            _guildId = 12345678901234567890;
            _discordClient = SetupClient();
        }
        public async Task StartBotAsync()
        {
            Console.WriteLine("Attempting to Connect To Server...");
            _discordClient = SetupClient();
            await _discordClient.ConnectAsync();
            Console.WriteLine("Connected To Server.");
        }

        public async Task DisconnectBotAsync()
        {
            Console.WriteLine("Disconnecting Bot From Server.");
            await _discordClient.DisconnectAsync();
            Console.WriteLine("Bot Disconnected Successfully.");
        }

        private DiscordClient SetupClient()
        {
            var discordClient = new DiscordClient(new DiscordConfiguration()
            {
                Token = _token,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.AllUnprivileged
            });
            return discordClient;
        }

        public void UpdateToken(string newTokenValue)
        {
            _token = newTokenValue;
        }

        private async Task<DiscordGuild> GetGuild()
        {
            var guild = await _discordClient.GetGuildAsync(_guildId);
            return guild;
        }

        public async Task SendTestPrivateMessage(ulong userId)
        {
            var guild = GetGuild().Result;
            var guildMember = await guild.GetMemberAsync(userId);

            await guildMember.SendMessageAsync("Beep Boop, Hello! I am a bot that your Jacob build to send reminders automatically while he's sleeping. \n\nToday's Reminder: You're a wonderful person!");
        }

        public async Task SendPrivateMessage(ulong userId, string message)
        {
            var guild = GetGuild().Result;
            var guildMember = await guild.GetMemberAsync(userId);
            await guildMember.SendMessageAsync(message);
        }
    }
}
