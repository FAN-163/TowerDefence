using Assets.Scripts.Runtime;
using Assets.Scripts.Turret;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.InGame.TurretMarket
{
    public class TurretInfoUI : MonoBehaviour
    {
        [SerializeField] private Image m_Image;
        [SerializeField] private Text m_PriceText;
        [SerializeField] private Text m_DescriptionText;
        [SerializeField] private Button m_ChoosenButton;

        private TurretAsset m_Asset;

        public void SetTurret(TurretAsset asset)
        {
            m_Asset = asset;

            m_Image.sprite = asset.Sprite;
            m_DescriptionText.text = asset.Description;
            m_PriceText.text = $"Price: {asset.Price}";

            m_ChoosenButton.onClick.AddListener(OnClick);

            Game.Player.TurretMarket.MoneyChanged += CheckAvailability;
        }

        private void OnDisable()
        {
            Game.Player.TurretMarket.MoneyChanged -= CheckAvailability;
        }

        private void CheckAvailability(int money)
        {
            m_ChoosenButton.interactable = money >= m_Asset.Price;
        }

        private void OnClick()
        {
            Game.Player.TurretMarket.ChooseTurret(m_Asset);
        }

    }
}
