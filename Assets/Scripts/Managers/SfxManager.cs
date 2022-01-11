using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers { 
    public class SfxManager : MonoBehaviour
    {
        private AudioSource sfxSource = null;

        private void Awake()
        {
            sfxSource = GetComponent<AudioSource>();
        }

        public void PlaySound(AudioClip clip, float volume = 1f)
        {
            try
            {
                sfxSource.PlayOneShot(clip, volume);
            }
            catch
            {
                Debug.LogError("error loading SFX: " + clip.name);
            }
        }
    }
}