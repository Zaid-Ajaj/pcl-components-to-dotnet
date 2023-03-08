using System.Collections.Generic;
using Pulumi;
using Random = Pulumi.Random;

namespace Components
{
    public class PlainComponent : global::Pulumi.ComponentResource
    {
        public PlainComponent(string name, ComponentResourceOptions? opts = null)
            : base("components:index:PlainComponent", name, ResourceArgs.Empty, opts)
        {
            var password = new Random.RandomPassword($"{name}-password", new()
            {
                Length = 16,
                Special = true,
            }, new CustomResourceOptions
            {
                Parent = this,
            });

            this.RegisterOutputs();
        }
    }
}
