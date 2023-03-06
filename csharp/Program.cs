using System.Collections.Generic;
using Pulumi;

return await Deployment.RunAsync(() => 
{
    var exampleComponent = new Components.ExampleComponent("exampleComponent", new()
    {
        Input = "doggo",
    });

    var another = new Components.AnotherComponent("another");

    var plain = new Components.PlainComponent("plain");

    return new Dictionary<string, object?>
    {
        ["result"] = exampleComponent.Result,
        ["password"] = exampleComponent.CreatedResource,
        ["passwordResult"] = exampleComponent.CreatedResource.Apply(createdResource => createdResource.Result),
    };
});

