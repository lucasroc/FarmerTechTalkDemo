open Farmer
open Farmer.Builders
open System
open MyModules.MultipleResource

// Create ARM resources here e.g. webApp { } or storageAccount { } etc.
// See https://compositionalit.github.io/farmer/api-overview/resources/ for more details.

// Add resources to the ARM deployment using the add_resource keyword.
// See https://compositionalit.github.io/farmer/api-overview/resources/arm/ for more details.

//Cria WebApp
let myWebApp = webApp {
    name "TechTalkFarmerWebSite"
    setting "storageKey" myStorage.Key
}

let deployment = arm {
    location Location.BrazilSouth
    add_resource myStorage
    add_resource myWebApp    
}

printf "Generating ARM template..."
deployment |> Writer.quickWrite "MyFirstFarmerARMTemplate"
printfn "all done! Template written to MyFirstFarmerARMTemplate.json"

// Alternatively, deploy your resource group directly to Azure here.
deployment
|> Deploy.execute "farmer-resource-group" Deploy.NoParameters
|> printfn "%A"

// Personaliza tratamento de erros
// match response with
// | Ok outputs -> printfn "Success! Outputs: %A" outputs
// | Error error -> printfn "Failed! %s" error