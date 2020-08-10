using UnityEngine.SceneManagement;

namespace ATG.Utilities
{
    public class SceneChanger
    {
        public void Change(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
