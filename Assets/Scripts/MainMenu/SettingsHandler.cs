using System.Collections;
using System.Collections.Generic;
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


        private void FixedUpdate()
        {
            Debug.Log($"{_settings.MoveCameraWithMouse}, {_toggle.isOn}");
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

