namespace DesignPrinciples.Sample.Demonstration.Boundaries
{
    public class Environment : IEnvironment
    {
        public string GetProgramsFolder()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.ProgramFiles);
        }

        public string GetDocumentsFolderOfCurrentUser()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        }
    }
}