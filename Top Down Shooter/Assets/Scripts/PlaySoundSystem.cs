using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundSystem : MonoBehaviour
{
    [SerializeField] private AudioClip sound;
    public void PlaySound()
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}
