using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.FG.ScriptableObjects;
using UnityEngine;

namespace _Scripts.FG.Managers_Scripts
{
    public class PoolManager : MonoBehaviour
    {
        [Serializable]
        public class PoolClass
        {
            public Pool poolInfo;
        }

        public static PoolManager Instance = null;


        public List<PoolClass> bulletPolls;
        public List<PoolClass> enemyPools;


        private Dictionary<String, Queue<GameObject>> _poolDictionary;
        private IPooledObject _pooledObject;

        [NonSerialized] public int enemyPoolStartIndex;
        [NonSerialized] public int enemyPoolEndIndex;

        public GameObject bulletsGameObject;
        public GameObject enemiesGameObject;

        private Transform _parentTransform;

        void Start()
        {
            if (Instance != null) return;
            Instance = this;

            enemyPoolStartIndex = bulletPolls.Count;
            enemyPoolEndIndex = enemyPools.Count + enemyPoolStartIndex;
            _poolDictionary = new Dictionary<string, Queue<GameObject>>();

            FillInPools(bulletPolls, bulletsGameObject);
            FillInPools(enemyPools, enemiesGameObject);
        }


        private void FillInPools(List<PoolClass> pools, GameObject gameObjectPoolContainer)
        {
            foreach (PoolClass pool in pools)
            {
                Queue<GameObject> objPoolQueue = new Queue<GameObject>();
                for (int i = 0; i < pool.poolInfo.size; i++)
                {
                    if (i == 0)
                    {
                        _parentTransform = gameObjectPoolContainer.transform.Find(pool.poolInfo.poolTag);
                        if (_parentTransform == null)
                        {
                            GameObject newContainer = new GameObject(pool.poolInfo.poolTag);
                            newContainer.transform.parent = gameObjectPoolContainer.transform;
                            newContainer.transform.localPosition = Vector3.zero;
                            _parentTransform = newContainer.transform;
                        }
                    }

                    GameObject oneObj = Instantiate(pool.poolInfo.prefab, _parentTransform);
                    oneObj.SetActive(false);
                    objPoolQueue.Enqueue(oneObj);
                }

                _poolDictionary.Add(pool.poolInfo.poolTag, objPoolQueue);
            }
        }

        public string GETEnemyPoolTag(int random)
        {
            return _poolDictionary.ElementAt(random).Key;
        }

        public GameObject SpawnRandomEnemyFromPool(int randomEnemy, Vector2 enemyPosition)
        {
            return SpawnObjFromPool(GETEnemyPoolTag(randomEnemy), enemyPosition,
                enemyPools[randomEnemy - enemyPoolStartIndex].poolInfo.rotation);
        }

        public GameObject SpawnObjFromPool(string poolTag, Vector2 localPosition, Vector3 localRotation)
        {
            if (!_poolDictionary.ContainsKey(poolTag))
            {
                Debug.Log("Pool with tag " + poolTag + " doesn't exist");
                return null;
            }

            GameObject objToSpawn = _poolDictionary[poolTag].Dequeue();
            objToSpawn.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            objToSpawn.transform.localPosition = localPosition;
            objToSpawn.transform.localRotation = Quaternion.Euler(localRotation);
            _pooledObject = objToSpawn.GetComponent<IPooledObject>();
            objToSpawn.SetActive(true);
            _poolDictionary[poolTag].Enqueue(objToSpawn);
            _pooledObject?.OnObjectSpawn();

            return objToSpawn;
        }
    }
}