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

resource appServicePlan 'Microsoft.Web/serverfarms@2021-02-01' = {
  name: appServicePlanName
  location: location
  sku: {
    name: sku
    tier: 'Standard'
  }
  properties: {
    reserved: true
  }
}

resource webApp 'Microsoft.Web/sites@2021-02-01' = {
  name: webAppName
  location: location
  properties: {
    serverFarmId: appServicePlan.id
    siteConfig: {
      linuxFxVersion: 'DOCKER|${imageName}'
      appCommandLine: startupCommand
    }
  }
}

resource appInsights 'Microsoft.Insights/components@2020-02-02' = {
  name: appInsightsName
  location: location
  kind: 'web'
  properties: {
    Application_Type: 'web'
  }
}

resource containerRegistry 'Microsoft.ContainerRegistry/registries@2021-06-01-preview' = {
  name: registryName
  location: location
  sku: {
    name: registrySku
  }
  properties: {
    adminUserEnabled: true
  }
}

//az ad sp create --id dd0d73a2-dd3e-4752-a7eb-8b9c5fefc8bc
// sp "id": "08f2fb0c-e135-49b5-bacc-8f444275b12a"
// az ad app federated-credential create --id dd0d73a2-dd3e-4752-a7eb-8b9c5fefc8bc --parameters credentials.json
//az role assignment create --role contributor --scope /subscriptions/699f3eb4-18f1-491c-ac3a-a7f89f164bd1/resourceGroups/TechExcelTraining-Day2 --subscription 699f3eb4-18f1-491c-ac3a-a7f89f164bd1 --assignee-object-id 08f2fb0c-e135-49b5-bacc-8f444275b12a --assignee-principal-type ServicePrincipal
