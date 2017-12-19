#!/bin/bash
dotnet publish -c Release
docker build -t raccord-api-poc ./bin/release/netcoreapp1.0/publish
docker tag raccord-api-poc registry.heroku.com/raccord-api-poc/web
docker push registry.heroku.com/raccord-api-poc/web