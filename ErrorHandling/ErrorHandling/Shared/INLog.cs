namespace ErrorHandling.Shared
{
    public interface INLog
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
    }
}
