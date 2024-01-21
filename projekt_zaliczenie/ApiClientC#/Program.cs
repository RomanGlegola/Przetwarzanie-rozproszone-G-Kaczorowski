using System.Text;
using Newtonsoft.Json;
using ApiClientCSharp.Models;

namespace ChatClientCSharp
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the Chat Client!");
            Console.Write("Enter your username: ");
            var username = Console.ReadLine();
            ClearScreen();

            while (true)
            {
                Console.WriteLine($"You write as {username}");
                Console.WriteLine("\nOptions:");
                Console.WriteLine("1. Send a message");
                Console.WriteLine("2. Get message history");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice (1, 2, 3): ");
                var choice = Console.ReadLine();
                ClearScreen();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter your message: ");
                        var text = Console.ReadLine();
                        await SendMessage(username, text);
                        break;
                    case "2":
                        await GetMessages();
                        break;
                    case "3":
                        Console.WriteLine("Exiting chat client.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }
            }
        }

        static async Task SendMessage(string username, string text)
        {
            var message = new { Username = username, Text = text };
            var json = JsonConvert.SerializeObject(message);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("http://localhost:1337/chat/send-message", data);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Message sent successfully.");
            }
            else
            {
                Console.WriteLine("Error sending message.");
            }
        }

        static async Task GetMessages()
        {
            var response = await client.GetAsync("http://localhost:1337/chat/get-messages");
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Received Messages:");
                Console.WriteLine(responseString);
        
                try
                {
                    var messages = JsonConvert.DeserializeObject<List<Message>>(responseString);
                    foreach (var message in messages)
                    {
                        Console.WriteLine($"{message.Username}: {message.Text}");
                    }
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("Error in parsing message data.");
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                Console.WriteLine("Error retrieving messages.");
            }
        }

        static void ClearScreen()
        {
            Console.Clear();
        }
    }
}
