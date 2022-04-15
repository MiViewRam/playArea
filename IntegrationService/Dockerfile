FROM mcr.microsoft.com/dotnet/sdk:6.0 AS installer-env
ARG USER
ARG PAT
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS {\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/miviewis/_packaging/MiViewUtils%40Local/nuget/v3/index.json\", \"username\":\"${USER}\", \"password\":\"${PAT}\"}]}
RUN wget -qO- https://raw.githubusercontent.com/Microsoft/artifacts-credprovider/master/helpers/installcredprovider.sh | bash
# Build requires 3.1 SDK
COPY --from=mcr.microsoft.com/dotnet/core/sdk:3.1 /usr/share/dotnet /usr/share/dotnet
WORKDIR /src/dotnet-function-app
COPY . .
RUN mkdir -p /out && \
    dotnet publish IntegrationService.Functions/*.csproj --output /out

# To enable ssh & remote debugging on app service change the base image to the one below
# FROM mcr.microsoft.com/azure-functions/dotnet:4-appservice
FROM mcr.microsoft.com/azure-functions/dotnet:4
ENV AzureWebJobsScriptRoot=/home/site/wwwroot \
    AzureFunctionsJobHost__Logging__Console__IsEnabled=true \
	AzureWebJobsSecretStorageType=files
COPY docker_secrets.json /azure-functions-host/Secrets/host.json
COPY --from=installer-env ["/out", "/home/site/wwwroot"]
