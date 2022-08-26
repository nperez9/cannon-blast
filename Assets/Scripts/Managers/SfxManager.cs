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

        private void PlaySound(AudioClip clip, float volume = 1f)
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
            PlaySound(blastSFX, 0.8f);
        }

        public void DestroyCannonSfx()
        {
            PlaySound(destroyCannonSFX, 0.4f);
        }
    
        public void GetCollectableSfx()
        {
            PlaySound(getColletableSFX, 1.2f);
        }

        public void PauseSfx()
        {
            PlaySound(pauseSFX, 0.8f);
        }

        public void WinSfx()
        {
            PlaySound(winSFX, 0.7f);
        }

        public void LooseSfx()
        {
            PlaySound(loseSFX, 2f);
        }
    }
}