using System.Collections.Generic;
using Core.Bomb.Runtime;
using Core.Bomb.Runtime.Bomb;
using Core.Bomb.Runtime.Deactivation;
using Core.Bomb.Runtime.Deactivation.Wire;
using Core.Bomb.Runtime.Modules;
using Core.Bomb.Runtime.Modules.Mistakes;
using Core.Bomb.Runtime.Modules.Timer;
using Core.CoroutineRunner.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Core.Bomb.Sample
{
    public class BombWizardSample : MonoBehaviour, ICoroutineRunner
    {
        [SerializeField] private RectTransform m_TimerViewParent;
        [SerializeField] private RectTransform m_DeactivationViewParent;
        [SerializeField] private RectTransform m_MistakeViewParent;
        
        [SerializeField] private TimerModuleSettingSample m_TimerModuleSettingSample;
        [SerializeField] private List<WireModuleSettingSample> m_WireModuleSettingSamples;
        [SerializeField] private MistakeModuleSettingSample m_MistakeModuleSettingSample;

        [SerializeField] private Button m_CreateBombButton;
        
        private Dictionary<string, RectTransform> m_ViewParents;
        private IList<IBombModuleSetting> m_BombModuleSettings;
        private MistakesCounter m_MistakesCounter = new MistakesCounter();
        
        private void Start()
        {
            m_ViewParents = new Dictionary<string, RectTransform>();
            m_ViewParents.Add(BombEnvironment.ModuleType.Timer, m_TimerViewParent);
            m_ViewParents.Add(BombEnvironment.ModuleType.Deactivation, m_DeactivationViewParent);
            m_ViewParents.Add(BombEnvironment.ModuleType.MistakeCounter, m_MistakeViewParent);
            
            m_CreateBombButton.onClick.RemoveListener(CreateBomb);
            m_CreateBombButton.onClick.AddListener(CreateBomb);
        }

        private void ConfigureSettings()
        {
            m_BombModuleSettings = new List<IBombModuleSetting>();
            var timerModuleSettingSample = new TimerModuleSetting
            {
                TimeToDetonate = m_TimerModuleSettingSample.TimeToDetonate,
                DefaultStateSetting = m_TimerModuleSettingSample.DefaultStateSetting,
                WarningStateSetting = m_TimerModuleSettingSample.WarningStateSetting,
                CoroutineRunner = this,
                ViewParent = GetViewParent(m_TimerModuleSettingSample.ModuleType),
                View = m_TimerModuleSettingSample.View
            };

            m_BombModuleSettings.Add(timerModuleSettingSample);

            foreach (var wireModuleSettingSample in m_WireModuleSettingSamples)
            {
                var wireModuleSetting = new WireModuleSetting()
                {
                    Wires = wireModuleSettingSample.Wires,
                    ViewParent = GetViewParent(wireModuleSettingSample.ModuleType),
                    View = wireModuleSettingSample.View
                };
                
                m_BombModuleSettings.Add(wireModuleSetting);
            }

            var mistakeModuleSettingSample = new MistakeModuleSetting
            {
                MaxAllowableMistakesCount = m_MistakeModuleSettingSample.MaxAllowableMistakesCount,
                ViewParent = GetViewParent(m_MistakeModuleSettingSample.ModuleType),
                View = m_MistakeModuleSettingSample.View,
                MistakesCounter = m_MistakesCounter
            };
            
            m_BombModuleSettings.Add(mistakeModuleSettingSample);
        }

        private void CreateBomb()
        {
            m_CreateBombButton.interactable = false;
            ConfigureSettings();
            
            var configurator = new BombModuleFactoryConfigurator();
            var moduleFactories = new List<IBombModuleFactory>();
            foreach (var moduleSetting in m_BombModuleSettings)
            {
                var moduleFactory = configurator.GetConfiguredFactory(moduleSetting);
                moduleFactories.Add(moduleFactory);
            }
            
            var bombSettings = new BombSetting
            {
                BombModuleFactories = moduleFactories,
                MistakesCounter = m_MistakesCounter
            };
            
            var bomb = new BombController(bombSettings);
            bomb.Plant();
        }
        
        private RectTransform GetViewParent(string key)
        {
            if (m_ViewParents.TryGetValue(key, out var parent))
            {
                return parent;
            }

            return null;
        }
    }
}