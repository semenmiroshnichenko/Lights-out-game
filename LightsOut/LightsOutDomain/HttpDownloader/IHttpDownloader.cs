namespace LightsOutDomain
{
    public interface IHttpDownloader
    {
        string GetData(string remoteUri);
    }
}