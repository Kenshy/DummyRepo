using System.Threading.Tasks;
using BotApp1.Extensions;
using Microsoft.Bot.Builder.Dialogs;

namespace BotApp1.Dialogs
{
    public class GreetingDialog : IDialog
    {
        private string _name;

        public GreetingDialog(string name = "")
        {
            _name = name;
        }
        public async Task StartAsync(IDialogContext context)
        {
            if (string.IsNullOrWhiteSpace(_name))
            {
                var hasName = context.GetProperty<string>("Name", out _name);
                if (hasName == false)
                    _name = "guest";
            }

            await context.PostAsync($"Hello {_name}! How may I be of service? To see what I can do, type \"help\"!");
            context.Done("Done");
        }
    }
}