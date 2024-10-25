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

// TODO: complete this script It should include configuration settings for an App Service Plan, a Web App, Application Insights, and Azure Container Registry in your resource group.
resource appServicePlan 'Microsoft.Web/serverfarms@2020-06-01' = {
  name: appServicePlanName
  location: location
  properties: {
    name: appServicePlanName
    reserved: true
    sku: {
      name: sku
      tier: 'Standard'
      size: 'S1'
    }
  }
}

resource webApp 'Microsoft.Web/sites@2020-06-01' = {
  name: webAppName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      appSettings: [
        {
          name: 'APPINSIGHTS_INSTRUMENTATIONKEY'
          value: appInsightsName
        }
        {
          name: 'WEBSITES_ENABLE_APP_SERVICE_STORAGE'
          value: 'false'
        }
      ]
    }
  }
}

resource appInsights 'microsoft.insights/components@2020-02-02-preview' = {
  name: appInsightsName
  location: location
  properties: {
    ApplicationId: appInsightsName
    Application_Type: 'web'
    Flow_Type: 'Redfield'
  }
}

resource logAnalytics 'microsoft.operationalinsights/workspaces@2020-03-01-preview' = {
  name: logAnalyticsName
  location: location
  properties: {
    sku: {
      name: 'PerGB2018'
    }
  }
}

resource registry 'Microsoft.ContainerRegistry/registries@2019-05-01' = {
  name: registryName
  location: location
  properties: {
    adminUserEnabled: false
    sku: {
      name: registrySku
    }
  }
}
