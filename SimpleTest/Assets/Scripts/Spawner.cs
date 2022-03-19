using System;
using System.Collections;
using UnityEngine;

namespace SimpleTest
{
   internal abstract class Spawner : MonoBehaviour
   {
      internal static Action<Entity> OnSpawn { get; private set; }
      
      [SerializeField]
      protected Entity spawnPrefab;
      
      internal float Speed { get; set; }
      
      internal float TimeSpawnDelay { get; set; }
      
      internal float Distance { get; set; }

      internal virtual void StartSpawner(Entity prefab = null)
      {
         var spawnPref = prefab ?? spawnPrefab;
         StartCoroutine(SpawnPrefab(spawnPref));
      }
      
      internal virtual void StopSpawner() => StopCoroutine(SpawnPrefab(null));

      protected IEnumerator SpawnPrefab(Entity spawnPref)
      {
         while (true)
         {
            if (TimeSpawnDelay > 0 && Speed > 0)
            {
               var ent = Instantiate(spawnPref, transform.position, Quaternion.identity, transform);
            
               Configuration(ent);
               OnSpawn?.Invoke(ent);
            }
            
            yield return new WaitForSeconds(TimeSpawnDelay);
         }
      }

      protected abstract void Configuration(Entity ent);
   }
}
