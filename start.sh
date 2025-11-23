#!/usr/bin/env bash
set -euo pipefail

export ASPNETCORE_ENVIRONMENT=Production
export ASPNETCORE_URLS="http://0.0.0.0:${PORT:-5000}"

dotnet restore
dotnet publish Laboratorio14/Laboratorio14.csproj -c Release -o out
exec dotnet out/Laboratorio14.dll