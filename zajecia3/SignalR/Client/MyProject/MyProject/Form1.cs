using Microsoft.AspNetCore.SignalR.Client;

namespace MyProject
{
    public partial class Form1 : Form
    {
        HubConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnConnect_Click(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7065/chatHub").Build();

            try
            {
                await connection.StartAsync();
                lblConnection.Text = "connection is established";


            }
            catch (Exception ex)
            {
                lblConnection.Text = ex.Message;
            }

            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                this.Invoke(new Action(() =>
                {
                    var msg = $"{user}: {message}";
                    lstMessage.Items.Add(msg);

                }));

            });
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await connection.InvokeAsync("SendMessage",txtUser.Text,txtMessage.Text);

        }
    }
}
