namespace DesignPrinciples.Sample.Demonstration.Boundaries
{
    public class EnvironmentFake : IEnvironment
    {
        public const string DocumentsFolder = @"C:\documents";

        public const string ProgramsFolder = @"C:\program files";

        public string GetProgramsFolder()
        {
            return ProgramsFolder;
        }

        public string GetDocumentsFolderOfCurrentUser()
        {
            return DocumentsFolder;
        }
    }
}