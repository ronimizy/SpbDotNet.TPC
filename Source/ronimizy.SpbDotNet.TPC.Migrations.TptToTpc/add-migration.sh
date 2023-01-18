#!/bin/bash

dotnet ef migrations add "$1" --context TptToTpcMigrationContext --output-dir Migrations -s ../ronimizy.SpbDotNet.TPC.Web