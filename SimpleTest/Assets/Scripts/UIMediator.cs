using TMPro;
using UnityEngine;

namespace SimpleTest
{
    internal sealed class UIMediator : MonoBehaviour
    {
        //TODO ленивое решение без использования Zenject
        [SerializeField]
        private TMP_InputField Speed;
        [SerializeField]
        private TMP_InputField Distance;
        [SerializeField]
        private TMP_InputField SpawnDelay;
        [SerializeField]
        private Spawner Spawer;
      

        private void Update()
        {
            if(string.IsNullOrEmpty(Speed.text) || Speed.text == "-"
               || string.IsNullOrEmpty(Distance.text) || Distance.text == "-"
               || string.IsNullOrEmpty(SpawnDelay.text) || SpawnDelay.text == "-")
                return;
            
            var speed = int.Parse(Speed.text);
            if (speed >= 0 && speed <= 100)
                Spawer.Speed = speed;
            else
                Speed.text = "0";
         
            var distance = int.Parse(Distance.text);
            if (distance > 0 && distance <= 500)
                Spawer.Distance = distance;
            else
                Distance.text = "0";
         
            var delay = int.Parse(SpawnDelay.text);
            if (delay > 0 && delay <= 10)
                Spawer.TimeSpawnDelay = delay;
            else
                SpawnDelay.text = "0";
        }
    }
}