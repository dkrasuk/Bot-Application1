using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System.Threading;

namespace Bot_Application1.Dialogs
{
    [Serializable]
    public class RootDialog : IDialog<object>
    {
        public Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);

            return Task.CompletedTask;
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<object> result)
        {
            var activity = await result as Activity;
            var text = activity.Text.ToString();



            if (text.Contains("заказ"))
            {
                await context.PostAsync($"Назовите код товара");
            }
            if (text.Contains("17865816"))
            {
                await context.PostAsync($"Двокамерний холодильник LG GA-B499TGBM");
                await context.PostAsync($"Подробнее: https://bt.rozetka.com.ua/ua/lg_ga-b499tgbm/p17865816/");
                await context.PostAsync($"25 999 грн");
                Thread.Sleep(1500);
                await context.PostAsync($"Какой вид оплаты интересует?");
            }
            if (text.Contains("наличные"))
            {
                await context.PostAsync($"Хорошо... Куда оформить доставку?");
            }
            if (text.Contains("НП"))
            {
                await context.PostAsync($"Отлично, отправим Вам {DateTime.Now.AddDays(1).ToLongDateString()}");
                Thread.Sleep(1500);
                await context.PostAsync($"Ваш заказ №: {Guid.NewGuid().ToString()} ");
                Thread.Sleep(750);
                await context.PostAsync($"Двокамерний холодильник LG GA-B499TGBM");
                Thread.Sleep(750);
                await context.PostAsync($"Общая стоимость с учетом доставки: 26 050 грн");
                Thread.Sleep(750);
                await context.PostAsync($"Все верно?");
            }
            if (text.Contains("да"))
            {
                await context.PostAsync($"Спасибо за заказ! До свидания!:)");
            }

            if (text.Contains("привет"))
            {
                await context.PostAsync($"Привет, Дмитрий! ID сессии:{activity.Id}");
            }
            else
            {
                await context.PostAsync($"Не понял, что Вы сказали :(");
            }
            




            context.Wait(MessageReceivedAsync);
        }
    }
}