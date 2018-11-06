using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KafkaNetProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            string topic = "my_topic";
            //Uri uri = new Uri("http://172.23.88.9:9092");
            Uri[] brokers = new Uri[] { new Uri("http://172.23.88.9:9093"), new Uri("http://172.23.88.9:9094"), new Uri("http://172.23.88.9:9095") };

            /* add this to hosts file 
             * 172.23.88.9	kafka
             * 172.23.88.9 bb -virtual-machine
             */
            //var options = new KafkaOptions(uri);
            var options = new KafkaOptions(brokers);
            var router = new BrokerRouter(options);
            var client = new Producer(router);
            Console.WriteLine($"=== Apache Kafka ===");
            string message = "Test msg";
            if (args != null && args.Length > 0)
            {
                message = args[0];
            }
            long i = 0;
            for (;;)
            {
                Thread.Sleep(1000);
                Message msg = new Message($"Message: {i}. {message}");
                client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
                Console.WriteLine($"Message: {i}.   {message}");
                i++;
            }
        }
    }
}
