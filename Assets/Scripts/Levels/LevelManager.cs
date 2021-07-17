using UnityEngine;
using UnityEngine.SceneManagement;

namespace Levels
{
    public class LevelManager : MonoBehaviour, ILevelManager
    {
        public void LoadNext()
        {
            ReloadScene();
        }

        public void Reload()
        {
            ReloadScene();
        }

        private static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}