Set-ExecutionPolicy -Scope Process -ExecutionPolicy Bypass

[Console]::OutputEncoding = [System.Text.Encoding]::UTF8
[Console]::InputEncoding = [System.Text.Encoding]::UTF8

$BaseURL = "http://localhost:1337/chat"

<# .SYNOPSIS
   Sends a message to the chat server.

   .DESCRIPTION
   The Send-Message function sends a message to the chat server using a POST request.

   .PARAMETER Username
   The username of the sender.

   .PARAMETER Text
   The text content of the message.

   .EXAMPLE
   Send-Message -Username "Anonymous" -Text "Hello, world!"
 #>
function Send-Message {
    param (
        [Parameter(Mandatory=$true)][string]$Username,
        [Parameter(Mandatory=$true)][string]$Text
    )

    $body = @{
        username = $Username
        text = $Text
    } | ConvertTo-Json

    $response = Invoke-RestMethod -Uri "$BaseURL/send-message/" -Method Post -Body $body -ContentType "application/json"
    if ($response.message -eq "Message received") {
        Write-Host "Message sent successfully."
    }
    else {
        Write-Host "Error sending message."
    }
}

<# .SYNOPSIS
   Retrieves and displays message history from the chat server.

   .DESCRIPTION
   The Get-Messages function retrieves the chat history using a GET request and displays it.

   .EXAMPLE
   Get-Messages
 #>
function Get-Messages {
    $response = Invoke-RestMethod -Uri "$BaseURL/get-messages/" -Method Get
    $response | ForEach-Object {
        Write-Host "$($_.username): $($_.text)"
    }
}

<# .SYNOPSIS
   Runs the chat client application.

   .DESCRIPTION
   The Run-ChatClient function provides a simple text-based interface for the user to interact with the chat server.
   It allows sending messages and viewing message history.

   .EXAMPLE
   Run-ChatClient
 #>
function Run-ChatClient {
    Write-Host "Welcome to the Chat Client!"
    $username = Read-Host "Enter your username"
    Clear-Host
    while ($true) {
        Write-Host "You write as $username`n"
        Write-Host "1. Send a message"
        Write-Host "2. Get message history"
        Write-Host "3. Exit `n"
        $choice = Read-Host "Enter your choice (1, 2, 3)"
        Clear-Host

        switch ($choice) {
            "1" {
                $message = Read-Host "Enter your message"
                Send-Message -Username $username -Text $message
            }
            "2" {
                Get-Messages
            }
            "3" {
                Write-Host "Exiting chat client."
                break
            }
            default {
                Write-Host "Invalid choice. Please enter 1, 2, or 3."
            }
        }
    }
    exit
}

Run-ChatClient
