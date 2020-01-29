docker build -t samonlinebackimg-img .

docker tag samonlinebackimg-img registry.heroku.com/samonlineback/web

docker push registry.heroku.com/samonlineback/web

heroku container:release web -a samonlineback