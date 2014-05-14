namespace DesignPrinciples.Sample.Demonstration.Boundaries
{
    public interface IEnvironment
    {
        string GetProgramsFolder();

        string GetDocumentsFolderOfCurrentUser();
    }
}