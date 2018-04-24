using System;
using System.Threading.Tasks;
using BotApp1.Extensions;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace BotApp1.Models
{
    [Serializable]
    public class UserModel
    {
        private string _name;
        [Prompt("In order to proceed, we need your name.")]
        public string Name
        {
            get => _name;
            set => _name = value.CapitalizeWord();
        }

        [Prompt("Nice to meet you, {Name}! We would need your email to forward results of your interview step.\nPlease note that using an invalid email will make you unreachable to recruiters.")]
        [Pattern(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")]
        public string Email { get; set; }

        public static IForm<UserModel> BuildForm()
        {
            return new FormBuilder<UserModel>()
                .AddRemainingFields()
                .Confirm("Is everything we know correct? {*}{||}")
                .OnCompletion(Process)
                .Build();
        }

        private static async Task Process(IDialogContext context, UserModel state)
        {
            context.SetProperty(nameof(Name), state.Name);
            context.SetProperty(nameof(Email), state.Email);
        }
    }
}