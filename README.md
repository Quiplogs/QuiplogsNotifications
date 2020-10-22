# Quiplogs Notifications (Email only. SMS support coming soon)

This project arose around a need to be able to send Notifications to an Azure queue and then have that queue be processed and sent off to a third party for porcessing (SendGrid).

This project produces TWO Nuget Packages.

  1. Quiplogs.Notifications.Send - The package takes an type of IEmail and send it to the Azure Queue
  2. Quiplogs.Notifications.Process - The package processes a queue item and sends it off to the SendGrid API
  
## Requirements

  1. Azure Subscription with Azure storage to utilize the Queue
  2. SendGrid Account  
 
## Quiplogs.Notifications.Send

Installing using this package is done in 4 steps

  1. Install the Quiplogs.Notifications.Send nuget package

  2. Add configuration to appsettings.json
  
  ```json
  "AppSettings": {
    "QuiplogsNotifications": {
      "Azure": {
        "DataConnectionString": "azure_connection_string",
        "EmailQueueName": "queue_name"
      },
      "Security": {
        "Key": "ecryption_key" e.g. b14ca5898a4e4133bbce2ea2315a1916
      }
    }
  ```
  
  3. Register Autofac and pass in IConfiguration
  
  ```csharp
  IConfiguration Configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

  var builder = new ContainerBuilder();
  builder.RegisterModule(new SendNotificationModule(Configuration));
  var container = builder.Build();
  ```
  
  4. Create a email and send (This example uses the Templated Email from SendGrid)
  
  ```csharp
  var tags = new Dictionary<string, string>();
  tags.Add("first_name", "first name");
  tags.Add("last_name", "last name");

  var email = new EmailWithTemplate
  {
      TemplateId = "SendGrid Template GUID",
      FromEmailAddress = "from email",
      FromName = "from name",
      ToEmailAddress = "to email",
      ToName = "to name",
      Subject = "email subject",
      ReplacementTags = tags
  };

  var sendService = container.Resolve<ISendService>();
  sendService.SendNotification(email);
  ```
  
 ## Quiplogs.Notification.Process
 
 Installing using this package is done in 6 steps
 
  1. Install nuget package Quiplogs.Notification.Process 1.0.1
  
  2. Add Configuration Settings
      - SENDGRID_API_KEY (Your generated SendGrid API Key)
      - SECURITY_KEY (same security token you used in the "Send module" e.g. b14ca5898a4e4133bbce2ea2315a1916)
  
  3. Reference the following packages
  
  ```csharp
  using AzureFunctions.Autofac;
  using Quiplogs.Notifications.Process;
  using Quiplogs.Notifications.Process.Interfaces;
  ```
  4. Add "[DependencyInjectionConfig(typeof(ProcessNotificationModule))]" as an attribute to your Azure Queue function class
  
  5. Change Run() Signature
      - inject ISendGridService
      - change input from string to byte[] (email gets stored as byte[] in queue)
      - change queue name to where you store emails
      - set connection config variable
  
  ```csharp
  [QueueTrigger("set yhe queue name for your email", Connection = "set connection string key")] byte[] encryptedMail, [Inject] ISendGridService sendGridService, ILogger log)
  ```
  
  6. Call send grid service
  
  ```csharp
  sendGridService.SendMail(encryptedMail);
  ```
  
  The function as a whole will look like the following example
  
  ```csharp
  using AzureFunctions.Autofac;
  using Quiplogs.Notifications.Process;
  using Quiplogs.Notifications.Process.Interfaces;
  using Microsoft.Azure.WebJobs;
  using Microsoft.Extensions.Logging;

  namespace FunctionApp1
  {
        [DependencyInjectionConfig(typeof(ProcessNotificationModule))]
        public static class EmailQueueFunction
        {
            [FunctionName("EmailQueueFunction")]
            public static void Run([QueueTrigger("twilioemailqueue", Connection = "AzureWebJobsStorage")] byte[] encryptedMail, [Inject] ISendGridService sendGridService, ILogger log)
            {
                sendGridService.SendMail(encryptedMail);
                log.LogInformation($"Emailed sent");
            }
        }
  }
  ```
