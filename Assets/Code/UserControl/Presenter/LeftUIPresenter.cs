using UserControl.Model;
using Abstractions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UserControl.Presenter
{
    public sealed class LeftUIPresenter : MonoBehaviour
    {
        [SerializeField] private SelectedValue _selectedValue;
        [SerializeField] private Image _icon;
        [SerializeField] private Image _health;
        [SerializeField] private Image _healthValue;
        [SerializeField] private Color _emptyColor;
        [SerializeField] private Color _fullColor;
        [SerializeField] private TMP_Text _healthText;

        private void Start()
        {
            _selectedValue.SelectionChanged += UpdateUI;
            UpdateUI(null);
        }

        private void OnDestroy()
        {
            _selectedValue.SelectionChanged -= UpdateUI;
        }

        private void UpdateUI(ISelectable selectable)
        {
            _icon.enabled = selectable != null;
            _health.gameObject.SetActive(selectable != null);
            _healthText.enabled = selectable != null;

            if(selectable != null)
            {
                _icon.sprite = selectable.Icon;
                _healthText.text = $"{selectable.Health}/{selectable.MaxHealth}";

                float percentFill = (float) selectable.Health / selectable.MaxHealth;
                _healthValue.fillAmount = percentFill;
                _healthValue.color = Color.Lerp(_emptyColor, _fullColor, percentFill);
            }
        }
    }
}
