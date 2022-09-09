using Assets.Scripts.Field;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public class UnitSpawner : MonoBehaviour
    {
        [SerializeField] private GridMovementAgent movementAgent;
        [SerializeField] private GridHolder gridHolder;


        private void Awake()
        {
            StartCoroutine(SpawnUnitsCoroutine());
        }

        private IEnumerator SpawnUnitsCoroutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(1.0f);
                SpawnerUnit();
            }
        }
        private void SpawnerUnit()
        {
            Node startNode = gridHolder.Grid.GetNode(gridHolder.StartCoordinate);
            Vector3 position = startNode.Position;
           // GridMovementAgent movementAgent = Instantiate(this.movementAgent, position, Quaternion.identity);
           // movementAgent.SetTargetNode(startNode);
        }
    }
}
