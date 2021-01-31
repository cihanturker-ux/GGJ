using System;
using System.Collections;
using UnityEngine;

namespace Sercan.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public GameObject startPanel, finalPanel, creditsPanel;
        private SoundManager sound;
        private void Start()
        {
            StartCoroutine(StartP());
            sound = FindObjectOfType<SoundManager>();
        }


        IEnumerator StartP()
        {
            PlayerController playerController = FindObjectOfType<PlayerController>();
            playerController.enabled = false;
            startPanel.SetActive(true);
            
            yield return new WaitForSeconds(3);
            
            playerController.enabled = true;
            startPanel.SetActive(false);
        }

        public void FinalPanel()
        {
            finalPanel.SetActive(true);
            StartCoroutine(FinalMusic());
            StartCoroutine(CreditsPanel());
        }

        IEnumerator FinalMusic()
        {
            yield return new WaitForSeconds(14);
            sound.ClipPlay(1);
        }

        IEnumerator CreditsPanel()
        {
            yield return new WaitForSeconds(30);
        }
    }
}