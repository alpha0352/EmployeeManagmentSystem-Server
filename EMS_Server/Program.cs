using EMS_Server;

public class Program
{
    public static ServerManager serverManager = new ServerManager();

    public static async Task Main(string[] args)
    {
        await serverManager.Init();
    }
}