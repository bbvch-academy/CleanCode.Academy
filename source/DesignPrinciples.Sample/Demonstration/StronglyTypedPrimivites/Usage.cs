namespace DesignPrinciples.Sample.Demonstration.StronglyTypedPrimivites
{
    public class Usage
    {
        private readonly UnsafeGenerator generator;

        private readonly UnsafeOtherDependency otherDependency;

        public Usage(UnsafeGenerator generator, UnsafeOtherDependency otherDependency)
        {
            this.generator = generator;
            this.otherDependency = otherDependency;
        }

        public void Use()
        {
            string id = this.generator.GenerateId();

            this.otherDependency.Use(id);
        } 
    }
}