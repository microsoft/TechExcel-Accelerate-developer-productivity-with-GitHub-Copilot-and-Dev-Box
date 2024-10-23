@description('Environment of the web app')
param environment string = 'dev'

@description('Location of services')
param location string = resourceGroup().location

var webAppName = '${uniqueString(resourceGroup().id)}-${environment}'
var appServicePlanName = '${uniqueString(resourceGroup().id)}-mpnp-asp'
var logAnalyticsName = '${uniqueString(resourceGroup().id)}-mpnp-la'
var appInsightsName = '${uniqueString(resourceGroup().id)}-mpnp-ai'
var sku = 'S1'
var registryName = '${uniqueString(resourceGroup().id)}mpnpreg'
var registrySku = 'Standard'
var imageName = 'techexcel/dotnetcoreapp'
var startupCommand = ''

// App Service Plan, a Web App, Application Insights, and Azure Container Registry in your resource group.

// Generate bicep code to create an Azure Application Insights
resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: appInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
    WorkspaceResourceId: logAnalytics.id
  }
}

// Generate bicep code to create an Azure Log Analytics Workspace
resource logAnalytics 'Microsoft.OperationalInsights/workspaces@2023-09-01' = {
  name: logAnalyticsName
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
  }
}

// Generate bicep code to create an Azure Container Registry    
resource acr 'Microsoft.ContainerRegistry/registries@2020-11-01-preview' = {
  name: registryName
  location: location
  sku: {
    name: registrySku
  }
}


// Generate bicep code to create an Azure App Service Plan 
resource appServicePlan 'Microsoft.Web/serverfarms@2022-09-01' = {
  name: appServicePlanName
  location: location
  kind: 'linux'
  properties: {
    reserved: true
  }
  sku: {
    name: sku
  }
}

// Generate bicep code to create an Azure Web App using docker image name imageName and startup command of startupCommand

resource webApp 'Microsoft.Web/sites@2022-09-01' = {
    name: webAppName
    location: location
    properties: {
      serverFarmId: appServicePlan.id
      siteConfig: {
        linuxFxVersion: 'DOCKER|${imageName}'
        appCommandLine: startupCommand
        appSettings: [
          { 
            name: 'WEBSITES_PORT'
            value: '8080'
          }
          {
            name: 'WEBSITES_ENABLE_APP_SERVICE_STORAGE'
            value: 'false'
          }
          {
            name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
            value: appInsights.properties.InstrumentationKey
          }
        ]
      }
    }
  }
