namespace Raccord.API.ViewModels.Core
{
    //  Used to return info by the api
    public class JsonResponse
    {
        // Indicates success
        public bool ok { get; set; }

        // contains details of message
        public string message { get; set; }

        // container for any data required in response
        public object data { get; set; }
    }
}
