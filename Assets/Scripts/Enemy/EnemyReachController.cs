using Assets.Scripts.Field;
using Assets.Scripts.Runtime;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Enemy
{
    public class EnemyReachController : IController
    {
        private Node m_TargetNode;
        private List<EnemyData> m_ReachEnemyDatas = new List<EnemyData>();

        public EnemyReachController(Grid grid)
        {
            m_TargetNode = grid.GetTargetNode();
        }

        public void OnStart()
        {
        }

        public void OnStop()
        {
        }

        public void Tick()
        {
            foreach(EnemyData enemyData in Game.Player.EnemyDatas)
            {
                if (enemyData.IsDead)
                {
                    continue;
                }

                if(enemyData.View.MovementAgent.GetCurrentNode() == m_TargetNode)
                {
                    Game.Player.ApplyDamage(enemyData.Asset.Damage);
                    m_ReachEnemyDatas.Add(enemyData);
                    enemyData.ReachedTarget();
                }
            }

            foreach(EnemyData enemyData in m_ReachEnemyDatas)
            {
                Game.Player.EnemyReachedTarget(enemyData);
            }

            m_ReachEnemyDatas.Clear();
        }
    }
}
