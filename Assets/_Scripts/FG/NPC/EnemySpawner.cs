using _Scripts.FG.Managers_Scripts;
using UnityEngine;

namespace _Scripts.FG.NPC
{
    public class EnemySpawner : MonoBehaviour
    {
        public static EnemySpawner Instance = null;

        public float maxSpawnRateInSeconds = 0.5f;
        public float minSpawnRateInSeconds = 0.1f;

        public bool stopEnemySpawn;
        private int _counter = 0;

        private float _edgeMaxYPosition;

        // public GameObject enemiesContainer;
        private float _edgeMinYPosition;
        private GameObject _oneEnemy;
        private PoolManager _poolManager;
        private float _previousYPosition;
        private int _randEnemyIndex;
        private float _randomYPosition;
        private SpaceManager _spaceManager;
        private float _spawnInSeconds;
        private int _totalEnemies;

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
            _edgeMinYPosition = _spaceManager.blackGroundBound.min.y;
            _edgeMaxYPosition = _spaceManager.blackGroundBound.max.y;
            Invoke(nameof(SpawnEnemy), 0);
        }

        private void SpawnEnemy()
        {
            _randEnemyIndex = Random.Range(_poolManager.enemyPoolStartIndex, _poolManager.enemyPoolEndIndex);

            int distance = 30;


            while (true)
            {
                _randomYPosition = Random.Range(_edgeMinYPosition + 5, _edgeMaxYPosition - 5);

                if (Mathf.Abs(_randomYPosition - _previousYPosition) > distance)
                {
                    break;
                }
            }

            _counter++;

            _previousYPosition = _randomYPosition;

            _oneEnemy = _poolManager.SpawnRandomEnemyFromPool(_randEnemyIndex, new Vector2(0, _randomYPosition));
            //  _oneEnemy.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2000, 0));

            ScheduleNextEnemySpawn();
        }


        private void ScheduleNextEnemySpawn()
        {
            _spawnInSeconds = Random.Range(minSpawnRateInSeconds, maxSpawnRateInSeconds);
            Invoke(nameof(SpawnEnemy), _spawnInSeconds);
        }
    }
}