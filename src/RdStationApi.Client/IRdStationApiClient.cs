using System.Threading.Tasks;

namespace RdStationApi.Client
{
    public interface IRdStationApiClient
    {
        Task<bool> SendLead(ILead lead);
        bool SendLeadSync(ILead lead);
        bool ChangeLeadStatusSync(LeadStatusRoot leadStatusRoot);
        Task<bool> ChangeLeadStatus(LeadStatusRoot leadStatusRoot);

    }
}