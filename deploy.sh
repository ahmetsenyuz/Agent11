#!/bin/bash
# deploy.sh

echo "Starting deployment..."

# Restore packages
dotnet restore

# Build for release
dotnet build -c Release

# Run tests
dotnet test

# Publish
dotnet publish -c Release -o ./publish

echo "Deployment completed successfully!"