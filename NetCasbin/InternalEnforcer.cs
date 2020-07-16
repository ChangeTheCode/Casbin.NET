using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NetCasbin
{
    /// <summary>
    /// InternalEnforcer = CoreEnforcer + Internal API.
    /// </summary>
    public class InternalEnforcer : CoreEnforcer
    {
        /// <summary>
        /// Adds a rule to the current policy.
        /// </summary>
        /// <param name="sec"></param>
        /// <param name="ptype"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        protected bool AddPolicy(string sec, string ptype, List<string> rule)
        {
            if (model.HasPolicy(sec, ptype, rule))
            {
                return false;
            }

            if (adapter != null && autoSave)
            {
                bool adapterAdded;
                try
                {
                    adapter.AddPolicy(sec, ptype, rule);
                    adapterAdded = true;
                }
                catch (NotImplementedException)
                {
                    // error intentionally ignored
                    adapterAdded = false;
                }

                if (adapterAdded)
                {
                    watcher?.Update();
                }
            }

            var ruleAdded = model.AddPolicy(sec, ptype, rule);
            return ruleAdded;
        }

        /// <summary>
        /// Adds a rule to the current policy.
        /// </summary>
        /// <param name="sec"></param>
        /// <param name="pType"></param>
        /// <param name="rule"></param>
        /// <param name="cancellationToken">instance of the cancellation token</param>
        /// <returns></returns>
        protected async Task<bool> AddPolicyAsync(string sec, string pType, List<string> rule, CancellationToken cancellationToken)
        {
            if (model.HasPolicy(sec, pType, rule))
            {
                return false;
            }

            if (adapter != null && autoSave)
            {
                bool adapterAdded;
                try
                {
                    await adapter.AddPolicyAsync(sec, pType, rule, cancellationToken);
                    adapterAdded = true;
                }
                catch (NotImplementedException)
                {
                    // error intentionally ignored
                    adapterAdded = false;
                }

                if (adapterAdded)
                {
                    if (!(watcher is null))
                    {
                        await watcher?.UpdateAsync();
                    }
                }
            }

            var ruleAdded = model.AddPolicy(sec, pType, rule);
            return ruleAdded;
        }

        /// <summary>
        /// Removes a rule from the current policy.
        /// </summary>
        /// <param name="sec"></param>
        /// <param name="pType"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        protected bool RemovePolicy(string sec, string pType, List<string> rule)
        {
            if (adapter != null && autoSave)
            {
                bool adapterRemoved;
                try
                {
                    adapter.RemovePolicy(sec, pType, rule);
                    adapterRemoved = true;
                }
                catch (NotImplementedException)
                {
                    // error intentionally ignored
                    adapterRemoved = false;
                }

                if (adapterRemoved)
                {
                    watcher?.Update();
                }
            }

            var ruleRemoved = model.RemovePolicy(sec, pType, rule);
            return ruleRemoved;
        }

        /// <summary>
        /// Removes a rule from the current policy.
        /// </summary>
        /// <param name="sec"></param>
        /// <param name="pType"></param>
        /// <param name="rule"></param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns></returns>
        protected async Task<bool> RemovePolicyAsync(string sec, string pType, List<string> rule, CancellationToken cancellationToken)
        {
            if (adapter != null && autoSave)
            {
                bool adapterRemoved;
                try
                {
                    await adapter.RemovePolicyAsync(sec, pType, rule, cancellationToken);
                    adapterRemoved = true;
                }
                catch (NotImplementedException)
                {
                    // error intentionally ignored
                    adapterRemoved = false;
                }

                if (adapterRemoved)
                {
                    if (!(watcher is null))
                    {
                        await watcher?.UpdateAsync();
                    }
                }
            }

            var ruleRemoved = model.RemovePolicy(sec, pType, rule);
            return ruleRemoved;
        }

        /// <summary>
        /// Removes rules based on field filters from the current policy.
        /// </summary>
        /// <param name="sec"></param>
        /// <param name="ptype"></param>
        /// <param name="fieldIndex"></param>
        /// <param name="fieldValues"></param>
        /// <returns></returns>
        protected bool RemoveFilteredPolicy(string sec, string ptype, int fieldIndex, params string[] fieldValues)
        {
            if (adapter != null && autoSave)
            {
                bool adapterRemoved;
                try
                {
                    adapter.RemoveFilteredPolicy(sec, ptype, fieldIndex, fieldValues);
                    adapterRemoved = true;
                }
                catch (NotImplementedException)
                {
                    // error intentionally ignored
                    adapterRemoved = false;
                }

                if (adapterRemoved)
                {
                    watcher?.Update();
                }
            }

            var ruleRemoved = model.RemoveFilteredPolicy(sec, ptype, fieldIndex, fieldValues);
            return ruleRemoved;
        }

        /// <summary>
        /// Removes rules based on field filters from the current policy.
        /// </summary>
        /// <param name="sec"></param>
        /// <param name="ptype"></param>
        /// <param name="fieldIndex"></param>
        /// <param name="cancellationToken">Instance of the cancellation Token</param>
        /// <param name="fieldValues"></param>
        /// <returns></returns>
        protected async Task<bool> RemoveFilteredPolicyAsync(string sec, string ptype, int fieldIndex, CancellationToken cancellationToken, params string[] fieldValues)
        {
            cancellationToken.ThrowIfCancellationRequested();
            if (adapter != null && autoSave)
            {
                bool adapterRemoved;
                try
                {
                    await adapter.RemoveFilteredPolicyAsync(sec, ptype, fieldIndex, cancellationToken, fieldValues);
                    adapterRemoved = true;
                }
                catch (NotImplementedException)
                {
                    // error intentionally ignored
                    adapterRemoved = false;
                }

                if (adapterRemoved)
                {
                    if (!(watcher is null))
                    {
                        await watcher?.UpdateAsync();
                    }
                }
            }

            var ruleRemoved = model.RemoveFilteredPolicy(sec, ptype, fieldIndex, fieldValues);
            return ruleRemoved;
        }
    }
}
