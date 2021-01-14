using System;
using System.Collections.Generic;
using System.Text;

namespace ApiNetCore.Domain.Responses
{
    public class ResponseStatus
    {
        public string HttpCode { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string DescriptionHttp { get; set; }
    }
}
