using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BupaWebAPI.Messages
{
    public class MessageResponse
    {
        public MessageResponse()
        {
            Message = string.Empty;
            Errors = new string[] { };
        }

        public string Message { get; set; }

        public string[] Errors { get; set; }
    }
}
