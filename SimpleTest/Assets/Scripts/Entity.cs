using System;
using UnityEngine;

namespace SimpleTest
{
    internal abstract class Entity : MonoBehaviour
    {
        internal float Speed { get; set; }
        internal float Distance { get; set; }

        private void Start()
        {
            Init();
        }

        internal abstract void Init();
    }
}