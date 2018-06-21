#!/bin/bash
cd ..
npm run build:prod
dotnet publish -c Release
cp Dockerfile ./bin/release/netcoreapp2.0/publish
docker build -t raccord-ui-poc ./bin/release/netcoreapp2.0/publish
docker tag raccord-ui-poc registry.heroku.com/raccord-ui-poc/web
docker push registry.heroku.com/raccord-ui-poc/web
heroku container:release web -a raccord-ui-poc