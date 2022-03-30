

using BackEnd.Repository;
using Contract.Model;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
     IEnumerable<Client> GetClients()
    {
        foreach (var pessoa in  ClientRepository.GetClients())
        {
            yield return pessoa;
            Task.Delay(300).Wait();
        }
    }

    return GetClients();
});

app.MapGet("/stream", () =>
{
    async IAsyncEnumerable<Client> GetClients()
    {
        foreach (var pessoa in ClientRepository.GetClients())
        {
            yield return pessoa;
            await Task.Delay(300);
        }
    }

    return GetClients();
});

app.Run();
