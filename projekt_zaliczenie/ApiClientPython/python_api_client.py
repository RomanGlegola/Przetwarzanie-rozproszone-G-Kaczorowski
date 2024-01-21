import requests
import os

SERVER_URL = "http://localhost:1337/chat"

def send_message(username: str, text: str):
    """
    Send a message to the chat server.

    :arg str username: The username sending the message.
    :arg str text: The message content.
    """
    response = requests.post(f"{SERVER_URL}/send-message/", json={"username": username, "text": text})
    if response.status_code == 200:
        print("Message sent successfully.")
    else:
        print("Error sending message.")

def get_messages():
    """
    Retrieve message history from the chat server.
    """
    response = requests.get(f"{SERVER_URL}/get-messages/")
    if response.status_code == 200:
        messages = response.json()
        for message in messages:
            print(f"{message['username']}: {message['text']}")
    else:
        print("Error retrieving messages.")

def clear_screen():
    """
    Clears the terminal screen.
    """
    # for windows
    if os.name == 'nt':
        _ = os.system('cls')
    # for mac and linux(here, os.name is 'posix')
    else:
        _ = os.system('clear')

def main():
    """
    Main function to run the chat client application.
    """
    print("Welcome to the Chat Client!")
    username = input("Enter your username: ")
    clear_screen()
    while True:
        print(f"You write as {username}")
        print("\nOptions:")
        print("1. Send a message")
        print("2. Get message history")
        print("3. Exit")
        choice = input("Enter your choice (1, 2, 3): ")
        clear_screen()

        if choice == '1':
            text = input("Enter your message: ")
            send_message(username, text)
        elif choice == '2':
            get_messages()
        elif choice == '3':
            print("Exiting chat client.")
            break
        else:
            print("Invalid choice. Please enter 1, 2, or 3.")

if __name__ == "__main__":
    main()
