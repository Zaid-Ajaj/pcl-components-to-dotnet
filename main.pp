component exampleComponent "./exampleComponent" {
    input = "doggo"
}

component another "./anotherComponent" {}

component plain "./plainComponent" {}

output result {
    value = exampleComponent.result
}

output password {
    value = exampleComponent.createdResource
}

output passwordResult {
    value = exampleComponent.createdResource.result
}