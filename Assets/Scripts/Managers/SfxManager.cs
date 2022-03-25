using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers { 
    public class SfxManager : MonoBehaviour
    {
        [SerializeField] private AudioClip blastSound = null;
        [SerializeField] private AudioClip destroyCannonSound = null;
        [SerializeField] private AudioClip pauseSound = null;
        [SerializeField] private AudioClip winSound = null;
        [SerializeField] private AudioClip grabItem = null;

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