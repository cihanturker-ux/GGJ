using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
namespace Sercan.Scripts.Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject panel;
        [SerializeField] private Image cursor; 
        [SerializeField] private Sprite büyüteç;
        
        public GameObject fadePanel;
        public Text dialogueText;

        public void DialoguePanel(bool isActive, string text)
        {
            panel.SetActive(isActive);
            dialogueText.text = text;
        }

        public void CursorChanger(bool b)
        {
            if (b)
            {
                cursor.sprite = büyüteç;
                cursor.rectTransform.localScale = Vector3.one*10;
            }
            else
            {
                cursor.sprite = null;
                cursor.rectTransform.localScale = Vector3.one;
            }
        }
        
        
    }
}