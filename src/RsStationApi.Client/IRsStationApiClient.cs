using System.Threading.Tasks;

namespace RsStationApi.Client
{
    public interface IRsStationApiClient
    {
        Task<bool> SendLead(ILead lead);
    }
}