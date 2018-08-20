#!/bin/bash
cd ..
ASPNETCORE_ENVIRONMENT=Production dotnet publish -c Release
cp Dockerfile ./bin/release/netcoreapp2.0/publish
docker build -t raccord-api-poc ./bin/release/netcoreapp2.0/publish
docker tag raccord-api-poc registry.heroku.com/raccord-api-poc/web
docker push registry.heroku.com/raccord-api-poc/web
heroku container:release web -a raccord-api-poc
