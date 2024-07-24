## Getting Started

### Prerequisites
* JetBrains Rider (https://www.jetbrains.com/rider/)
* .NET Core 7 SDK (https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* Postman (https://www.postman.com/downloads/)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/insan-career/DistributedSystemsAndMicroservices.git
2. Go inside folder `DistributedSystemsAndMicroservices`
3. Double click on `DistributedSystemsAndMicroservices.sln`
4. Wait for the Jetbrains Rider IDE to launch
5. On top menu bar, click on `Build -> Build Solution` 
6. On `Build Output` panel below, make sure it is showing `Build completed in [00:00:xx.xxx]`

### Run
1. On top menu bar, click on `Run -> Run DistributedSystemsAndMicroservices:https` 
2. The swagger UI will appear and list each of the users and orders API detail
   For example: https://localhost:7246/swagger/index.html
3. Test each of the users and orders API using swagger UI

### Test

#### Prerequisites
Please note if testing using postman, the setup and run need to be completed succesfully first

1. Open `postman`
2. On top menu bar, click on `File -> Import`
3. Go to folder `Postman`
4. Drop the file `Koobits_DistributedSystemsAndMicroservices.postman_collection.json` 
inside the import file drop box
5. Wait the postman to load all the requests and test cases
6. Wait for it to finish loading
7. Find the `...` beside the `Koobits_DistributedSystemsAndMicroservices` name
8. After finished loading, click on `... -> Run collection`
9. Click on `Run Koobits_DistributedSystemsAndMicroservices`

### Troubleshooting
For troubleshooting, please feel free to contact the author Jimmy (insan.career@gmail.com)  
for assistance. Thank you.
