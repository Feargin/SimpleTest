using System;

namespace SimpleTest
{
    internal sealed class Qube : Entity
    {
        internal override void Init()
        {
            var moveSystem = GetComponent<MoveSystem>();
            var lifeLoopSystem = GetComponent<LifeLoopSystem>();
            
            moveSystem.Speed = Speed;
            lifeLoopSystem.Distance = Distance;
        }
    }
}