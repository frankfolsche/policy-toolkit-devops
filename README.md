# policy-toolkit-devops
Example how to use the Azure [Api Management Policy](https://github.com/Azure/azure-api-management-policy-toolkit) toolkit in a Azure DevOps pipeline

## Compile policies
`dotnet tool restore`

`dotnet azure-apim-policy-compiler --s PolicyDevOps.Apis.Policies`

## Pipeline
[![Build Status](https://dev.azure.com/frankfolsche/FrankFolsche/_apis/build/status%2Ffrankfolsche.policy-toolkit-devops?branchName=main)](https://dev.azure.com/frankfolsche/FrankFolsche/_build/latest?definitionId=2&branchName=main)