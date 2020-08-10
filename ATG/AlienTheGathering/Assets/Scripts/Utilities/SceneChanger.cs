using UnityEngine;
using UnityEngine.SceneManagement;

namespace ATG.Utilities
{
    public class SceneChanger : MonoBehaviour
    {
        public void Change(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
