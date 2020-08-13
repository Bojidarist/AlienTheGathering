using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATG.Core
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject MainMenuUI = default;
        [SerializeField] private GameObject TitleScreenUI = default;
        [SerializeField] private GameObject RestartUI = default;

        public static UIManager Instance { get; set; }

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
        }

        public void ShowMainMenuUI()
        {
            MainMenuUI.SetActive(true);
        }

        public void RemoveMainMenuUI()
        {
            MainMenuUI.SetActive(false);
        }

        public void ShowRestartUI()
        {
            RestartUI.SetActive(true);
        }

        public void RemoveRestartUI()
        {
            RestartUI.SetActive(false);
        }

        public void ShowTitleScreenUI()
        {
            TitleScreenUI.SetActive(true);
        }

        public void RemoveTitleScreenUI()
        {
            TitleScreenUI.SetActive(false);
        }
    }
}