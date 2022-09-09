using Assets.Scripts.Runtime;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.InGame
{
    public class GamePlayInfoUI : MonoBehaviour
    {
        [SerializeField] private Text m_HealthText;
        [SerializeField] private Text m_MoneyText;


        private void OnEnable()
        {
            SetHealth(Game.Player.Health);
            SetMoney(Game.Player.TurretMarket.Money);

            Game.Player.HealthChanged += SetHealth;
            Game.Player.TurretMarket.MoneyChanged += SetMoney;
        }

        private void OnDisable()
        {
            Game.Player.HealthChanged -= SetHealth;
            Game.Player.TurretMarket.MoneyChanged -= SetMoney;
        }

        private void SetHealth(int health)
        {
            m_HealthText.text = $"Health: {health}";
        }
        private void SetMoney(int money)
        {
            m_MoneyText.text = $"Health: {money}";
        }
    }
}
