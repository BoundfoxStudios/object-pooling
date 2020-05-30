using BoundfoxStudios.ObjectPoolingSample.Enemy;
using UnityEngine;

namespace BoundfoxStudios.ObjectPoolingSample.UI
{
  public class StartButtonUI : MonoBehaviour
  {
    public EnemySpawner EnemySpawner;

    public void StartGame()
    {
      EnemySpawner.AllowSpawning = true;
      Destroy(gameObject);
    }
  }
}
