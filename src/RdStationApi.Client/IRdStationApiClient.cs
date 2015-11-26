using System.Threading.Tasks;

namespace RdStationApi.Client
{
    public interface IRdStationApiClient
    {
        Task<bool> SendLead(ILead lead);
        bool SendLeadSync(ILead lead);
    }
}