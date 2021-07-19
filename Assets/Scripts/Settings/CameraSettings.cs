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
            if(_settings == null)
            {
                _settings = LoadFromJson();
                return _settings;
            }
            return null;
        }

        private static void SaveToJson(MainSettings settings)
        {
            string json = JsonUtility.ToJson(settings, true);
            if (File.Exists(_settingsPath))
            {
                File.WriteAllText(_settingsPath, json);
            } else
            {
                var file = File.Create(_settingsPath);
                file.Close();
                File.WriteAllText(_settingsPath, json);
            }
            
        }

        private static MainSettings LoadFromJson()
        {
            if (File.Exists(_settingsPath))
            {
                string json = File.ReadAllText(_settingsPath);
                return JsonUtility.FromJson<MainSettings>(json);
            } else
            {
                File.Create(_settingsPath);
                string json = File.ReadAllText(_settingsPath);
                return JsonUtility.FromJson<MainSettings>(json);
            }

        }

    }
}