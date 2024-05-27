namespace Log.Service.Api.Logger
{
    public interface ILogger
    {
        void Log(string Type, string message);
    }
}