using System.Diagnostics;
using EMS_Server;

public class Program
{
    public static ServerManager serverManager = new ServerManager();

    public static async Task Main(string[] args)
    {
        AppDomain.CurrentDomain.ProcessExit += serverManager.AppExit;
        await serverManager.Init();
    }
}