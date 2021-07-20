using UnityEngine.SceneManagement;

namespace Game.SceneManagement
{
    public class SceneManager
    {
        public void LoadScene(Scenes scene)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync((int)scene);
        }

    }
}

