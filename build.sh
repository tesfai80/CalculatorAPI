#!/usr/bin/env bash
#
# Generated by: https://github.com/swagger-api/swagger-codegen.git
#

dotnet restore src/CalculatorAPI/ && \
    dotnet build src/CalculatorAPI/ && \
    echo "Now, run the following to start the project: dotnet run -p src/CalculatorAPI/CalculatorAPI.csproj --launch-profile web"
