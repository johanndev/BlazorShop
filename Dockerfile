# Stage 1: Compile and publish the source code
FROM microsoft/dotnet:2.1.300-sdk AS builder
WORKDIR /app

COPY *.sln ./
COPY BlazorShop.Client ./BlazorShop.Client
COPY BlazorShop.Server ./BlazorShop.Server
COPY BlazorShop.Shared ./BlazorShop.Shared
COPY global.json global.json
COPY NuGet.Config NuGet.Config

## restore onto a separate layer. That way, we have a single 
RUN dotnet restore --configfile NuGet.Config

RUN dotnet publish --configuration Release --no-restore --output /app/out /p:PublishWithAspNetCoreTargetManifest="false"

# Stage 2: Copies the published code out to published image
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS http://+:5000

COPY --from=builder /app/out .

ENTRYPOINT ["dotnet", "BlazorShop.Server.dll"]
