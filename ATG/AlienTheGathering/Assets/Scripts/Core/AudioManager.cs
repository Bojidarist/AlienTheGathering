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

        public void LoadSound(ref AudioSource src, string resourcesPath, bool isLoop = false, bool playOnAwake = false, bool addComponent = true)
        {
            if (addComponent)
            {
                src = gameObject.AddComponent<AudioSource>();
            }
            src.clip = Resources.Load<AudioClip>(resourcesPath);
            src.loop = isLoop;
            src.playOnAwake = playOnAwake;
        }
    }
}
