using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LoftBlog_TrainingBot.Interfaces;
using LoftBlog_TrainingBot.Models;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Connector;

namespace LoftBlog_TrainingBot.Commands
{
    [Serializable]
    public class Questions : ITool
    {
        public string Description { get; set; }
        public List<string> CommandsName { get; set; }
        public bool IsAdmin { get; set; }

        public Questions()
        {
            Description = "Викторина для квеста ImagineCup";
            CommandsName = new List<string>() { "/questions" };
        }

        public virtual async Task Run(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as Activity;
            if (activity?.Conversation != null)
            {
                await context.Forward(MakeInterviewDialog(), ResumeAfterNewDialog, activity, CancellationToken.None);
            }
        }


        internal static IDialog<InterviewInfo> MakeInterviewDialog()
        {
            return Chain.From(() => FormDialog.FromForm(InterviewInfo.BuildForm));
        }

        private async Task ResumeAfterNewDialog(IDialogContext context, IAwaitable<object> result)
        {
            var answers = await result as InterviewInfo;
            if (answers != null)
            {
                await context.PostAsync("Ваши данные успешно получены. Спасибо!");
                context.Done(result);
            }
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(Run);
        }

    }
}