using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BotApp1.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;

namespace BotApp1.Dialogs
{
    public class InterviewDialog
    {
        public static readonly IDialog<string> dialog = Chain.PostToChain()
            .Select(msg => msg.Text)
            .Switch(
                new RegexCase<IDialog<string>>(new Regex(".* hi .*", RegexOptions.IgnoreCase), (context, text) =>
                {
                    return FormDialog.FromForm(InterviewModel.BuildForm, FormOptions.PromptInStart).ContinueWith(AfterMyDialogContinue);
                }),
                new DefaultCase<string, IDialog<string>>((context, text) =>
                {
                    return FormDialog.FromForm(InterviewModel.BuildForm, FormOptions.PromptInStart).ContinueWith(AfterMyDialogContinue);
                }))
            .Unwrap()
            .PostToUser();

        internal static IDialog<InterviewModel> MakeRootDialog()
            {
                return Chain.From(() => FormDialog.FromForm(InterviewModel.BuildForm));
            }



        private async static Task<IDialog<string>> AfterMyDialogContinue(IBotContext context, IAwaitable<object> item)
        {
            return Chain.Return("Your interview has been completed, thanks for your time.");
        }
    }
}