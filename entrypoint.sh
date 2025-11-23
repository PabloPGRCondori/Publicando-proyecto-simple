#!/usr/bin/env bash
set -euo pipefail
export ASPNETCORE_URLS="http://0.0.0.0:${PORT:-8080}"
exec dotnet /app/Laboratorio14.dll