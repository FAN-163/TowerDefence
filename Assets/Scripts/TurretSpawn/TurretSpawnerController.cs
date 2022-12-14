using Assets.Scripts.Field;
using Assets.Scripts.Runtime;
using Assets.Scripts.Turret;
using UnityEngine;

namespace Assets.Scripts.TurretSpawn
{
    public class TurretSpawnerController : IController
    {
        private Field.Grid m_Grid;
        private TurretMarket m_Market;

        public TurretSpawnerController(Field.Grid grid, TurretMarket market)
        {
            m_Grid = grid;
            m_Market = market;
        }

        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            if(m_Grid.HasSelectedNode() && Input.GetMouseButtonDown(0))
            {
                Node selectedNode = m_Grid.GetSelectedNode();

                if (selectedNode.IsOccupied)
                {
                    return;
                }

                TurretAsset asset = m_Market.ChosenTurret;

                if(asset != null)
                {
                    m_Market.BuyTurret(asset);
                    SpawnTurret(asset, selectedNode);
                }
                else
                {
                    Debug.Log("Not enough money");
                }
            }
            
        }

        private void SpawnTurret(TurretAsset asset, Node node)
        {
            TurretView view = Object.Instantiate(asset.ViewPrefab);
            TurretData data = new TurretData(asset, node);

            data.AttachView(view);
            Game.Player.TurretSpawned(data);

            node.IsOccupied = true;
            m_Grid.UpdatePathfinding();
        }
    }
}
