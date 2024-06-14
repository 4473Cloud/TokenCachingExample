# TokenCachingExample

This project demonstrates an effective approach to caching Machine-to-Machine (M2M) tokens in a .NET application. It features an API with a singular endpoint designed to retrieve an M2M token and store it using C#'s built-in memory cache. To ensure reliability and minimize the risk of token expiration issues, the cache's absolute expiration is strategically set to two minutes prior to the actual token expiration time. This buffer period acts as a grace period, enhancing the robustness of the token management process.

## Description

TokenCachingExample is crafted to showcase a robust caching mechanism for M2M tokens within a .NET environment. This is achieved by setting the cache expiration to a brief period before the token's actual expiry, thereby ensuring continuous token availability without the risk of sudden expiration during critical operations.

### How to Run

To explore and run the TokenCachingExample project, follow these simple steps:

1. Open the solution in Visual Studio.
2. Build the project to resolve dependencies and prepare the build artifacts.
3. Run the project to initiate the API service.

Upon running the project, a Swagger UI will automatically open in your default web browser.
This process will start the API, making it ready to handle requests for M2M token retrieval.
