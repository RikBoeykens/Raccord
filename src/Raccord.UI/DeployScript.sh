#!/bin/bash
dotnet publish -c Release
docker build -t raccord-ui-poc ./bin/release/netcoreapp1.0/publish
docker tag raccord-ui-poc registry.heroku.com/raccord-ui-poc/web
docker push registry.heroku.com/raccord-ui-poc/web