using BoundfoxStudios.ObjectPoolingSample.Enemy;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Laser
{
  public class Laser : MonoBehaviour
  {
    public GameObject HitEffectPrefab;
    public float Speed;
    public string CollisionTag;
    
    private float _bottomY;
    private bool ReachedBottom => transform.position.y < _bottomY;

    private void Start()
    {
      _bottomY = FindObjectOfType<Camera>().ViewportToWorldPoint(new Vector3(0, -0.1f)).y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag(CollisionTag))
      {
        Destroy(gameObject);

        var effectInstance = Instantiate(HitEffectPrefab, transform.position, Quaternion.identity);

        Destroy(effectInstance.gameObject, 0.2f);

        // Don't destroy the player for this demo :-)
        
        if (other.GetComponent<EnemyController>())
        {
          Destroy(other.gameObject);
        }
      }
    }

    private void Update()
    {
      var newPosition = transform.position + Vector3.up * Speed * Time.deltaTime;

      transform.position = newPosition;
      
      if (ReachedBottom)
      {
        Destroy(gameObject);
      }
    }
  }
}
