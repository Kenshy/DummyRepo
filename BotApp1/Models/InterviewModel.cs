using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BotApp1.Extensions;
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
        public string CompanyName;
        public string Q1 { get; set; }
        //[Prompt("{&}")]
        //public string Q2 { get; set; }
        //[Prompt("{&}")]
        //public string Q3 { get; set; }
        [Prompt("Intrebare random")]
        public string Random { get; set; }

        private static async Task Process(IDialogContext context, InterviewModel state)
        {
            await context.PostAsync("mesaj de verificare");
        }

        public static IForm<InterviewModel> BuildForm()
        {

            var question = "";
            var builder = new FormBuilder<InterviewModel>()
                .Field(new FieldReflector<InterviewModel>(nameof(CompanyName))
                    .SetType(null)
                    .SetPrompt(new PromptAttribute("Please tell me who do you interview with:{||}") { ChoiceStyle = ChoiceStyleOptions.Buttons })
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
                    .AddQuestion(nameof(Q1), Task.Run(() => GetQuestion("c1", 1)).Result)
                    //.Field(new FieldReflector<InterviewModel>(nameof(Q1))
                    //.SetDefine(async (state, field) =>
                    //{
                    //    field.SetPrompt(new PromptAttribute(await GetQuestion("c1", 1)) { ChoiceStyle = ChoiceStyleOptions.AutoText });
                    //    return true;
                    //}))
                    
                //.Field(new FieldReflector<InterviewModel>(nameof(Q1))
                //    .SetDefine(async (state, field) => field.AddDescription(GetQuestion(state, 1))))
                .AddRemainingFields()
                .Confirm("Is this your selection?\n{*}")
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