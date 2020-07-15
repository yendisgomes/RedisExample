using ServiceStack.Redis;
using System;

namespace RedisExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string host = "localhost:6379";
            Client client1 = new Client() { Email = "will@example.com", Name = "Will" };
            Client client2 = new Client() { Email = "rick@example.com", Name = "Rick" };

            Client getClient1 = null;
            Client getClient2 = null;
            try
            {
                using (var redisClient = new RedisClient(host))
                {
                    redisClient.Set<Client>(client1.Key.ToString(), client1);
                    redisClient.Set<Client>(client2.Key.ToString(), client2);

                    getClient1 = redisClient.Get<Client>(client1.Key.ToString());
                    getClient2 = redisClient.Get<Client>(client2.Key.ToString());
                }

                Console.WriteLine("==================================================");
                Console.WriteLine("Get values from Redis");
                Console.WriteLine("==================================================");
                Console.WriteLine($"Client1: {getClient1.Key} - {getClient1.Name} - {getClient1.Email}");
                Console.WriteLine($"Client2: {getClient2.Key} - {getClient2.Name} - {getClient2.Email}");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.ReadKey();
            }

        }
    }
}
