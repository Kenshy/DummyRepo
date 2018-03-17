using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace BotApp1.Models
{
    [Serializable]
    public class UserModel
    {
        [Prompt("Name a place to know the current date-time:")]
        public string Name { get; set; }

        [Prompt("We would need your email to forward results of your interview step.")]
        [EmailAddress]
        public string Email { get; set; }

        public static IForm<UserModel> BuildForm()
        {
            return new FormBuilder<UserModel>()
                .OnCompletion(Process)
                .Build();
        }

        private static async Task Process(IDialogContext context, UserModel state)
        {
            return;
        }
    }
}