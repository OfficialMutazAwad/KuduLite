﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kudu.Services.DaaS
{
    /// <summary>
    /// Interface for interacting with diagnostic sessions
    /// </summary>
    public interface ISessionManager
    {
        /// <summary>
        /// Submit a new DaaS session
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        Task<string> SubmitNewSessionAsync(Session session);
        
        /// <summary>
        /// Lists all DaaS sessions, complete as well as active
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Session>> GetAllSessionsAsync();

        /// <summary>
        /// Get a specific DaaS session
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<Session> GetSessionAsync(string sessionId);

        /// <summary>
        /// Gets the active diagnostic session object
        /// </summary>
        /// <returns></returns>
        Task<Session> GetActiveSessionAsync();

        /// <summary>
        /// Once a DaaS session is submitted, this method should be
        /// called to run the diagnostic tool specified in the session
        /// </summary>
        /// <param name="activeSession"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        Task RunToolForSessionAsync(Session activeSession, CancellationToken token);

        /// <summary>
        /// Checks if the current instance is specified in the list of instances to collect
        /// data from the diagnostic session
        /// </summary>
        /// <param name="activeSession"></param>
        /// <returns></returns>
        bool ShouldCollectOnCurrentInstance(Session activeSession);

        /// <summary>
        /// Checks if the current instance has already collected the logs for the diagnostic
        /// session or not
        /// </summary>
        /// <returns></returns>
        Task<bool> HasThisInstanceCollectedLogs();

        /// <summary>
        /// Marks a diagnostic session as complete if all instances have finished collecting
        /// data
        /// </summary>
        /// <param name="forceCompletion"></param>
        /// <returns></returns>
        Task<bool> CheckandCompleteSessionIfNeededAsync(bool forceCompletion = false);
    }
}