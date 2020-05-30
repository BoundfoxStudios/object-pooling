using System;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Laser
{
  public class LaserShooter : MonoBehaviour
  {
    public float FireSpeed = 0.6f;
    public Laser LaserPrefab;
    public Transform[] StartPositions;

    private float _timeToNextFire;

    private void Start()
    {
      _timeToNextFire = Time.time;
    }

    public void Shoot()
    {
      if (Time.time > _timeToNextFire)
      {
        DoShoot();
      }
    }

    private void DoShoot()
    {
      foreach (var startTransform in StartPositions)
      {
        Instantiate(LaserPrefab, startTransform.position, Quaternion.identity);
      }
      
      _timeToNextFire = Time.time + FireSpeed;
    }
  }
}
