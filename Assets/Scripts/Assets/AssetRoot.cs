using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

namespace Assets.Scripts.Assets
{
    [CreateAssetMenu(menuName = "Assets/Asset Root", fileName = "Asset Root")]
    public class AssetRoot : ScriptableObject
    {
        public SceneAsset UIScene;
        public List<LevelAsset> Levels;
    }
}
