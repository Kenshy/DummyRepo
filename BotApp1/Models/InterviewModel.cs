using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace BotApp1.Models
{
    [Serializable]
    public class InterviewModel
    {
        [Prompt("Name a place to know the current date-time:")]
        public string PlaceName { get; set; }

        [Prompt("This is just to see if it is working")]
        public string Q2 { get; set; }

        private static async Task Process(IDialogContext context, InterviewModel state)
        {
            await context.PostAsync("mesaj de verificare");
        }


        public static IForm<InterviewModel> BuildForm()
        {
            var builder = new FormBuilder<InterviewModel>()
                //.Field(new FieldReflector<InterviewModel>(nameof(PlaceName))
                //    .SetDefine(async (state, field) =>
                //    {
                //        var placeName = "randomPlaceName";
                //        field.AddDescription(placeName, "Descriere custom pt field");

                //        return true;
                //    }))
                //.Confirm("Is this your selection?\n{*}")
                //.OnCompletion(Process)
                .Build();

            return builder;
        }
    }
}