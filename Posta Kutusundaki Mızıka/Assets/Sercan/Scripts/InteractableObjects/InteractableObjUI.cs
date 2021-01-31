using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sercan.Scripts
{
    public class InteractableObjUI : MonoBehaviour
    {
        [SerializeField] private GameObject interactObjectCanvas;
        [SerializeField] private TextMeshProUGUI objectText;
        
        public bool InteractObjCanvas => interactObjectCanvas.activeSelf;
        public void InteractableObjectCanvas(bool isActive)
        {
            interactObjectCanvas.SetActive(isActive);
        }

        public void ObjectText(string text)
        {
            objectText.text = text;
        }
    }
}