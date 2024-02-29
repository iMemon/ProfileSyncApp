// See https://aka.ms/new-console-template for more information
using Dotmim.Sync.Sqlite;
using Dotmim.Sync.PostgreSql;
using Dotmim.Sync;

class Program
{
    static void Main(string[] args)
    {
        // Sql Server provider, the "server" or "hub".
        NpgsqlSyncProvider serverProvider = new NpgsqlSyncProvider(
            @"User ID=postgres;Password=1234;Host=localhost;Port=5432;Database=adventureworks;");

        // Sqlite Client provider acting as the "client"
        SqliteSyncProvider clientProvider = new SqliteSyncProvider("advworks.db");

        // Tables involved in the sync process:
        var setup = new SyncSetup("Address", 
                                  "Customer", "CustomerAddress");

        // Sync agent
        SyncAgent agent = new SyncAgent(clientProvider, serverProvider);

        do
        {
            // var result = await agent.SynchronizeAsync(setup);
            var result = Task.Run(()=> agent.SynchronizeAsync(setup)).Result;
            Console.WriteLine(result);

        } while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}
