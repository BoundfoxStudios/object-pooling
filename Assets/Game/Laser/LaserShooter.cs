using BoundfoxStudios.ObjectPoolingSample.ObjectPooling;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Laser
{
  public class LaserShooter : MonoBehaviour
  {
    private float _timeToNextFire;
    public float FireSpeed = 0.6f;
    public string LaserName;
    public Transform[] StartPositions;

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
        var instance = ObjectPoolManager.Instance.Get(LaserName);

        if (instance)
        {
          instance.transform.position = startTransform.position;
          instance.SetActive(true);
        }
      }

      _timeToNextFire = Time.time + FireSpeed;
    }
  }
}
