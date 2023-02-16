#!/bin/bash

dotnet ef migrations add "$1" --context TphToTpcMigrationContext --output-dir Migrations -s ../ronimizy.SpbDotNet.TPC.Web