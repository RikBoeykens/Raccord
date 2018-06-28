#!/bin/bash
cd ..
ASPNETCORE_ENVIRONMENT=Production dotnet run --urls "http://localhost:5000"