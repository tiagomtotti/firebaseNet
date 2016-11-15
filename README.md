[![NuGet version](https://badge.fury.io/nu/firebaseNet.svg)](https://badge.fury.io/nu/firebaseNet)

# firebaseNet
Client library for Firebase Cloud Messaging (FCM) written in C# / .NET.

This library provides a simple way in pure C# to send messages using the FCM HTTP connection servers. All JSON serialization/deserialization and HTTP related stuff is done automatically for you =).

## Sending your first message

To send a message using the FCM C# client, first you'll need to get your project `Server Key`.
The server key authorizes your app server for access to Google services, including sending messages via Firebase Cloud Messaging. You obtain the server key when you create your Firebase project. You can view it in the [Cloud Messaging](https://console.firebase.google.com/project/_/settings/cloudmessaging) tab of the Firebase console ***Settings*** pane.


Once you have your server key, use it to initialize the FCMClient:

```c#
FCMClient client = new FCMClient("your-server-key");
```

Now it's time to send the message:

```c#
var message = new Message()
{
    To = "bk3RNwTe3H0:CI2k_HHwgIpoDKCIZvvDMExUdFQ3P1...",
};
var result = await client.SendMessageAsync(message);

```

This is the smallest possible request (a message without any parameters and just one recipient).

**Tip:** If you provide an invalid Server Key, the SendMessageAsync method will throw a `FCMUnauthorizedException`.

## Message Types

With FCM, you can send two types of messages to clients:

- Notification messages, sometimes thought of as "display messages."
- Data messages, which are handled by the client app.

A notification message is the more lightweight option, with a 2KB limit and a predefined set of user-visible keys. Data messages let developers send up to 4KB of custom key-value pairs. Notification messages can contain an optional data payload, which is delivered when users tap on the notification.

### Notification Messages

To send notification messages, set the `Notification` property with the necessary predefined set of key options for the user-visible part of the notification message. For example, here is a notification message in an IM app. The user can expect to see a message with the title "Portugal vs. Denmark" and text "great match!" on the device:

```c#
FCMClient client = new FCMClient(ServerApiKey);

var message = new Message()
{
    To = "bk3RNwTe3H0:CI2k_HHwgIpoDKCIZvvDMExUdFQ3P1...",
    Notification = new AndroidNotification()
    {
        Body = "great match!",
        Title = "Portugal vs. Denmark",
        Icon = "myIcon"
    }
};

var result = await client.SendMessageAsync(message);
```

### Data Messages

Set the `Data` property with your custom key-value pairs to send a data payload to the client app. Data messages can have a 4KB maximum payload.

For example, here is a in the same IM app as above, where the information is encapsulated in the data key and the client app is expected to interpret the content:

```c#
FCMClient client = new FCMClient(ServerApiKey);

var message = new Message()
{
    To = "bk3RNwTe3H0:CI2k_HHwgIpoDKCIZvvDMExUdFQ3P1...",
	Data = new Dictionary<string, string>
    {
        { "Nick", "Mario" },
        { "body", "great match!" },
		{ "Room", "PortugalVSDenmark" }
    }
};

var result = await client.SendMessageAsync(message);
```

### Messages with both notification and data payloads

App behavior when receiving messages that include both notification and data payloads depends on whether the app is in the background or the foreground—essentially, whether or not it is active at the time of receipt.
- **When in the background**, apps receive the notification payload in the notification tray, and only handle the data payload when the user taps on the notification.
- **When in the foreground**, your app receives a message object with both payloads available.

Here is a message containing both the `Notification` property `Data` property:

```c#
FCMClient client = new FCMClient(ServerApiKey);

var message = new Message()
{
    To = "bk3RNwTe3H0:CI2k_HHwgIpoDKCIZvvDMExUdFQ3P1...",
    Notification = new AndroidNotification()
    {
        Body = "great match!",
        Title = "Portugal vss Denmark",
        Icon = "myIcon"
    },
    Data = new Dictionary<string, string>
    {
        { "score", "5x1" },
        { "time", "15:10" }
    }
};

var result = await client.SendMessageAsync(message);
```

More details about FCM messages can be found in the product documentation at: 
- https://firebase.google.com/docs/cloud-messaging/concept-options
- https://firebase.google.com/docs/cloud-messaging/server?hl=en-us#implementing-http-connection-server-protocol

### More samples

You can find more samples within the project integration tests. Take a look at the `test/FirebaseNet.Tests/Interation` folder.

### Contributing

You know how to do it! Fork it, branch it, change it, commit it, and pull-request it. We are passionate about improving this project, and glad to accept help to make it better.