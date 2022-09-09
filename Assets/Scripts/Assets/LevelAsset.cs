using Assets.Scripts.EnemySpawn;
using Assets.Scripts.TurretSpawn;
using UnityEditor;
using UnityEngine;

namespace Assets.Scripts.Assets
{
    [CreateAssetMenu(menuName = "Assets/Level Asset", fileName = "Level Asset")]
    public class LevelAsset : ScriptableObject
    {
        public SceneAsset SceneAsset;
        public SpawnWavesAsset SpawnWavesAsset;
        public TurretMarketAsset TurretMarketAsset;

        public int StartHealth;
        public int StartMoney;
    }
}
