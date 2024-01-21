
let connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("btnSend").disabled = true;

connection.start().then(function () {
    document.getElementById("btnSend").disabled = false;
}).catch(function (err) {
    return console.error(err.toString);
})

document.getElementById("btnSend").addEventListener("click", function () {
    var user = document.getElementById("txtUser").value;
    var message = document.getElementById("txtMessage").value;

    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString);
    })
})

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messageList").appendChild(li);

    li.textContent = `${user} says ${message}`;
}).catch(function (err) {
    return console.error(err.toString);
})