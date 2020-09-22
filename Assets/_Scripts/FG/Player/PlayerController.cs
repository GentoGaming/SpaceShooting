using _Scripts.FG.Managers_Scripts;
using UnityEngine;

namespace _Scripts.FG.Player
{
    public class PlayerController : MonoBehaviour
    {
        public int speed = 7;
        public Vector4 spaceShipOffset;
        public float spaceShipYOffset = 6f;
        public float spaceShipXOffset = 25f;
        private Vector3 _playerNextPosition;
        private Vector3 _position;
        private SpaceManager _spaceManager;
        public Vector2 Movement { get; set; }


        void Start()
        {
            _spaceManager = SpaceManager.Instance;
        }


        // Update is called once per frame
        void FixedUpdate()
        {
            Thrust(Movement.x, Movement.y);
        }


        private void Thrust(float hor, float ver)
        {
            _playerNextPosition = new Vector3(hor, ver) * speed * 10 * Time.deltaTime;

            _position = transform.position;

            if (hor < 0 && (_position.x + _playerNextPosition.x < (float) SpaceManager.Edges.Left))
            {
                hor = 0;
            }

            if (hor > 0 && (_position.x + _playerNextPosition.x > (float) SpaceManager.Edges.Right))
            {
                hor = 0;
            }

            if (ver > 0 && (_position.y + _playerNextPosition.y > (float) SpaceManager.Edges.Top))
            {
                ver = 0;
            }

            if (ver < 0 && (_position.y + _playerNextPosition.y < (float) SpaceManager.Edges.Bottom))
            {
                ver = 0;
            }


            _playerNextPosition = new Vector3(hor, ver) * speed * 10 * Time.deltaTime;
            transform.position += _playerNextPosition;
        }
    }
}