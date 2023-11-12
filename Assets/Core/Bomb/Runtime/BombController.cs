using System;
using System.Collections.Generic;
using System.Linq;
using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Deactivation;
using UnityEngine;

namespace Core.Bomb.Runtime
{
    public class BombController : IDisposable
    {
        private readonly BombSetting m_BombSetting;
        private readonly Dictionary<int, IBombModule> m_BombModules;
        private readonly BombSignalProducer m_BombSignalProducer;
        private readonly MistakesCounter m_MistakesCounter;
        
        private BombModuleDeactivator m_BombModuleDeactivator;
        private BombModuleDetonator m_BombModuleDetonator;

        public BombController(BombSetting bombSetting)
        {
            m_BombSetting = bombSetting;
            m_MistakesCounter = bombSetting.MistakesCounter;
            m_BombSignalProducer = new BombSignalProducer();
            m_BombModules = new Dictionary<int, IBombModule>();
        }

        public void Plant()
        {
            var moduleFactories = m_BombSetting.BombModuleFactories;
            for (int i = 0; i < moduleFactories.Count; i++)
            {
                var module = moduleFactories[i].Create(i, m_BombSignalProducer);
                m_BombModules.Add(i, module);
            }

            CreateModuleDeactivator();
            CreateModuleDetonator();
            m_BombSignalProducer.Attach(m_MistakesCounter);
            
            foreach (var bombModules in m_BombModules.Values)
            {
                bombModules.Start();
            }
            
            Debug.Log("bomb has been planted");
        }
        
        private void CreateModuleDeactivator()
        {
            var deactivationModules = new Dictionary<int, IDeactivationModule>();
            
            foreach (var bombModule in m_BombModules)
            {
                if (bombModule.Value is IDeactivationModule module)
                {
                    deactivationModules.Add(bombModule.Key, module);
                }
            }

            if (deactivationModules.Any())
            {
                m_BombModuleDeactivator = new BombModuleDeactivator(deactivationModules, Defuse);
                m_BombSignalProducer.Attach(m_BombModuleDeactivator);
            }
        }

        private void CreateModuleDetonator()
        {
            m_BombModuleDetonator = new BombModuleDetonator(Detonate); 
            m_BombSignalProducer.Attach(m_BombModuleDetonator);
        }
        
        private void Defuse()
        {
            StopAllModules();
            Debug.Log("bomb has been defused");

        }

        private void Detonate()
        {
            StopAllModules();
            Debug.Log("bomb has been detonate");
        }

        private void StopAllModules()
        {
            foreach (var bombModule in m_BombModules.Values)
            {
                bombModule.Stop();
            }
        }

        public void Dispose()
        {
            m_BombSignalProducer.Detach(m_BombModuleDeactivator);
            m_BombSignalProducer.Detach(m_BombModuleDetonator);
            m_BombSignalProducer.Detach(m_MistakesCounter);

            foreach (var bombModules in m_BombModules.Values)
            {
                bombModules.Dispose();
            }
        }
    }
}