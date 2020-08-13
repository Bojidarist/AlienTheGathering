using ATG.Utilities;
using UnityEngine;

namespace ATG.Core
{
    public class GameManager : MonoBehaviour
    {
        public SceneChanger sceneChanger { get; set; }

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

            sceneChanger = new SceneChanger();
        }

        public void StartGame()
        {
            UIManager.Instance.RemoveMainMenuUI();
            UIManager.Instance.RemoveRestartUI();
            UIManager.Instance.RemoveTitleScreenUI();
            sceneChanger.Change(SceneNames.CowLevel);
            ATGConfig.EnemyCount = 2;
        }

        public void LoseGame()
        {
            UIManager.Instance.ShowRestartUI();
        }

        public void CloseGame()
        {
            Application.Quit(0);
        }
    }
}
