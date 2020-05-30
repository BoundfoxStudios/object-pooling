using System;
using System.Collections.Generic;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.ObjectPooling
{
  [Serializable]
  public class ObjectPool
  {
    public bool CanExpand;

    [NonSerialized]
    public List<GameObject> Items = new List<GameObject>();

    public string Name;
    public GameObject ObjectToPool;
    public int PrewarmAmount;
  }
}
