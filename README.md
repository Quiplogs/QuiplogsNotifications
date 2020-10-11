# Quiplogs Notifications

If you need to send notifications (only email for now) using twilio then this might be of use.

The application consists of a Send package which process the IEmail onto an Azure Queue and a Process package which will read the item in queue and send it using Twilio

Currently a work in progress. The console application is used to test the dll's

