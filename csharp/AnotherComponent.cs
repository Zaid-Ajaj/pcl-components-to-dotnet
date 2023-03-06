using System.Collections.Generic;
using Pulumi;
using Random = Pulumi.Random;

namespace Components
{
    public class AnotherComponent : global::Pulumi.ComponentResource
    {
        [Output("value")]
        public Output<string> Value { get; private set; } = null!;
        public AnotherComponent(string name, ComponentResourceOptions? opts = null)
            : base("components:index:AnotherComponent", name, ResourceArgs.Empty, opts)
        {
            var password = new Random.RandomPassword("password", new()
            {
                Length = 16,
                Special = true,
            }, new CustomResourceOptions
            {
                Parent = this,
            });

            this.Value = password.Result;

            this.RegisterOutputs(new Dictionary<string, object?>
            {
                ["value"] = password.Result,
            });
        }
    }
}
