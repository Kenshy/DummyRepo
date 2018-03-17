using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using BotApp1.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;

namespace BotApp1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {

            //var message = await result; // We've got a message!
            //if (message.Text.Length > 0)
            //{
            //    // User said 'order', so invoke the New Order Dialog and wait for it to finish.
            //    // Then, call ResumeAfterNewOrderDialog.
            //    await context.Call(this.MessageReceivedAsync, message, CancellationToken.None);
            //}
            //// User typed something else; for simplicity, ignore this input and wait for the next message.
            //context.Wait(this.MessageReceivedAsync);

            await context.PostAsync("xHello and welcome!");

            var activity = await result as Activity;

            // calculate something for us to return
            int length = (activity.Text ?? string.Empty).Length;

            // return our reply to the user
            await context.PostAsync($"You sent {activity.Text} which was {length} characters");

            context.Wait(MessageReceivedAsync);
        }

        private async Task ResumeAfterNewOrderDialog(IDialogContext context, IAwaitable<string> result)
        {
            await context.PostAsync($"New order dialog just told me this: {await result}");

            // Again, wait for the next message from the user.
            context.Wait(this.MessageReceivedAsync);
        }
    }
}