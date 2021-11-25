namespace Logger.Abstractions
{
    public interface IAction
    {
        bool InfoLog();
        bool WarningLog();
        bool ErrorLog();
    }
}
