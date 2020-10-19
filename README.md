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
  
  ```bash
  "AppSettings": {
    "QuiplogsNotifications": {
      "Azure": {
        "DataConnectionString": "azure_connection_string",
        "EmailQueueName": "queue_name"
      },
      "Security": {
        "Key": "ecryption_key"
      }
    }
  ```
  
  3. Register Autofac and pass in IConfiguration
  
  ```bash
  IConfiguration Configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .Build();

  var builder = new ContainerBuilder();
  builder.RegisterModule(new SendNotificationModule(Configuration));
  var container = builder.Build();
  ```
  
  4. Create a email and send (This example uses the Templated Email from SendGrid)
  
  ```bash
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
 
 Still in progress*
 
 Receive an Azure queue message and send it off to SendGrid API
