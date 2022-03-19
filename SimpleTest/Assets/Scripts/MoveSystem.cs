using UnityEngine;

namespace SimpleTest
{
    [RequireComponent(typeof(Rigidbody))]
    internal sealed class MoveSystem : MonoBehaviour
    {
        internal float Speed { get; set; }
        
        private Rigidbody rigibody;

        private void Awake()
        {
            rigibody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            rigibody.MovePosition(transform.position + Vector3.right * (Speed * Time.smoothDeltaTime));
        }
    }
}