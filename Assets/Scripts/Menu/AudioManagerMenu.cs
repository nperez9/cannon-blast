using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Menu { 
    public class SfxManager : MonoBehaviour
    {
        private AudioSource musicSource = null;
        [SerializeField] private AudioClip music = null;
        [SerializeField] private AudioClip[] clips = null;

        private void Awake()
        {
            musicSource = GetComponent<AudioSource>();
            PlaySound(clips[Random.Range(0, clips.Length)], 2f);
            PlaySound(clips[Random.Range(0, clips.Length)]);
        }

        public void PlaySound(AudioClip clip, float volume = 1f)
        {
            //Reproduce un audioclip con el volumen indicado (opcional, sino usa 1f)
        }
    }
}
