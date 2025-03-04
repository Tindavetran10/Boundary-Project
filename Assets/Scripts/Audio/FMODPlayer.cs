using UnityEngine;

namespace Audio
{
    public class FMODPlayer : MonoBehaviour
    {
        // Start is called before the first frame update
        private void PlayLightAttackEvent(string path) => FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
        private void PlayMagmaStrikeEvent(string path) => FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
        private void PlayElectroNovaEvent(string path) => FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
        private void PlayCelestialTempestEvent(string path) => FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
        private void PlayFlamingDragonRoarStrikeEvent(string path) => FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
}
