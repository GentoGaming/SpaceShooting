using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.FG.ScriptableObjects
{
    [CreateAssetMenu(fileName = "new Pool", menuName = "Pool")]
    public class Pool : ScriptableObject
    {
        public String poolTag;
        public GameObject prefab;
        public int size;
        public List<Vector2> position;
        public Vector3 rotation;
    }
}