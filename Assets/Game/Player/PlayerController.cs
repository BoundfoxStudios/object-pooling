using BoundfoxStudios.ObjectPoolingSample.Laser;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Player
{
  [RequireComponent(typeof(Rigidbody2D))]
  public class PlayerController : MonoBehaviour
  {
    private Rigidbody2D _rigidbody;
    public Camera Camera;
    public LaserShooter LaserShooter;

    private void Start()
    {
      _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
      Move();
      Shoot();
    }

    private void Shoot()
    {
      if (Input.GetMouseButton(0))
      {
        LaserShooter.Shoot();
      }
    }

    private void Move()
    {
      var mousePosition = Camera.ScreenToWorldPoint(Input.mousePosition);

      _rigidbody.MovePosition(new Vector2(mousePosition.x, _rigidbody.position.y));
    }
  }
}
