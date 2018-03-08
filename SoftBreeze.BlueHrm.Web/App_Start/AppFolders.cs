using Abp.Dependency;

namespace SoftBreeze.BlueHrm.Web
{
    public class AppFolders : IAppFolders, ISingletonDependency
    {
        public string TempFileDownloadFolder { get; set; }
    }
}