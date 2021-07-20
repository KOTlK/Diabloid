using System.Collections;
using UnityEngine;
using System.IO;

namespace Game.Settings
{
    public class CameraSettings
    {
        private static MainSettings _settings;
        private readonly static string _settingsPath = Application.persistentDataPath + "/Settings.json";

        public static bool isEmpty
        {
            get
            {
                if (_settings == null)
                {
                    return true;
                } else
                {
                    return false;
                }
            }

            private set { }
        }

        public static void Save(MainSettings settings)
        {
            _settings = settings;
            SaveToJson(_settings);
        }

        public static MainSettings Load()
        {
            return LoadFromJson();
        }

        private static void SaveToJson(MainSettings settings)
        {
            string json = JsonUtility.ToJson(settings, true);
            File.WriteAllText(_settingsPath, json);
        }

        private static MainSettings LoadFromJson()
        {
            if (File.Exists(_settingsPath))
            {
                string json = File.ReadAllText(_settingsPath);
                Debug.Log(json);
                return JsonUtility.FromJson<MainSettings>(json);
            } else
            {
                string json = JsonUtility.ToJson(GetDefaultSettings(), true);
                File.WriteAllText(_settingsPath, json);
                return JsonUtility.FromJson<MainSettings>(json);
            }

        }

        private static MainSettings GetDefaultSettings()
        {
            MainSettings temp = new MainSettings();
            temp.MoveCameraWithMouse = true;
            return temp;
        }

    }
}