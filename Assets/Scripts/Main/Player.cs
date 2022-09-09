using Assets.Scripts.Enemy;
using Assets.Scripts.Field;
using Assets.Scripts.Runtime;
using Assets.Scripts.Turret;
using Assets.Scripts.Turret.Weapon;
using Assets.Scripts.TurretSpawn;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class Player
    {
        private List<EnemyData> m_EnemyDatas = new List<EnemyData>();

        public IReadOnlyList<EnemyData> EnemyDatas => m_EnemyDatas;

        private List<TurretData> m_TurretDatas = new List<TurretData>();

        public IReadOnlyList<TurretData> TurretDatas => m_TurretDatas;

        public readonly GridHolder GridHolder;
        public readonly Field.Grid Grid;
        public readonly TurretMarket TurretMarket;
        public readonly EnemySearch EnemySearch;

        private bool m_AllWavesAreSpawned = false;
        private int m_Health;

        public int Health => m_Health;

        public event Action<int> HealthChanged;

        public Player()
        {
            GridHolder = UnityEngine.Object.FindObjectOfType<GridHolder>();
            GridHolder.CreateGrid();
            Grid = GridHolder.Grid;

            TurretMarket = new TurretMarket();

            EnemySearch = new EnemySearch(m_EnemyDatas);
            m_Health = Game.CurrentLevel.StartHealth;
        }

        public void EnemySpawned(EnemyData data)
        {
            m_EnemyDatas.Add(data);
        }
        public void EnemyDied(EnemyData data)
        {
            m_EnemyDatas.Remove(data);
        }

        public void EnemyReachedTarget(EnemyData data)
        {
            m_EnemyDatas.Remove(data);
        }

        public void LastWaveSpawned()
        {
            m_AllWavesAreSpawned = true;
        }

        public void ApplyDamage(int damage)
        {
            m_Health -= damage;
            HealthChanged?.Invoke(m_Health);
        }

        public void TurretSpawned(TurretData data)
        {
            m_TurretDatas.Add(data);
        }
        public void CheckForWin()
        {
            if (m_AllWavesAreSpawned && m_EnemyDatas.Count == 0)
            {
                GameWon();
            }
        }

        private void GameWon()
        {
            Debug.Log("Win");
        }

        public void CheckForLose()
        {
            if(m_Health <= 0)
            {
                GameLost();
            }
        }

        private void GameLost()
        {
            Game.StopPlayer();
            Debug.Log("Lose");
        }

        public void Pause()
        {
            Time.timeScale = 0.0f;
        }

        public void UnPause()
        {
            Time.timeScale = 1.0f;
        }
    }
}
