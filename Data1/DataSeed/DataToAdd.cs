using System.Collections.Generic;

namespace Data1.DataSeed
{
    public static class DataToAdd
    {
        public static List<TraitEntity> GetTraits()
        {
            return new List<TraitEntity>
            {
                new TraitEntity
                {
                    Id = "facet_modesty",
                    MinVal = 0,
                    MaxVal = 60,
                    Text =
                        "need to work on his attitude a bit more. Modesty is not one of his strengths and is rather low."
                },
                new TraitEntity
                {
                    Id = "facet_modesty",
                    MinVal = 60,
                    MaxVal = 80,
                    Text =
                        "be a modest person. He cares about others but he does not necesarely miss an opportunity to brag with something he did."
                },
                new TraitEntity
                {
                    Id = "facet_modesty",
                    MinVal = 80,
                    MaxVal = 100,
                    Text =
                        "be a very modest person. When he talks about his achievments or strengths, he does not talk as if it was only his achievment but give credit to others."
                },
                new TraitEntity
                {
                    Id = "facet_intellect",
                    MinVal = 0,
                    MaxVal = 60,
                    Text = "a rather not intellectual person, but has other qualities."
                },
                new TraitEntity
                {
                    Id = "facet_intellect",
                    MinVal = 60,
                    MaxVal = 80,
                    Text =
                        "a mediocre person considering his intelligence through the way he also formulates his answers."
                },
                new TraitEntity
                {
                    Id = "facet_intellect",
                    MinVal = 80,
                    MaxVal = 100,
                    Text = "a rather quite intelligent and calculated person."
                },
                new TraitEntity
                {
                    Id = "facet_dutifulness",
                    MinVal = 0,
                    MaxVal = 60,
                    Text =
                        "unexpectedly lower that usual and would be a real concern, considering the need for fulfilling duties."
                },
                new TraitEntity
                {
                    Id = "facet_dutifulness",
                    MinVal = 60,
                    MaxVal = 80,
                    Text =
                        "normal, does not seem to have a special orientation towards fulfilling tasks in any special maner."
                },
                new TraitEntity
                {
                    Id = "facet_dutifulness",
                    MinVal = 80,
                    MaxVal = 100,
                    Text = "rather impressive, as he seems to speak as this would be important to achieve."
                },
                new TraitEntity
                {
                    Id = "facet_achievement_striving",
                    MinVal = 80,
                    MaxVal = 100,
                    Text =
                        "[name] seems like a person oriented to achieving more than it is expected. It makes efforts to achieve what is needed."
                }


                //"facet_achievement_striving",
                //"facet_altruism",
                //"facet_cooperation",
                //"facet_gregariousness",

                //"facet_adventurousness",
                //"need_challenge",
                //"need_stability",
                //"need_liberty",
                //"need_curiosity",

                //"facet_assertiveness",
                //"facet_self_discipline",
                //"need_harmony",
                //"need_structure",
                //"facet_self_efficacy"
            };
        }

        public static List<ParagraphEntity> GetParagraphs()
        {
            return new List<ParagraphEntity>
            {
                new ParagraphEntity
                {
                    ParagraphText =
                        "After analyzing the answers, here are the results. [name] seems to [modesty]. The way he speaks classifies him as [intelect]. As an individual, his task orientation is [dutifulness]. [Achievment striving]",
                    TypeId = ParagraphType.Personal
                },
                new ParagraphEntity
                {
                    ParagraphText = "Regarding the likelyhood for [name] to interact with coleagues, it appears to be [gregariousness]. [cooperation]. We have taken a look on how altruist the candidate is and we found rather [altruismStatus] results.",
                    TypeId = ParagraphType.Interpersonal
                },
                new ParagraphEntity
                {
                    ParagraphText = "We analyse what are the most important factors that motive a person and their needs. [stability, achievment striving, challenge, stability, liberty-curiosity] Here is the results of our test for [name]. [stability]",
                    TypeId = ParagraphType.Motivational
                },
                new ParagraphEntity
                {
                    ParagraphText = "[name] would [assertiveness]. Apart from this, we run an analysis to check for other skills and how he would integrate in the team. [discipline, harmony, stability]",
                    TypeId = ParagraphType.Leadership
                },
                new ParagraphEntity
                {
                    ParagraphText = "Regarding the likelyhood for [name] to interact with coleagues, it appears to be [gregariousness]. [cooperation]. We have taken a look on how altruist the candidate is and we found rather [altruismStatus] results.",
                    TypeId = ParagraphType.Organisational
                }
            };
        }
    }
}
