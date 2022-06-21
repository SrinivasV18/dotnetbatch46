using System;

namespace LoggerLib
{
    public static class Logger
    {
        public static string Success(string msg)
        {
            return "Sucess -" + msg;
        }
        public static string Warn(string msg)
        {
            return "Warn -" + msg;
        }
    }
}
