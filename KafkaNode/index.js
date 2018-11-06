const express = require('express');
const path = require('path');
const app = express();
const port = process.env.PORT || 3000;

const kafka = require('kafka-node');
const Consumer = kafka.Consumer;
const client = new kafka.KafkaClient(
    {kafkaHost: '172.23.88.9:9093,172.23.88.9:9094,172.23.88.9:9095'});
const consumer = new Consumer(
    client,
    [
        { topic: 'my_topic', partition: 0},
        { topic: 'my_topic', partition: 1},
        { topic: 'my_topic', partition: 2}
    ],
    {
        autoCommit: false
    }
);


app.use(express.static(path.join(__dirname, 'public')));

app.listen(port, () => {
    console.log('Server running on port: ' + port);
});

consumer.on('message', (message) => {
    console.log(message);
})
