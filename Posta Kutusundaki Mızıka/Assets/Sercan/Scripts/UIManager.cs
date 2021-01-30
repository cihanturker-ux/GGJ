using UnityEngine;

namespace Sercan.Scripts
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject interactObjectCanvas;

        public void InteractableObjectCanvas(bool isActive)
        {
            interactObjectCanvas.SetActive(isActive);
        }
    }
}