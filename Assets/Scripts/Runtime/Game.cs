using Assets.Scripts.Assets;
using Assets.Scripts.Main;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Runtime
{
    public static class Game
    {
        private static Player s_Player;
        private static AssetRoot s_AssetRoot;
        private static LevelAsset s_CurrentLevel;

        private static Runner s_Runner;

        public static Player Player => s_Player;
        public static AssetRoot AssetRoot => s_AssetRoot;
        public static LevelAsset CurrentLevel => s_CurrentLevel;

        public static void SetAssetRoot(AssetRoot assetRoot)
        {
            s_AssetRoot = assetRoot;
        }

        public static void StartLevel(LevelAsset levelAsset)
        {
            s_CurrentLevel = levelAsset;
            AsyncOperation operation = SceneManager.LoadSceneAsync(levelAsset.SceneAsset.name);
            operation.completed += StartPlayer;
        }
        private static void StartPlayer(AsyncOperation operation)
        {
            if(!operation.isDone)
            {
                throw new Exception("Can't load scene");
            }
            s_Player = new Player();
            s_Runner = UnityEngine.Object.FindObjectOfType<Runner>();
            s_Runner.StartRunning();

            SceneManager.LoadScene(AssetRoot.UIScene.name, LoadSceneMode.Additive);
        }

        public static void StopPlayer()
        {
            s_Runner.StopRunning();
        }
    }
}
