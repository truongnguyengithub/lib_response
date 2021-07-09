using System;
using System.Collections.Generic;

namespace OMC.Libs
{
    public interface IRequestContext
    {
        string AccessToken { get; }

        IServiceProvider Provider { get; }

        bool IsError { get; }

        IReadOnlyDictionary<dynamic, string> Errors { get; }

        void AddError(string code, string msg);

        void AddError(int code, string msg);

        void AddError(ErrorCodeEnums code, string msg);
    }
}
