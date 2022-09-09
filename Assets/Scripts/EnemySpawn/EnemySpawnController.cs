using Assets.Scripts.Assets;
using Assets.Scripts.Enemy;
using Assets.Scripts.Field;
using Assets.Scripts.Runtime;
using System.Collections;
using UnityEngine;
using Grid = Assets.Scripts.Field.Grid;

namespace Assets.Scripts.EnemySpawn
{
    public class EnemySpawnController : IController
    {
        private SpawnWavesAsset m_SpawnWaves;
        private Grid m_Grid;

        private IEnumerator m_SpawnRoutine;

        private float m_WaitTime;

        public EnemySpawnController(SpawnWavesAsset spawnWaves, Grid grid)
        {
            m_SpawnWaves = spawnWaves;
            m_Grid = grid;
        }

        public void OnStart()
        {
            m_WaitTime = Time.time;
            m_SpawnRoutine = SpawnRoutine();
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            if(m_WaitTime > Time.time)
            {
                return;
            }

            if(m_SpawnRoutine.MoveNext())
            {
                if(m_SpawnRoutine.Current is CustomWaitForSecond waitForSeconds)
                {
                    m_WaitTime = Time.time + waitForSeconds.Seconds;
                }
            }
        }

        private IEnumerator SpawnRoutine()
        {
            foreach (SpawnWave wave in m_SpawnWaves.SpawnWaves)
            {
                yield return new CustomWaitForSecond(wave.TimeBeforeStartWave);

                for(int i = 0; i < wave.Count; i++)
                {
                    SpawnEnemy(wave.EnemyAsset);

                    if (i < wave.Count - 1)
                    {
                        yield return new CustomWaitForSecond(wave.TimeBetweenSpawns);
                    }
                }

                //todo show wave number
            }

            Game.Player.LastWaveSpawned();
        }

        private void SpawnEnemy(EnemyAsset asset)
        {
            EnemyView view = Object.Instantiate(asset.ViewPrefab);
            view.transform.position = m_Grid.GetStartNode().Position;
            EnemyData data = new EnemyData(asset);

            data.AttachView(view);
            view.CreateMovementAgent(m_Grid);

            Game.Player.EnemySpawned(data);
        }

        private class CustomWaitForSecond
        {
            public readonly float Seconds;

            public CustomWaitForSecond(float seconds)
            {
                Seconds = seconds;
            }
        }
    }
}
