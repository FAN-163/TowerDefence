using Assets.Scripts.Enemy;
using Assets.Scripts.EnemySpawn;
using Assets.Scripts.Field;
using Assets.Scripts.Main;
using Assets.Scripts.Turret.Weapon;
using Assets.Scripts.TurretSpawn;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Runtime
{
    public class Runner : MonoBehaviour 
    {
        private List<IController> m_Controllers;
        private bool m_IsRunning = false;

        private void Update()
        {
            if(!m_IsRunning)
            {
                return;
            }
            TickControllers();
        }

        public void StartRunning()
        {
            CreateAllControllers();
            OnStartControllers();
            m_IsRunning = true;
        }

        public void StopRunning()
        {
            m_IsRunning = false;
            OnStopControllers();
        }

        private void CreateAllControllers()
        {
            m_Controllers = new List<IController>()
            {
                new GridRaycastController(Game.Player.GridHolder),
                new EnemySpawnController(Game.CurrentLevel.SpawnWavesAsset, Game.Player.Grid),
                new TurretSpawnerController(Game.Player.Grid, Game.Player.TurretMarket),
                new MovementController(),
                new EnemyReachController(Game.Player.Grid),
                new TurretShootController(),
                new EnemyDeathController(),
                new LoseController(),
                new WinController()
            };
        }

        private void OnStartControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.OnStart();
                }
                catch(Exception e)
                {
                    Debug.LogError(e);
                }
               
            }
        }

        private void TickControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                if(!m_IsRunning)
                {
                    return;
                }

                try
                {
                    controller.Tick();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

            }
        }

        private void OnStopControllers()
        {
            foreach (IController controller in m_Controllers)
            {
                try
                {
                    controller.OnStop();
                }
                catch (Exception e)
                {
                    Debug.LogError(e);
                }

            }
        }
    }
}
