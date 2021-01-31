using System;
using UnityEngine;

namespace Sercan.Scripts.Managers
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioClip[] clips;
        
        private AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void ClipPlay(int index)
        {
            audioSource.clip = clips[index];
            audioSource.Play();
        }

        
    }
}