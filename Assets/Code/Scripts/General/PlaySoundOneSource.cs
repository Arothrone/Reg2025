using UnityEngine;

public class PlaySoundOneSource : MonoBehaviour
{
    public AudioSource sound;
    public void PlaySound()
    {
        

        if (sound != null && sound.clip != null)
        {
            
            sound.PlayOneShot(sound.clip);
        }
    }
}
