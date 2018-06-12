using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPost.Classes.Helpers
{
    public interface ILogger
    {
        void LogException(Exception exception);

        void LogError(string message);

        void LogInfo(string message);
    }
}
