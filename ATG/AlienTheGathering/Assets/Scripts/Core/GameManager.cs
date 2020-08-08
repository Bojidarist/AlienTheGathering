using UnityEngine;

namespace ATG.Core
{
    public class GameManager : MonoBehaviour
    {
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
        }
    }
}
