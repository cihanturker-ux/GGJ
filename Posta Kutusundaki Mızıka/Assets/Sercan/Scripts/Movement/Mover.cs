using UnityEngine;

namespace Sercan.Scripts.Movement
{
    public class Mover
    {
        private Rigidbody _rb;
        private Transform _transform;

        public Mover(Rigidbody rigidbody,Transform transform)
        {
            _rb = rigidbody;
            _transform = transform;
        }

        public void Move(float vertical,float horizontal,float speed)
        {
            _rb.velocity = ((_transform.forward*vertical) + (_transform.right*horizontal)) * speed* Time.fixedDeltaTime;
        }

        
    }
}