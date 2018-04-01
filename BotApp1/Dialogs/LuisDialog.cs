using System;
using System.Threading.Tasks;
using BotApp1.Extensions;
using BotApp1.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

namespace BotApp1.Dialogs
{
    [LuisModel("aebc8cb8-4008-47be-baf9-441b4e852a6e","f30de8e9b49547688d1371e738f785b3")]
    [Serializable]
    public class LuisDialog : LuisDialog <InterviewModel>
    {
        private readonly BuildFormDelegate<UserModel> _userModel;
        private readonly BuildFormDelegate<InterviewModel> _interviewModel;

        public LuisDialog(BuildFormDelegate<UserModel> userModel, BuildFormDelegate<InterviewModel> interviewModel)
        {
            _userModel = userModel;
            _interviewModel = interviewModel;
        }

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("I am sorry, I did not understand.");
            context.Wait(MessageReceived);
        }

        [LuisIntent("Introduction")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Hello! I will be your guide today.");
            var userModel = new UserModel();
            if (result.TryFindEntity("CandidateName", out EntityRecommendation candidate))
            {
                userModel.Name = candidate.Entity;
            }
            else
            {
                if (context.GetProperty<string>(nameof(userModel.Name), out var name))
                    userModel.Name = name;
            }

            var hasMail = context.GetProperty<string>(nameof(userModel.Email), out var email);
            if (hasMail)
                userModel.Email = email;

            var registrationForm = new FormDialog<UserModel>(userModel, _userModel, FormOptions.PromptInStart);
            context.Call(registrationForm, GreetingCallback);
        }

        [LuisIntent("Interview")]
        private async Task StartInterview(IDialogContext context, LuisResult result)
        {
            //if(result)
            var interviewForm =
                new FormDialog<InterviewModel>(new InterviewModel(), _interviewModel, FormOptions.PromptInStart);
            context.Call<InterviewModel>(interviewForm, Callback);
        }

        private async Task GreetingCallback(IDialogContext context, IAwaitable<UserModel> result)
        {
            var userData = await result;
            await context.PostAsync($"Great job, {userData.Name}! What can I do for you? Check for some interviews, offer you an interview with a specific company?");
            context.Wait(MessageReceived);
        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }
    }
}