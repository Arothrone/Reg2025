using UnityEngine;

public class PlaySoundThisSource : MonoBehaviour
{
    [SerializeField] AudioClip pickupSoundClip;

    public void PlaySound()
    {
        if (pickupSoundClip != null)
        {
            AudioSource.PlayClipAtPoint(pickupSoundClip, Camera.main.transform.position);
        }
    }
}
