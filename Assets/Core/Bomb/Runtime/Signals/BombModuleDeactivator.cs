using System;
using System.Collections.Generic;
using System.Linq;
using Core.Bomb.Runtime.Deactivation;

namespace Core.Bomb.Runtime.Bomb
{
    public class BombModuleDeactivator : IBombSignalObserver
    {
        private readonly IDictionary<int, IDeactivationModule> m_DeactivationModules;
        private readonly Action m_OnAllModulesDefused;

        public BombModuleDeactivator(IDictionary<int, IDeactivationModule> deactivationModules, Action onAllModulesDefused)
        {
            m_DeactivationModules = deactivationModules;
            m_OnAllModulesDefused = onAllModulesDefused;
        }

        public void OnSignalReceived(int id, string signalKey)
        {
            if (signalKey != BombEnvironment.DeactivationEvents.Deactivate)
            {
                return;
            }
            
            var isAllModulesDefused = m_DeactivationModules.Values.All(m => m.IsDeactivated);
            if (isAllModulesDefused)
            {
                m_OnAllModulesDefused?.Invoke();
            }
        }
    }
}