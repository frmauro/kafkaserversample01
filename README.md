# kafkaserversample01

## remove local repository GIT
rm -rf .git

## commands docker-compose
docker-compose up
docker-compose down

## list of commands KAFKA in docker
docker exec -ti samples_kafka_1 /opt/kafka/bin/kafka-topics.sh --list --zookeeper zookeeper:2181
docker exec -ti samples_kafka_1 /usr/bin/broker-list.sh

## Create a Topic
francisco@francisco-ubuntu20:~/estudos/kafka/samples$ docker exec -ti samples_kafka_1 /opt/kafka/bin/kafka-topics.sh --create --zookeeper zookeeper:2181 --replication-factor 1 --partitions 1 --topic test2


docker ps -a --format 'table {{.ID}}\t{{.Names}}\t{{.Image}}\t{{.Status}}'