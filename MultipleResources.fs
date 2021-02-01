namespace MyModules

open Farmer
open Farmer.Builders
open System

module MultipleResource =
    //Cria uma Storage Account
    let myStorage = storageAccount {
        name "tecktalkfarmersa"        
    }

