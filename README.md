# MMT .NET Core Technical Test

## Assignment
Our client requires an application that can be used across multiple channels to promote their range of products. For their first release, there will be no eCommerce functionality, although recommended selling prices will be displayed. All prices are in GBP.

## What to do
- Before starting the solution, please configure the connection string ```"MMTShop"``` found on the API project/appsettings.json 
- Example: ```"MMTShop": "Server=FOYS-PC;Database=MMTShop;Integrated Security=SSPI;MultipleActiveResultSets=true"```

## Prerequisites
- NET Core 3.1 SDK
- Visual Studio 2019

## Deliverables
The API has three endpoints which can be reached at ```https://localhost:44313/Products```
- A ```GET``` request to retrieve a list of featured products - `GetFeaturedProducts`
- A ```GET``` request to retrieve a list of available categories - `GetAvailableCategories`
- A ```GET``` request to retrieve a list of products based on the category specified - `GetProductsByCategory/{categoryName}`

## What to Improve/Future features
- Authentication
- Logging i.e. Log4Net
- Documentation i.e. Swagger/ReDoc
- Unit/Integration testing
- Throttling
