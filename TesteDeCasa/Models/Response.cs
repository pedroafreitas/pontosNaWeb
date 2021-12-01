using System;

namespace TesteDeCasa.Models
{
    public class Response
    {
        public string  RequestId => $"{Guid.NewGuid().ToString()}";

        public string ResponseCode {get; init; }

        public string ResponseMessage {get; init; }

        public object Data {get; init; }

    }

}




