# Agent11

This repository contains the Agent11 application, an ASP.NET MVC project for managing user authentication and sessions.

## Deployment Ready

This project is now deployment ready with all necessary configurations, documentation, and deployment scripts.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- .NET 6.0 SDK
- Visual Studio 2022 or VS Code
- SQL Server or SQL Server Express

### Installing

1. Clone the repository
2. Open the solution in Visual Studio or VS Code
3. Restore NuGet packages
4. Build the solution

### Running the Application

1. Run the application using `dotnet run` or through Visual Studio
2. Navigate to `https://localhost:5001` (or `http://localhost:5000` for HTTP)

## Deployment Instructions

### Local Deployment

To deploy locally:

1. Build the project: `dotnet build`
2. Publish the project: `dotnet publish -c Release -o ./publish`
3. Run the published application: `dotnet ./publish/Agent11.dll`

### Production Deployment

For production deployment:

1. Configure environment variables for connection strings and secrets
2. Set up reverse proxy (nginx/Apache) if needed
3. Configure HTTPS certificates
4. Set up logging and monitoring

### Environment Configuration

Create `appsettings.Production.json` for production settings:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=Agent11DB;Trusted_Connection=true;TrustServerCertificate=true;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

## Build Process

The project uses the standard .NET build process:

1. `dotnet restore` - Restore packages
2. `dotnet build` - Build the solution
3. `dotnet test` - Run tests
4. `dotnet publish` - Publish for deployment

## Testing

Run unit tests with:
```
dotnet test
```

## Deployment Script

A deployment script is included to automate the deployment process:

```bash
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
```

Make the script executable:
```bash
chmod +x deploy.sh
```

## Monitoring and Error Tracking

The application includes:
- Built-in logging
- Exception handling
- Performance monitoring capabilities

## Deployment Checklist

- [ ] All dependencies are installed
- [ ] Database connection strings are configured
- [ ] SSL certificates are set up (if applicable)
- [ ] Environment variables are configured
- [ ] Application is tested in staging environment
- [ ] Backup procedures are in place
- [ ] Monitoring and alerting systems are configured

## Troubleshooting Guide

### Common Issues

1. **Connection String Errors**
   - Verify database connection string in appsettings.json
   - Ensure database server is accessible

2. **Port Conflicts**
   - Change ports in launchSettings.json if needed
   - Use different port for development

3. **Missing Dependencies**
   - Run `dotnet restore`
   - Ensure .NET 6.0 SDK is installed

4. **SSL Certificate Issues**
   - Configure HTTPS properly
   - Use trusted certificates in production

## Contributing

Please read CONTRIBUTING.md for details on our code of conduct, and the process for submitting pull requests.

## Versioning

We use SemVer for versioning. For the versions available, see the [tags on this repository](https://github.com/your/project/tags).

## Authors

- **John Smith** - *CEO & Founder* - [GitHub Profile](https://github.com/johnsmith)
- **Sarah Johnson** - *CTO* - [GitHub Profile](https://github.com/sarahjohnson)
- **Michael Chen** - *Lead Developer* - [GitHub Profile](https://github.com/michaelchen)

## License

This project is licensed under the MIT License - see the LICENSE file for details.

## Acknowledgments

- Thanks to the ASP.NET team for providing excellent tools
- Inspired by modern web application development practices