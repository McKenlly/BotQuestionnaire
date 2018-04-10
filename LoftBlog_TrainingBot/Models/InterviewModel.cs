using System;
using System.Collections.Generic;
using LoftBlog_TrainingBot.Attributes;

using Microsoft.Bot.Builder.FormFlow;

namespace LoftBlog_TrainingBot.Models
{
    public enum QuestionsOneOptions
    {
        One = 2,
        Two = 4,
        Three = 6
    };
    public enum QuestionsTwoOptions
    {
        One,
        Two, 
        Three,
        Four
    };
    public enum QuestionsThreeOptions
    {
        One,
        Two,
        Three,
        Four
    };
    public enum QuestionsFourOptions
    {
        Один,
        Два,
        Три,
        Четыре
     };


    [Serializable]
    public class InterviewInfo
    {
        [LocalizableDescribe("QuestionOne", typeof(Resources.Resources))]
        public QuestionsOneOptions? One;

        [LocalizableDescribe("QuestionTwo", typeof(Resources.Resources))]
        public QuestionsTwoOptions? Two;

        [LocalizableDescribe("QuestionThree", typeof(Resources.Resources))]
        public QuestionsThreeOptions? Three;

        [LocalizableDescribe("QuestionFour", typeof(Resources.Resources))]
        public QuestionsFourOptions? Four;


        public static IForm<InterviewInfo> BuildForm()
        {
            return new FormBuilder<InterviewInfo>().Build();
        }
    };
}