using UnityEngine;
using Game.SceneManagement;

namespace Game.MainMenu
{
    public class MenuSceneManager : MonoBehaviour
    {
        private readonly SceneManager _manager = new SceneManager();

        public void LoadGame()
        {
            _manager.LoadScene(Scenes.OpenWorld);
        }
    }
}