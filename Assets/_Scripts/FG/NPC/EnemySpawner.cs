using _Scripts.FG.Managers_Scripts;
using UnityEngine;

namespace _Scripts.FG.NPC
{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance;

        public float maxSpawnRateInSeconds = 0.5f;
        public float minSpawnRateInSeconds = 0.1f;

        public bool isCreatingEnemies;
        
        
        private SpaceManager _spaceManager;
        private GameObject _oneEnemy;
        private PoolManager _poolManager;
        
        private float _previousYPosition, _randomYPosition, _spawnInSeconds, _edgeMinYPosition, _edgeMaxYPosition;
        private int _randEnemyIndex, _totalEnemies;

        private void Awake()
        {
            if (Instance != null) return;
            Instance = this;
            _previousYPosition = 0;
        }

        public void InitEnemySpawner()
        {
            _spaceManager = SpaceManager.Instance;
            _poolManager = PoolManager.Instance;
            _edgeMinYPosition = _spaceManager.BlackGroundBound.min.y;
            _edgeMaxYPosition = _spaceManager.BlackGroundBound.max.y;
            Invoke(nameof(SpawnEnemy), 0);
        }

        private void SpawnEnemy()
        {
            if (isCreatingEnemies)
            {
                _randEnemyIndex = Random.Range(_poolManager.EnemyPoolStartIndex, _poolManager.EnemyPoolEndIndex);

                int distance = 30;


                while (true)
                {
                    _randomYPosition = Random.Range(_edgeMinYPosition + 5, _edgeMaxYPosition - 5);

                    if (Mathf.Abs(_randomYPosition - _previousYPosition) > distance)
                    {
                        break;
                    }
                }

                _previousYPosition = _randomYPosition;
                _poolManager.SpawnRandomEnemyFromPool(_randEnemyIndex, new Vector2(0, _randomYPosition));
            }
            ScheduleNextEnemySpawn();
        }


        private void ScheduleNextEnemySpawn()
        {
            _spawnInSeconds = Random.Range(minSpawnRateInSeconds, maxSpawnRateInSeconds);
            Invoke(nameof(SpawnEnemy), _spawnInSeconds);
        }
    }
}