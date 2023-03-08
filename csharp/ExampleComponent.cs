using System.Collections.Generic;
using Pulumi;
using Random = Pulumi.Random;

namespace Components
{
    public class ExampleComponentArgs : global::Pulumi.ResourceArgs
    {
        [Input("input")]
        public Input<string> Input { get; set; } =  "hello"
;
    }

    public class ExampleComponent : global::Pulumi.ComponentResource
    {
        [Output("result")]
        public Output<string> Result { get; private set; } = null!;
        [Output("createdResource")]
        public Output<Random.RandomPassword> CreatedResource { get; private set; } = null!;
        public ExampleComponent(string name, ExampleComponentArgs args, ComponentResourceOptions? opts = null)
            : base("components:index:ExampleComponent", name, args, opts)
        {
            var password = new Random.RandomPassword($"{name}-password", new()
            {
                Length = 16,
                Special = true,
                OverrideSpecial = args.Input,
            }, new CustomResourceOptions
            {
                Parent = this,
            });

            this.Result = password.Result;
            this.CreatedResource = Output.Create(password);

            this.RegisterOutputs(new Dictionary<string, object?>
            {
                ["result"] = password.Result,
                ["createdResource"] = password,
            });
        }
    }
}
