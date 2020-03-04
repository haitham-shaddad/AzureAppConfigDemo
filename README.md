#AzureAppConfigDemo#
A demo presented at Azure Sydney UG for Azure App Configuration Service

#Run the application To run the sample, you have to:

1. Create a new Azure App Configuration instance
2. Update the key AzureAppConfig:ConnectionString in appsettings.json with the connection string from the new app config instance. This will allow you to run the sample anywhere
3. If you want to deploy the sample to azure app service and use managed identity you have to do the following
    1. From azure portal, open your azure app service
    2. Select Identity and turn it on
    3. Go to the app config instance -> Access Control (IAM)
    4. Click Add Role assignment
    5. Choose "App Configuration Data Reader" from the Role drop down
    6. Choose "App Service" in the Assign access to drop down
    7. Choose your app service in the "Select" list
    8. Click Save