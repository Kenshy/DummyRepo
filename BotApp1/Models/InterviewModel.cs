using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotApp1.Services.Contracts;
using BotApp1.Services.Data;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.FormFlow.Advanced;

namespace BotApp1.Models
{
    [Serializable]
    public class InterviewModel
    {
        [Template(TemplateUsage.NotUnderstood, "Sorry , \"{0}\" is not an option I understand.", "Try again, I don't get \"{0}\".", "Care to rephrase a bit? I did not understand \"{0}\"")]
        public string CompanyName;
        public string Q1 { get; set; }
        public string Q2 { get; set; }
        public string Q3 { get; set; }
        public string Q4 { get; set; }
        //public string Q5 { get; set; }
        //public string Q6 { get; set; }
        //public string Q7 { get; set; }
        //public string Q8 { get; set; }
        //public string Q9 { get; set; }
        //public string Q10 { get; set; }
        //public string Q11 { get; set; }
        //public string Q12 { get; set; }
        //public string Q13 { get; set; }

        private static async Task Process(IDialogContext context, InterviewModel state)
        {
var hasName = context.UserData.TryGetValue<string>("Name", out var name);
var hasEmail = context.UserData.TryGetValue<string>("Email", out var email);

            if(hasEmail)
                await ProcessUser(state, hasName ? name: "guest", email);
        }

        private static async Task ProcessUser(InterviewModel state, string name, string email)
        {
            var service = new InterviewApiService("http://localhost:5000");
            await service.ProcessUser(state, name, email);
        }

        public static IForm<InterviewModel> BuildForm()
        {
            var builder = new FormBuilder<InterviewModel>()
                .Field(new FieldReflector<InterviewModel>(nameof(CompanyName))
                    .SetType(null)
                    .SetPrompt(new PromptAttribute("Please tell me who do you interview with:{||}")
                    {
                        ChoiceStyle = ChoiceStyleOptions.Buttons
                    })
                    .SetDefine(async (state, field) =>
                    {
                        var companies = await GetCompanies();
                        foreach (var company in companies)
                            field
                                .AddDescription(company.CompanyId.ToString(), company.CompanyName)
                                .AddTerms(company.CompanyId.ToString(), company.CompanyName, company.ShortName);

                        field.Template(TemplateUsage.EnumSelectOne).ChoiceStyle = ChoiceStyleOptions.PerLine;
                        return true;
                    }))
                .Field(new FieldReflector<InterviewModel>(nameof(Q1))
                    .SetDefine(async (state, field) =>
                    {
                        field.SetPrompt(
                            new PromptAttribute(await GetQuestion(state.CompanyName, 1))
                            {
                                ChoiceStyle = ChoiceStyleOptions.AutoText
                            });
                        return true;
                    }))

                .Field(new FieldReflector<InterviewModel>(nameof(Q2))
                    .SetDefine(async (state, field) =>
                    {
                        field.SetPrompt(
                            new PromptAttribute(await GetQuestion(state.CompanyName, 2))
                            {
                                ChoiceStyle = ChoiceStyleOptions.AutoText
                            });
                        return true;
                    }))

                .Field(new FieldReflector<InterviewModel>(nameof(Q3))
                    .SetDefine(async (state, field) =>
                    {
                        field.SetPrompt(
                            new PromptAttribute(await GetQuestion(state.CompanyName, 3))
                            {
                                ChoiceStyle = ChoiceStyleOptions.AutoText
                            });
                        return true;
                    }))

                .Field(new FieldReflector<InterviewModel>(nameof(Q4))
                    .SetDefine(async (state, field) =>
                    {
                        field.SetPrompt(
                            new PromptAttribute(await GetQuestion(state.CompanyName, 4))
                            {
                                ChoiceStyle = ChoiceStyleOptions.AutoText
                            });
                        return true;
                    }))

                //.Field(new FieldReflector<InterviewModel>(nameof(Q5))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 5))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))

                //.Field(new FieldReflector<InterviewModel>(nameof(Q6))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 6))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))

                //.Field(new FieldReflector<InterviewModel>(nameof(Q7))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 7))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))

                //.Field(new FieldReflector<InterviewModel>(nameof(Q8))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 8))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))
                //.Field(new FieldReflector<InterviewModel>(nameof(Q9))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 9))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))
                //.Field(new FieldReflector<InterviewModel>(nameof(Q10))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 10))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))
                //.Field(new FieldReflector<InterviewModel>(nameof(Q11))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 11))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))
                //.Field(new FieldReflector<InterviewModel>(nameof(Q12))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 12))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))
                //.Field(new FieldReflector<InterviewModel>(nameof(Q13))
                //    .SetDefine(async (state, field) =>
                //    {
                //        field.SetPrompt(
                //            new PromptAttribute(await GetQuestion(state.CompanyName, 13))
                //            {
                //                ChoiceStyle = ChoiceStyleOptions.AutoText
                //            });
                //        return true;
                //    }))
                .AddRemainingFields()
                .Confirm("Here is a short review of all your answers. Is this right?\n{*}{||}")
                .OnCompletion(Process)
                .Build();

            return builder;
        }

        private static async Task<List<CompanyDto>> GetCompanies()
        {
            var service = new InterviewApiService("http://localhost:5000");
            return await service.GetCompanies();
        }

        private static async Task<string> GetQuestion(string companyName, int questionId)
        {
            var service = new InterviewApiService("http://localhost:5000");
            
            return await service.GetQuestion(companyName, questionId);
        }
    }
}