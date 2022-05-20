# kafkaserversample01

## remove local repository GIT
rm -rf .git

## commands docker-compose
docker-compose up
docker-compose down

## command to get network name by container name
docker inspect kafka -f "{{json .NetworkSettings.Networks }}"

## docker create containers for zookeeper and kafka
# Download spotify/kafka image using docker
docker pull spotify/kafka

# Create the docker container using the downloaded image
docker run -d -p 2181:2181 -p 9092:9092 --name kafka -e KAFKA_ADVERTISED_LISTENERS=PLAINTEXT://kafka:9092   --env ADVERTISED_PORT=9092 spotify/kafka


## list of commands KAFKA in docker
# Open your terminal and exec inside the kafka container
docker exec -it kafka bash
# Once in the container, goto the below path
cd /opt/kafka_2.11-0.10.1.0/

bin/kafka-topics.sh --list --zookeeper localhost:2181

## Create a Topic
# Open your terminal and exec inside the kafka container
docker exec -it kafka bash
# Once in the container, goto the below path
cd /opt/kafka_2.11-0.10.1.0/
# Here 2.11 is the Scala version and 0.10.1.0 is the Kafka version that is used by the spotify/kafka docker image
# Create a topic
bin/kafka-topics.sh --create --topic updateamount --zookeeper localhost:2181 --partitions 1 --replication-factor 1



docker ps -a --format 'table {{.ID}}\t{{.Names}}\t{{.Image}}\t{{.Status}}'