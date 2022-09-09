using Assets.Scripts.Assets;
using UnityEngine;


namespace Assets.Scripts.EnemySpawn
{

    [CreateAssetMenu(menuName = "Assets/Spawn Waves Asset", fileName = "Spawn Waves Asset")]
    public class SpawnWavesAsset : ScriptableObject
    {
        public SpawnWave[] SpawnWaves;
    }
}
