using UnityEngine;

namespace Audio
{
    public class FMODPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        private void PlayMeleeEvent(string path) => FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
}
