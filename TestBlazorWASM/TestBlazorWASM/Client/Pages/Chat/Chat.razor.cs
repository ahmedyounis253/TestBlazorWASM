
namespace TestBlazorWASM.Client.Pages.Chat
{
    public partial  class Chat:IAsyncDisposable
    {

        private HubConnection? hubConnection;
        private Guid myId = Guid.NewGuid();
        [Inject]public  NavigationManager _navigationManager { get; set; }

        private NotificationMessage message { get; set; }
        private List<NotificationMessage> messages { get; set; }
        protected override async  Task OnInitializedAsync()
        {
            messages = new List<NotificationMessage>();
            message = new NotificationMessage { Sender = myId };

            hubConnection = new HubConnectionBuilder().WithUrl(_navigationManager.ToAbsoluteUri("/Chat")).Build();
            hubConnection.On<NotificationMessage>("BroadCast", (foundMessage) =>
            {
                messages.Add(foundMessage);
                StateHasChanged();

            });
            await hubConnection.StartAsync();

        }



        private async Task SendMessage()
        {

            if (hubConnection is not  null)
            {
                message.createdOn=DateTime.Now;
                await hubConnection.SendAsync("BroadCast", message);
                message.Message = "";

            }



        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }

        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;
    }
}
