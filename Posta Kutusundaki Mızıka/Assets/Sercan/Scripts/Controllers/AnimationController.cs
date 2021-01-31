using UnityEngine;

namespace Sercan.Scripts
{
    public class AnimationController
    {
        private Animator anim;

        public AnimationController(Animator animator)
        {
            anim = animator;
        }

        public void IdleToWalk(float v)
        {
            anim.SetFloat("Speed",v); 
        }

    }
}