using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OMC.Libs
{
    public class RequestContext : IRequestContext
    {
        public RequestContext()
        {
            this.errors = new Dictionary<dynamic, string>();
        }

        public HttpContext Context { get; set; }

        public Dictionary<dynamic, string> errors { get; }

        public IReadOnlyDictionary<dynamic, string> Errors => (IReadOnlyDictionary<dynamic, string>)this.errors;

        public bool IsError => this.errors.Any<KeyValuePair<dynamic, string>>();

        public void AddError(string code, string msg) => this.errors.Add(code, msg);

        public void AddError(int code, string msg) => this.errors.Add(code, msg);

        public void AddError(ErrorCodeEnums code, string msg) => this.errors.Add(code, msg);

        public string AccessToken
        {
            get
            {
                StringValues? header = this.Context?.Request?.Headers["Authorization"];
                return (header.HasValue ? (string)header.GetValueOrDefault() : (string)null)?.Substring("Basic ".Length);
            }
        }

        public IServiceProvider Provider => this.Context?.RequestServices;
    }
}
