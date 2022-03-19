using System.Collections;
using UnityEngine;

namespace SimpleTest
{
    internal sealed class LifeLoopSystem : MonoBehaviour
    {
        internal float Distance { get; set; }

        private float startPosition;

        private void Start()
        {
            startPosition = transform.position.x;
            StartCoroutine(FindTargetPoint());
        }

        private IEnumerator FindTargetPoint()
        {
            while (true)
            {
                if(transform.position.x >= startPosition + Distance)
                    Destroy(gameObject, 0.001f);
                
                yield return new WaitForFixedUpdate();
            }
        }
    }
}