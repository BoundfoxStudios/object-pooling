using BoundfoxStudios.ObjectPoolingSample.Enemy;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Laser
{
  public class Laser : MonoBehaviour
  {
    private float _bottomY;
    public string CollisionTag;
    public GameObject HitEffectPrefab;
    public float Speed;
    private bool ReachedBottom => transform.position.y < _bottomY;

    private void Start()
    {
      _bottomY = FindObjectOfType<Camera>().ViewportToWorldPoint(new Vector3(0, -0.1f)).y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
      if (other.CompareTag(CollisionTag))
      {
        gameObject.SetActive(false);

        var effectInstance = Instantiate(HitEffectPrefab, transform.position, Quaternion.identity);

        Destroy(effectInstance.gameObject, 0.2f);

        // Don't destroy the player for this demo :-)

        if (other.GetComponent<EnemyController>())
        {
          other.gameObject.SetActive(false);
        }
      }
    }

    private void Update()
    {
      var newPosition = transform.position + Vector3.up * Speed * Time.deltaTime;

      transform.position = newPosition;

      if (ReachedBottom)
      {
        gameObject.SetActive(false);
      }
    }
  }
}
