using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Field
{
    internal class FlowFieldPathfinding
    {
        private Grid grid;
        private Vector2Int target;

        public FlowFieldPathfinding(Grid grid, Vector2Int target)
        {
            this.grid = grid;
            this.target = target;
        }

        public void UpdateField()
        {
            foreach(Node node in grid.EnumerateAllNodes())
            {
                node.ResetWeight();
            }

            Queue<Vector2Int> queue = new Queue<Vector2Int>();

            queue.Enqueue(target);
            grid.GetNode(target).PathWeight = 0.0f;

            while(queue.Count > 0)
            {
                Vector2Int current = queue.Dequeue();
                Node currentNode = grid.GetNode(current);
                float weightToTarget = currentNode.PathWeight + 1.0f;

                foreach(Vector2Int neighbour in GetNeighours(current))
                {
                    Node neighbourNode = grid.GetNode(neighbour);
                    if(weightToTarget < neighbourNode.PathWeight)
                    {
                        neighbourNode.NextNode = currentNode;
                        neighbourNode.PathWeight = weightToTarget;
                        queue.Enqueue(neighbour);
                    }
                }
            }
        }

        private IEnumerable<Vector2Int> GetNeighours(Vector2Int coordinate)
        {
            Vector2Int rightCoordinate = coordinate + Vector2Int.right;
            Vector2Int leftCoordinate = coordinate + Vector2Int.left;
            Vector2Int upCoordinate = coordinate + Vector2Int.up;
            Vector2Int downCoordinate = coordinate + Vector2Int.down;

            bool hasRightNode = rightCoordinate.x < grid.Width && !grid.GetNode(rightCoordinate).IsOccupied;
            bool hasLeftNode = leftCoordinate.x >= 0 && !grid.GetNode(leftCoordinate).IsOccupied;
            bool hasUpNode = upCoordinate.y < grid.Height && !grid.GetNode(upCoordinate).IsOccupied;
            bool hasDownNode = downCoordinate.y >= 0 && !grid.GetNode(downCoordinate).IsOccupied;

            if(hasRightNode)
            {
                yield return rightCoordinate;
            }

            if(hasLeftNode)
            {
                yield return leftCoordinate;
            }

            if(hasUpNode)
            {
                yield return upCoordinate;
            }

            if(hasDownNode)
            {
                yield return downCoordinate;
            }
        }
    }
}
