using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetCasbin.Persist
{
    public interface IAdapter
    {
        void LoadPolicy(Model.Model model);

        Task LoadPolicyAsync(Model.Model model);

        Task LoadPolicyAsync(Model.Model model, CancellationToken cancellationToken);

        void SavePolicy(Model.Model model);

        Task SavePolicyAsync(Model.Model model, CancellationToken cancellationToken);

        void AddPolicy(string sec, string pType, IList<string> rule);

        Task AddPolicyAsync(string sec, string pType, IList<string> rule);

        Task AddPolicyAsync(string sec, string pType, IList<string> rule, CancellationToken cancellationToken);

        void RemovePolicy(string sec, string pType, IList<string> rule);

        Task RemovePolicyAsync(string sec, string pType, IList<string> rule);

        Task RemovePolicyAsync(string sec, string pType, IList<string> rule, CancellationToken cancellationToken);

        void RemoveFilteredPolicy(string sec, string pType, int fieldIndex, params string[] fieldValues);

        Task RemoveFilteredPolicyAsync(string sec, string pType, int fieldIndex, params string[] fieldValues);

        Task RemoveFilteredPolicyAsync(string sec, string pType, int fieldIndex, CancellationToken cancellationToken, params string[] fieldValues);
    }
}
