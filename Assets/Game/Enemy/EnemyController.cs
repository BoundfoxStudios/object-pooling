using BoundfoxStudios.ObjectPoolingSample.Laser;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Enemy
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class EnemyController : MonoBehaviour
  {
    private float _bottomY;

    private Rigidbody2D _rigidbody;
    public LaserShooter LaserShooter;
    public float Speed = 1.2f;

    private bool ReachedBottom => transform.position.y < _bottomY;

    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
      _bottomY = FindObjectOfType<Camera>().ViewportToWorldPoint(new Vector3(0, -0.1f)).y;
    }

    private void Update()
    {
      MoveTowardsBottom();
      LaserShooter.Shoot();

      if (ReachedBottom)
      {
        gameObject.SetActive(false);
      }
    }

    private void MoveTowardsBottom()
    {
      var newPosition = _rigidbody.position + Vector2.down * Speed * Time.deltaTime;

      _rigidbody.MovePosition(newPosition);
    }
  }
}
