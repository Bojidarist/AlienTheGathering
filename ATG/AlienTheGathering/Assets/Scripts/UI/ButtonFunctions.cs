using ATG.Core;
using ATG.Utilities;
using UnityEngine;

namespace ATG.UI
{
    public class ButtonFunctions : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.StartGame();
        }

        public void OpenMainMenuOptions()
        {
            Debug.Log("Open Options Menu");
        }
    }
}
