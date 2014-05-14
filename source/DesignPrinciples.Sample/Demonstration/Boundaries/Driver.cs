namespace DesignPrinciples.Sample.Demonstration.Boundaries
{
    public class Driver
    {
        private readonly IEnvironment environment;

        public Driver(IEnvironment environment)
        {
            this.environment = environment;
        }

        public void Save()
        {
            string documentsFolder = this.environment.GetDocumentsFolderOfCurrentUser();

            // ...
        }
    }
}