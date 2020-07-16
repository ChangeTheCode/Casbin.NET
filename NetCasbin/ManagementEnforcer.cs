using NetCasbin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCasbin
{
    /// <summary>
    /// ManagementEnforcer = InternalEnforcer + Management API.
    /// </summary>
    public class ManagementEnforcer : InternalEnforcer
    {
        /// <summary>
        /// Gets the list of subjects that show up in the current policy.
        /// </summary>
        /// <returns>
        /// All the subjects in "p" policy rules. It actually collects the
        /// 0-index elements of "p" policy rules. So make sure your subject
        /// is the 0-index element, like (sub, obj, act). Duplicates are removed.
        /// </returns>
        public List<string> GetAllSubjects()
        {
            return GetAllNamedSubjects(PermConstants.Section.PolicySection);
        }

        /// <summary>
        /// GetAllNamedSubjects gets the list of subjects that show up in the currentnamed policy.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <returns>
        /// All the subjects in policy rules of the ptype type. It actually
        /// collects the 0-index elements of the policy rules.So make sure
        /// your subject is the 0-index element, like (sub, obj, act).
        /// Duplicates are removed.</returns>
        public List<string> GetAllNamedSubjects(string ptype)
        {
            return model.GetValuesForFieldInPolicy(PermConstants.Section.PolicySection, ptype, 0);
        }

        /// <summary>
        /// Gets the list of objects that show up in the current policy.
        /// </summary>
        /// <returns>
        /// All the objects in "p" policy rules. It actually collects the
        /// 1-index elements of "p" policy rules.So make sure your object
        /// is the 1-index element, like (sub, obj, act).
        /// Duplicates are removed.</returns>
        public List<string> GetAllObjects()
        {
            return GetAllNamedObjects(PermConstants.Section.PolicySection);
        }

        /// <summary>
        /// Gets the list of objects that show up in the current named policy.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <returns>
        /// All the objects in policy rules of the ptype type. It actually
        /// collects the 1-index elements of the policy rules.So make sure
        /// your object is the 1-index element, like (sub, obj, act).
        /// Duplicates are removed.</returns>
        public List<string> GetAllNamedObjects(string ptype)
        {
            return model.GetValuesForFieldInPolicy(PermConstants.DefautPolicyType, ptype, 1);
        }

        /// <summary>
        /// Gets the list of actions that show up in the current policy.
        /// </summary>
        /// <returns>
        /// All the actions in "p" policy rules. It actually collects
        /// the 2-index elements of "p" policy rules.So make sure your action
        /// is the 2-index element, like (sub, obj, act).
        /// Duplicates are removed.</returns>
        public List<string> GetAllActions()
        {
            return GetAllNamedActions(PermConstants.Section.PolicySection);
        }

        /// <summary>
        /// Gets the list of actions that show up in the current named policy.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <returns>
        /// All the actions in policy rules of the ptype type. It actually
        /// collects the 2-index elements of the policy rules.So make sure
        /// your action is the 2-index element, like (sub, obj, act).
        /// Duplicates are removed.</returns>
        public List<string> GetAllNamedActions(string ptype)
        {
            return model.GetValuesForFieldInPolicy(PermConstants.Section.PolicySection, ptype, 2);
        }

        /// <summary>
        /// Gets the list of roles that show up in the current policy.
        /// </summary>
        /// <returns>
        /// All the roles in "g" policy rules. It actually collects
        /// the 1-index elements of "g" policy rules. So make sure your
        /// role is the 1-index element, like (sub, role).
        /// Duplicates are removed.</returns>
        public List<string> GetAllRoles()
        {
            return GetAllNamedRoles(PermConstants.Section.RoleSection);
        }

        /// <summary>
        /// Gets the list of roles that show up in the current named policy.
        /// </summary>
        /// <param name="ptype">The policy type, can be "g", "g2", "g3", ..</param>
        /// <returns>
        /// All the subjects in policy rules of the ptype type. It actually
        /// collects the 0-index elements of the policy rules.So make
        /// Sure your subject is the 0-index element, like (sub, obj, act).
        /// Duplicates are removed.</returns>
        public List<string> GetAllNamedRoles(string ptype)
        {
            return model.GetValuesForFieldInPolicy(PermConstants.Section.RoleSection, ptype, 1);
        }

        /// <summary>
        /// Gets all the authorization rules in the policy.
        /// </summary>
        /// <returns> all the "p" policy rules.</returns>
        public List<List<string>> GetPolicy()
        {
            return GetNamedPolicy(PermConstants.Section.PolicySection);
        }

        /// <summary>
        /// Gets all the authorization rules in the policy, field filters can be specified.
        /// </summary>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to  match this field.</param>
        /// <returns>The filtered "p" policy rules.</returns>
        public List<List<string>> GetFilteredPolicy(int fieldIndex, params string[] fieldValues)
        {
            return GetFilteredNamedPolicy(PermConstants.Section.PolicySection, fieldIndex, fieldValues);
        }

        /// <summary>
        /// Gets all the authorization rules in the named policy.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <returns>The "p" policy rules of the specified ptype.</returns>
        public List<List<string>> GetNamedPolicy(string ptype)
        {
            return model.GetPolicy(PermConstants.Section.PolicySection, ptype);
        }

        /// <summary>
        /// Gets all the authorization rules in the named policy, field filters can be specified.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to  match this field.</param>
        /// <returns>The filtered "p" policy rules of the specified ptype.</returns>
        public List<List<string>> GetFilteredNamedPolicy(string ptype, int fieldIndex, params string[] fieldValues)
        {
            return model.GetFilteredPolicy(PermConstants.Section.PolicySection, ptype, fieldIndex, fieldValues);
        }

        /// <summary>
        /// Gets all the role inheritance rules in the policy.
        /// </summary>
        /// <returns>all the "g" policy rules.</returns>
        public List<List<string>> GetGroupingPolicy()
        {
            return GetNamedGroupingPolicy(PermConstants.DefaultGroupingPolicyType);
        }

        /// <summary>
        /// Gets all the role inheritance rules in the policy, field filters can be specified.
        /// </summary>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>The filtered "g" policy rules.</returns>
        public List<List<string>> GetFilteredGroupingPolicy(int fieldIndex, params string[] fieldValues)
        {
            return GetFilteredNamedGroupingPolicy(PermConstants.DefaultGroupingPolicyType, fieldIndex, fieldValues);
        }

        /// <summary>
        /// Gets all the role inheritance rules in the policy.
        /// </summary>
        /// <param name="ptype">The policy type, can be "g", "g2", "g3", ..</param>
        /// <returns>The "g" policy rules of the specified ptype.</returns>
        public List<List<string>> GetNamedGroupingPolicy(string ptype)
        {
            return model.GetPolicy(PermConstants.Section.RoleSection, ptype);
        }

        /// <summary>
        /// Gets all the role inheritance rules in the policy, field filters can be specified.
        /// </summary>
        /// <param name="ptype">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>The filtered "g" policy rules of the specified ptype.</returns>
        public List<List<string>> GetFilteredNamedGroupingPolicy(string ptype, int fieldIndex, params string[] fieldValues)
        {
            return model.GetFilteredPolicy(PermConstants.Section.RoleSection, ptype, fieldIndex, fieldValues);
        }

        /// <summary>
        /// Determines whether an authorization rule exists.
        /// </summary>
        /// <param name="paramList">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasPolicy(List<string> paramList)
        {
            return HasNamedPolicy(PermConstants.DefautPolicyType, paramList);
        }

        /// <summary>
        /// Determines whether an authorization rule exists.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasPolicy(params string[] parameters)
        {
            return HasPolicy(parameters.ToList());
        }

        /// <summary>
        /// Determines whether a named authorization rule exists.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="paramList">The "p" policy rule.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasNamedPolicy(string ptype, List<string> paramList)
        {
            return model.HasPolicy(PermConstants.Section.PolicySection, ptype, paramList);
        }

        /// <summary>
        /// Determines whether a named authorization rule exists.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasNamedPolicy(string ptype, params string[] parameters)
        {
            return HasNamedPolicy(ptype, parameters.ToList());
        }

        /// <summary>
        /// Adds an authorization rule to the current policy. If the rule
        /// already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddPolicy(params string[] parameters)
        {
            return AddPolicy(parameters.ToList());
        }

        /// <summary>
        /// Adds an authorization rule to the current policy. If the rule
        /// already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> AddPolicyAsync(CancellationToken cancellationToken, params string[] parameters)
        {
            return AddPolicyAsync(parameters.ToList(), cancellationToken);
        }

        /// <summary>
        /// Adds an authorization rule to the current policy. If the rule
        /// already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddPolicy(List<string> parameters)
        {
            return AddNamedPolicy(PermConstants.DefautPolicyType, parameters);
        }

        /// <summary>
        /// Adds an authorization rule to the current policy. If the rule
        /// already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, pType "p" is implicitly used.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> AddPolicyAsync(List<string> parameters, CancellationToken cancellationToken)
        {
            return AddNamedPolicyAsync(PermConstants.DefautPolicyType, parameters, cancellationToken);
        }

        /// <summary>
        /// Adds an authorization rule to the current named policy.If the
        /// rule already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddNamedPolicy(string pType, params string[] parameters)
        {
            return AddNamedPolicy(pType, parameters.ToList());
        }

        /// <summary>
        /// Adds an authorization rule to the current named policy.If the
        /// rule already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> AddNamedPolicyAsync(string pType, CancellationToken cancellationToken, params string[] parameters)
        {
            return AddNamedPolicyAsync(pType, parameters.ToList(), cancellationToken);
        }

        /// <summary>
        /// Adds an authorization rule to the current named policy.If the
        /// rule already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddNamedPolicy(string pType, List<string> parameters)
        {
            return AddPolicy(PermConstants.Section.PolicySection, pType, parameters);
        }

        /// <summary>
        /// Adds an authorization rule to the current named policy.If the
        /// rule already exists, the function returns false and the rule will not be added.
        /// Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> AddNamedPolicyAsync(string pType, List<string> parameters, CancellationToken cancellationToken)
        {
            return AddPolicyAsync(PermConstants.Section.PolicySection, pType, parameters, cancellationToken);
        }

        /// <summary>
        /// Removes an authorization rule from the current policy.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemovePolicy(params string[] parameters)
        {
            return RemovePolicy(parameters.ToList());
        }

        /// <summary>
        /// Removes an authorization rule from the current policy.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemovePolicyAsync(CancellationToken cancellationToken, params string[] parameters)
        {
            return RemovePolicyAsync(parameters.ToList(), cancellationToken);
        }

        /// <summary>
        /// Removes an authorization rule from the current policy.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemovePolicy(List<string> parameters)
        {
            return RemoveNamedPolicy(PermConstants.Section.PolicySection, parameters);
        }

        /// <summary>
        /// Removes an authorization rule from the current policy.
        /// </summary>
        /// <param name="parameters">The "p" policy rule, ptype "p" is implicitly used.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemovePolicyAsync(List<string> parameters, CancellationToken cancellationToken)
        {
            return RemoveNamedPolicyAsync(PermConstants.DefautPolicyType, parameters, cancellationToken);
        }

        /// <summary>
        /// Removes an authorization rule from the current policy, field filters can be specified.
        /// </summary>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveFilteredPolicy(int fieldIndex, params string[] fieldValues)
        {
            return RemoveFilteredNamedPolicy(PermConstants.DefautPolicyType, fieldIndex, fieldValues);
        }

        /// <summary>
        /// Removes an authorization rule from the current policy, field filters can be specified.
        /// </summary>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveFilteredPolicyAsync(int fieldIndex, CancellationToken cancellationToken, params string[] fieldValues)
        {
            return RemoveFilteredNamedPolicyAsync(PermConstants.DefautPolicyType, fieldIndex, cancellationToken, fieldValues);
        }

        /// <summary>
        /// Removes an authorization rule from the current named policy.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveNamedPolicy(string pType, params string[] parameters)
        {
            return RemoveNamedPolicy(pType, parameters.ToList());
        }

        /// <summary>
        /// Removes an authorization rule from the current named policy.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveNamedPolicyAsync(string pType, CancellationToken cancellationToken, params string[] parameters)
        {
            return RemoveNamedPolicyAsync(pType, parameters.ToList(), cancellationToken);
        }

        /// <summary>
        /// Removes an authorization rule from the current named policy.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveNamedPolicy(string pType, List<string> parameters)
        {
            return RemovePolicy(PermConstants.Section.PolicySection, pType, parameters);
        }

        /// <summary>
        /// Removes an authorization rule from the current named policy.
        /// </summary>
        /// <param name="pType">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="parameters">The "p" policy rule.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveNamedPolicyAsync(string pType, List<string> parameters, CancellationToken cancellationToken)
        {
            return RemovePolicyAsync(PermConstants.Section.PolicySection, pType, parameters, cancellationToken);
        }

        /// <summary>
        /// Removes an authorization rule from the current named policy, field filters can be specified.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to  match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveFilteredNamedPolicy(string ptype, int fieldIndex, params string[] fieldValues)
        {
            return RemoveFilteredPolicy(PermConstants.Section.PolicySection, ptype, fieldIndex, fieldValues);
        }

        /// <summary>
        /// Removes an authorization rule from the current named policy, field filters can be specified.
        /// </summary>
        /// <param name="ptype">The policy type, can be "p", "p2", "p3", ..</param>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to  match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveFilteredNamedPolicyAsync(string ptype, int fieldIndex, CancellationToken cancellationToken, params string[] fieldValues)
        {
            return RemoveFilteredPolicyAsync(PermConstants.Section.PolicySection, ptype, fieldIndex, cancellationToken, fieldValues);
        }

        /// <summary>
        /// Determines whether a role inheritance rule exists.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasGroupingPolicy(List<string> parameters)
        {
            return HasNamedGroupingPolicy(PermConstants.DefaultGroupingPolicyType, parameters);
        }

        /// <summary>
        /// Determines whether a role inheritance rule exists.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasGroupingPolicy(params string[] parameters)
        {
            return HasGroupingPolicy(parameters.ToList());
        }

        /// <summary>
        /// Determines whether a named role inheritance rule
        /// exists.
        /// </summary>
        /// <param name="ptype">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="parameters">The "g" policy rule.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasNamedGroupingPolicy(string ptype, List<string> parameters)
        {
            return model.HasPolicy(PermConstants.Section.RoleSection, ptype, parameters);
        }

        /// <summary>
        /// Determines whether a named role inheritance rule
        /// exists.
        /// </summary>
        /// <param name="ptype">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="parameters">The "g" policy rule.</param>
        /// <returns>Whether the rule exists.</returns>
        public bool HasNamedGroupingPolicy(string ptype, params string[] parameters)
        {
            return HasNamedGroupingPolicy(ptype, parameters.ToList());
        }

        /// <summary>
        /// Adds a role inheritance rule to the current policy. If the
        /// rule already exists, the function returns false and the rule will not be
        /// Added.Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddGroupingPolicy(params string[] parameters)
        {
            return AddGroupingPolicy(parameters.ToList());
        }

        /// <summary>
        /// Adds a role inheritance rule to the current policy. If the
        /// rule already exists, the function returns false and the rule will not be
        /// Added.Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="cancellationToken">Instance of the cancellation toke</param>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> AddGroupingPolicyAsync(CancellationToken cancellationToken, params string[] parameters)
        {
            return AddGroupingPolicyAsync(parameters.ToList(), cancellationToken);
        }

        /// <summary>
        /// Adds a role inheritance rule to the current policy. If the
        /// rule already exists, the function returns false and the rule will not be
        /// Added.Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddGroupingPolicy(List<string> parameters)
        {
            return AddNamedGroupingPolicy(PermConstants.DefaultGroupingPolicyType, parameters);
        }

        /// <summary>
        /// Adds a role inheritance rule to the current policy. If the
        /// rule already exists, the function returns false and the rule will not be
        /// Added.Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> AddGroupingPolicyAsync(List<string> parameters, CancellationToken cancellationToken)
        {
            return AddNamedGroupingPolicyAsync(PermConstants.DefaultGroupingPolicyType, parameters, cancellationToken);
        }

        /// <summary>
        /// Adds a named role inheritance rule to the current 
        /// policy. If the rule already exists, the function returns false and the rule
        /// will not be added. Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="ptype">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="parameters">The "g" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddNamedGroupingPolicy(string ptype, List<string> parameters)
        {
            var ruleAdded = AddPolicy(PermConstants.Section.RoleSection, ptype, parameters);

            if (autoBuildRoleLinks)
            {
                BuildRoleLinks();
            }

            return ruleAdded;
        }

        /// <summary>
        /// Adds a named role inheritance rule to the current 
        /// policy. If the rule already exists, the function returns false and the rule
        /// will not be added. Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="pType">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="parameters">The "g" policy rule.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public async Task<bool> AddNamedGroupingPolicyAsync(string pType, List<string> parameters, CancellationToken cancellationToken)
        {
            var ruleAdded = await AddPolicyAsync(PermConstants.Section.RoleSection, pType, parameters, cancellationToken);

            if (autoBuildRoleLinks)
            {
                BuildRoleLinks();
            }

            return ruleAdded;
        }

        /// <summary>
        /// Adds a named role inheritance rule to the current 
        /// policy. If the rule already exists, the function returns false and the rule
        /// will not be added. Otherwise the function returns true by adding the new rule.
        /// </summary>
        /// <param name="ptype">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="parameters">The "g" policy rule.</param>
        /// <returns>Succeeds or not.</returns>
        public bool AddNamedGroupingPolicy(string ptype, params string[] parameters)
        {
            return AddNamedGroupingPolicy(ptype, parameters.ToList());
        }

        /// <summary>
        /// Removes a role inheritance rule from the current policy.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveGroupingPolicy(params string[] parameters)
        {
            return RemoveGroupingPolicy(parameters.ToList());
        }

        /// <summary>
        /// Removes a role inheritance rule from the current policy.
        /// </summary>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveGroupingPolicyAsync(CancellationToken cancellationToken, params string[] parameters)
        {
            return RemoveGroupingPolicyAsync(parameters.ToList(), cancellationToken);
        }

        /// <summary>
        /// Removes a role inheritance rule from the current policy.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveGroupingPolicy(List<string> parameters)
        {
            return RemoveNamedGroupingPolicy(PermConstants.DefaultGroupingPolicyType, parameters);
        }

        /// <summary>
        /// Removes a role inheritance rule from the current policy.
        /// </summary>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveGroupingPolicyAsync(List<string> parameters, CancellationToken cancellationToken)
        {
            return RemoveNamedGroupingPolicyAsync(PermConstants.DefaultGroupingPolicyType, parameters, cancellationToken);
        }

        /// <summary>
        /// Removes a role inheritance rule from the current 
        /// policy, field filters can be specified.
        /// </summary>
        /// <param name="pType">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveNamedGroupingPolicy(string pType, params string[] parameters)
        {
            return RemoveNamedGroupingPolicy(pType, parameters.ToList());
        }

        /// <summary>
        /// Removes a role inheritance rule from the current 
        /// policy, field filters can be specified.
        /// </summary>
        /// <param name="pType">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="cancellationToken">Instance of the cancellation toke</param>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveNamedGroupingPolicyAsync(string pType, CancellationToken cancellationToken, params string[] parameters)
        {
            return RemoveNamedGroupingPolicyAsync(pType, parameters.ToList(), cancellationToken);
        }

                /// <summary>
        /// Removes a role inheritance rule from the current 
        /// policy, field filters can be specified.
        /// </summary>
        /// <param name="pType">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="parameters">The "g" policy rule, ptype "g" is implicitly used.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveNamedGroupingPolicy(string pType, List<string> parameters)
        {
            var ruleRemoved = RemovePolicy(PermConstants.Section.RoleSection, pType, parameters);

            if (autoBuildRoleLinks)
            {
                BuildRoleLinks();
            }

            return ruleRemoved;
        }

                /// <summary>
                /// Removes a role inheritance rule from the current 
                /// policy, field filters can be specified.
                /// </summary>
                /// <param name="pType">The policy type, can be "g", "g2", "g3", ..</param>
                /// <param name="parameters">The "g" policy rule, pType "g" is implicitly used.</param>
                /// <param name="cancellationToken">Instance of the cancellation token</param>
                /// <returns>Succeeds or not.</returns>
                public async Task<bool> RemoveNamedGroupingPolicyAsync(string pType, List<string> parameters, CancellationToken cancellationToken)
        {
            var ruleRemoved = await RemovePolicyAsync(PermConstants.Section.RoleSection, pType, parameters, cancellationToken);

            if (autoBuildRoleLinks)
            {
                BuildRoleLinks();
            }

            return ruleRemoved;
        }

        /// <summary>
        /// Removes a role inheritance rule from the current 
        /// policy, field filters can be specified.
        /// </summary>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveFilteredGroupingPolicy(int fieldIndex, params string[] fieldValues)
        {
            return RemoveFilteredNamedGroupingPolicy(PermConstants.DefaultGroupingPolicyType, fieldIndex, fieldValues);
        }

        /// <summary>
        /// Removes a role inheritance rule from the current 
        /// policy, field filters can be specified.
        /// </summary>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="cancellationToken">Instance of the cancellation token</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public Task<bool> RemoveFilteredGroupingPolicyAsync(int fieldIndex, CancellationToken cancellationToken, params string[] fieldValues)
        {
            return RemoveFilteredNamedGroupingPolicyAsync(PermConstants.DefaultGroupingPolicyType, fieldIndex, cancellationToken, fieldValues);
        }

        /// <summary>
        /// Removes a role inheritance rule from the current named policy, field filters can be specified.
        /// </summary>
        /// <param name="pType">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public bool RemoveFilteredNamedGroupingPolicy(string pType, int fieldIndex, params string[] fieldValues)
        {
            var ruleRemoved = RemoveFilteredPolicy(PermConstants.Section.RoleSection, pType, fieldIndex, fieldValues);

            if (autoBuildRoleLinks)
            {
                BuildRoleLinks();
            }

            return ruleRemoved;
        }

        /// <summary>
        /// Removes a role inheritance rule from the current named policy, field filters can be specified.
        /// </summary>
        /// <param name="pType">The policy type, can be "g", "g2", "g3", ..</param>
        /// <param name="fieldIndex">The policy rule's start index to be matched.</param>
        /// <param name="cancellationToken"></param>
        /// <param name="fieldValues">The field values to be matched, value "" means not to match this field.</param>
        /// <returns>Succeeds or not.</returns>
        public async Task<bool> RemoveFilteredNamedGroupingPolicyAsync(string pType, int fieldIndex, CancellationToken cancellationToken, params string[] fieldValues)
        {
            var ruleRemoved = await RemoveFilteredPolicyAsync(PermConstants.Section.RoleSection, pType, fieldIndex, cancellationToken, fieldValues);

            if (autoBuildRoleLinks)
            {
                BuildRoleLinks();
            }

            return ruleRemoved;
        }

        /// <summary>
        /// Adds a customized function.
        /// </summary>
        /// <param name="name">The name of the new function.</param>
        /// <param name="function">The function.</param>
        public void AddFunction(string name, AbstractFunction function)
        {
            functionMap.AddFunction(name, function);
        }
    }
}
