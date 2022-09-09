
namespace Assets.Scripts.Runtime
{
    public interface IController
    {
        void OnStart();
        void OnStop();
        void Tick();
    }
}
