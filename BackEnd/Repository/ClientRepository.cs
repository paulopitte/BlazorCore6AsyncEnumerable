using Bogus;
using Contract.Model;

namespace BackEnd.Repository
{
    internal static class ClientRepository
    {

        public static ICollection<Client> GetClients()
        {
            List<Client> clients = new();
            for (int init = 0; init < 30; init++)
            {

                var fake = new Faker<Bogus.Person>()
                                .CustomInstantiator(p => new Bogus.Person())
                                .RuleFor(u => u.FullName, (f, u) => f.Name.FullName())
                                .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName).ToLower())
                                .Generate();

                clients.Add(new()
                {
                    Name = fake.FullName,
                    Email = fake.Email,
                    Image = fake.Avatar
                });
            }
            return clients;

        }
    }
}
