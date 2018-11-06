# KafkaNetProducer

configuration kafka on Ubuntu server

bin/zookeeper-server-start.sh config/zookeeper.properties

bin/kafka-server-start.sh config/server-1.properties 
bin/kafka-server-start.sh config/server-2.properties 
bin/kafka-server-start.sh config/server-3.properties 

bin/kafka-topics.sh --create --topic my_topic --zookeeper localhost:2181 --replication-factor 3 --partitions 3 

bin/kafka-topics.sh --describe --zookeeper localhost:2181 –topic my_topic

bin/kafka-console-consumer.sh --bootstrap-server localhost:9093,localhost:9094,localhost:9095 --topic my_topic --from-beginning
