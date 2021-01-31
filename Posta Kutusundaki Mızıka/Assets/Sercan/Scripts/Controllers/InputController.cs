using UnityEngine;

namespace Sercan.Scripts.Controllers
{
    public class InputController
    {
        public float Vertical => Input.GetAxis("Vertical");
        public float Horizontal => Input.GetAxis("Horizontal");

    }
}