using UnityEngine;

namespace ATG.Core
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; set; }

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
