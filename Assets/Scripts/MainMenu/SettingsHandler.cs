using UnityEngine;
using UnityEngine.UI;
using Game.Settings;

namespace Game.MainMenu
{
    public class SettingsHandler : MonoBehaviour
    {
        [SerializeField] private Toggle _toggle;
        private MainSettings _settings;

        private void Awake()
        {
            _settings = CameraSettings.Load();

            _toggle.isOn = _settings.MoveCameraWithMouse;
        }


        private void OnEnable()
        {
            _toggle.onValueChanged.AddListener(delegate { ReverseSettings(); });
        }

        private void OnDisable()
        {
            _toggle.onValueChanged.RemoveAllListeners();
        }

        public void ReverseSettings()
        {
            _settings.MoveCameraWithMouse = !_settings.MoveCameraWithMouse;
        }

        public void ApplySettings()
        {
            CameraSettings.Save(_settings);
        }
    }
}

