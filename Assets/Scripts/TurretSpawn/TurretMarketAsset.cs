using Assets.Scripts.Turret;
using UnityEngine;

namespace Assets.Scripts.TurretSpawn
{
    [CreateAssetMenu(menuName = "Assets/Turret Market Asset", fileName = "Turret Market Asset")]
    public class TurretMarketAsset : ScriptableObject
    {
        public TurretAsset[] TurretAssets;
    }
}
