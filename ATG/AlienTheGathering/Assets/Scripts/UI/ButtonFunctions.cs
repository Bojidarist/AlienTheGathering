using ATG.Core;
using ATG.Utilities;
using UnityEngine;

namespace ATG.UI
{
    public class ButtonFunctions : MonoBehaviour
    {
        public void StartGame()
        {
            GameManager.Instance.SceneChanger.Change(SceneNames.CowLevel);
        }

        public void OpenMainMenuOptions()
        {
            Debug.Log("Open Options Menu");
        }
    }
}
