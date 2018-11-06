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
            Console.WriteLine($"Send some message:\n");
            long i = 0;
            for (;;)
            {
                Thread.Sleep(1000);
                //string userMsg = Console.ReadLine();
                Message msg = new Message($"Message: {i}");
                client.SendMessageAsync(topic, new List<Message> { msg }).Wait();
                Console.WriteLine($"{i}: Message sent do Kafka");
                i++;
            }
        }
    }
}
