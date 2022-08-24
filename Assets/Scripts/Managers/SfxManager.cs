using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers { 
    public class SfxManager : MonoBehaviour
    {
        [SerializeField] private AudioClip blastSFX = null;
        [SerializeField] private AudioClip destroyCannonSFX = null;
        [SerializeField] private AudioClip pauseSFX = null;
        [SerializeField] private AudioClip winSFX = null;
        [SerializeField] private AudioClip getColletableSFX = null;
        [SerializeField] private AudioClip loseSFX = null;

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

        public void blastSfx()
        {
            sfxSource.PlayOneShot(blastSFX);
        }

        public void DestroyCannonSfx()
        {
            sfxSource.PlayOneShot(destroyCannonSFX);
        }
    
        public void GetCollectableSfx()
        {
            sfxSource.PlayOneShot(getColletableSFX);
        }

        public void PauseSfx()
        {
            sfxSource.PlayOneShot(pauseSFX);
        }

        public void WinSfx()
        {
            sfxSource.PlayOneShot(winSFX);
        }

        public void LooseSfx()
        {
            sfxSource.PlayOneShot(loseSFX);
        }
    }
}