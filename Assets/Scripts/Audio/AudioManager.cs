using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance { get; private set; }

        private void Awake()
        {
            if(Instance != null)
                Debug.LogError("More than one Audio Manager in scene.");
            Instance = this;
        }
    }
}
