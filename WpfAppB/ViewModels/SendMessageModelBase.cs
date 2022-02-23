using Azure.Messaging.ServiceBus;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WpfAppB.Models;

namespace WpfAppB.ViewModels
{
    internal class SendMessageModelBase
    {

        public async Task<ObservableCollection<RecieveMessage>> GetSendMessagesAsync()
        {
            Models.RecieveMessage recmsg = new Models.RecieveMessage();

            recmsg.connectionString = "Endpoint=sb://appcomm.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e58SZV3vWGbcSdIUlGOfOBCX49Ln5OW4qBAzwsmpTSE=";
            recmsg.queueName = "tparchilogiciel";

            recmsg.client = new ServiceBusClient(recmsg.connectionString);
            recmsg.processor = recmsg.client.CreateProcessor(recmsg.queueName, new ServiceBusProcessorOptions());

            static async Task<string> MessageHandler(ProcessMessageEventArgs args)
            {
                string body = args.Message.Body.ToString();

                await args.CompleteMessageAsync(args.Message);
                return body;
            }

            static Task ErrorHandler(ProcessErrorEventArgs args)
            {
                //Console.WriteLine(args.Exception.ToString());
                return Task.CompletedTask;
            }

            try
            {
                // add handler to process messages
                recmsg.processor.ProcessMessageAsync += MessageHandler;

                // add handler to process any errors
                recmsg.processor.ProcessErrorAsync += ErrorHandler;

                // start processing 
                await recmsg.processor.StartProcessingAsync();




                await recmsg.processor.StopProcessingAsync();

            }
            finally
            {

                await recmsg.processor.DisposeAsync();
                await recmsg.client.DisposeAsync();
            }

        }
    }
}