using Microsoft.Bot.Builder.Dialogs;

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
    }
}