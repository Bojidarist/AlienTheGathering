using ATG.Utilities;
using UnityEngine;

namespace ATG.Core
{
    public class GameManager : MonoBehaviour
    {
        public SceneChanger SceneChanger { get; set; }

        public static GameManager Instance { get; set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                Instance = this;
            }

            SceneChanger = new SceneChanger();
        }

        public void CloseGame()
        {
            Application.Quit(0);
        }
    }
}
