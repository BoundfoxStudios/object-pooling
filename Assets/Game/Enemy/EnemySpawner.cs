using BoundfoxStudios.ObjectPoolingSample.ObjectPooling;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Enemy
{
  public class EnemySpawner : MonoBehaviour
  {
    private float _nextSpawnTime;
    public bool AllowSpawning;
    public Camera Camera;
    public EnemyController EnemyPrefab;
    public Vector2 SpawnIntervalMinMax;
    public float YOffset = 0.5f;

    private void Start()
    {
      RandomizeNextSpawnTime();
    }

    private void RandomizeNextSpawnTime()
    {
      _nextSpawnTime = Time.time + Random.Range(SpawnIntervalMinMax.x, SpawnIntervalMinMax.y);
    }

    private void Update()
    {
      if (AllowSpawning && Time.time > _nextSpawnTime)
      {
        SpawnEnemy();
      }
    }

    private void SpawnEnemy()
    {
      var topLeft = Camera.ViewportToWorldPoint(new Vector3(0, 1));
      var topRight = Camera.ViewportToWorldPoint(new Vector3(1, 1));
      var randomPosition = Vector3.Lerp(topLeft, topRight, Random.value);

      var enemy = ObjectPoolManager.Instance.Get("Enemy");

      if (!enemy)
      {
        return;
      }

      enemy.transform.position = new Vector3(randomPosition.x, randomPosition.y - YOffset, 0);
      enemy.SetActive(true);
      RandomizeNextSpawnTime();
    }
  }
}
