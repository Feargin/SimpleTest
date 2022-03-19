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

      [SerializeField, Range(0.5f, 100f)]
      protected float speed;

      [SerializeField, Min(0.05f)] 
      protected float timeSpawnDelay;

      [SerializeField, Min(1)]
      protected float distance;

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
            yield return new WaitForSeconds(timeSpawnDelay);
            var ent = Instantiate(spawnPref, transform.position, Quaternion.identity, transform);
            
            Configuration(ent);
            OnSpawn?.Invoke(ent);
         }
      }

      protected abstract void Configuration(Entity ent);
   }
}
