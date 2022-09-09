using Assets.Scripts.Field;

namespace Assets.Scripts.Enemy
{
    public interface IMovementAgent
    {
        void TickMovement();

        Node GetCurrentNode();
    }
}
