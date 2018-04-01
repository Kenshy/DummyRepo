using BotApp1.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;

namespace BotApp1.Extensions
{
    public static class ChatbotExtensions
    {
        public static void SetProperty<T>(this IDialogContext context, string keyName, T value)
        {
            context.UserData.SetValue(keyName, value);
        }

        public static bool GetProperty<T>(this IDialogContext context, string keyName, out T value)
        {
            return context.UserData.TryGetValue<T>(keyName, out value);
        }

        public static string CapitalizeWord(this string value)
        {
            return !string.IsNullOrWhiteSpace(value) ? char.ToUpper(value[0]) + value.Substring(1) : null;
        }

        public static IFormBuilder<InterviewModel> AddQuestion(this IFormBuilder<InterviewModel> model, string fieldName, string prompt)
        {
            model.Field(new FieldReflector<InterviewModel>(fieldName)
                .SetDefine(async (state, field) =>
                {
                    field.SetPrompt(new PromptAttribute(prompt) {ChoiceStyle = ChoiceStyleOptions.AutoText});
                    return true;
                }));

            return model;
        }
    }
}