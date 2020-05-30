using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.Enemy
{
  public class EnemySpawner : MonoBehaviour
  {
    public Vector2 SpawnIntervalMinMax;
    public EnemyController EnemyPrefab;
    public Camera Camera;
    public float YOffset = 0.5f;
    public bool AllowSpawning;

    private float _nextSpawnTime;

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

      Instantiate(EnemyPrefab, new Vector3(randomPosition.x, randomPosition.y - YOffset, 0), Quaternion.identity);
      
      RandomizeNextSpawnTime();
    }
  }
}
