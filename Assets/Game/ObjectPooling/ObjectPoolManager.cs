using System.Collections;
using System.Linq;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.ObjectPooling
{
  public class ObjectPoolManager : MonoBehaviour
  {
    public static ObjectPoolManager Instance;
    public ObjectPool[] Pools;

    private void Start()
    {
      Instance = this;

      StartCoroutine(PrewarmObjects());
    }

    private IEnumerator PrewarmObjects()
    {
      Debug.Log("Prewarming Object pools...");

      foreach (var pool in Pools)
      {
        Debug.Log($"Prewarming pool {pool.Name}");

        for (var i = 0; i < pool.PrewarmAmount; i++)
        {
          CreateInstanceAndAddToPool(pool);

          yield return null;
        }
      }

      Debug.Log("Prewarming done.");
    }

    private GameObject CreateInstanceAndAddToPool(ObjectPool pool)
    {
      var instance = Instantiate(pool.ObjectToPool);
      instance.SetActive(false);

      pool.Items.Add(instance);

      return instance;
    }

    public GameObject Get(string name)
    {
      var pool = Pools.FirstOrDefault(p => p.Name == name);

      if (pool == null)
      {
        Debug.LogError($"Object pool for ${name} not found!");

        return null;
      }

      var item = pool.Items.FirstOrDefault(i => !i.activeInHierarchy);

      if (item)
      {
        return item;
      }

      if (!pool.CanExpand)
      {
        return null;
      }

      return CreateInstanceAndAddToPool(pool);
    }
  }
}
