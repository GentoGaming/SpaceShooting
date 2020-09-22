using System;
using _Scripts.FG.Managers_Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace FG.Background_Parallax
{
    public class BackgroundEffects : MonoBehaviour
    {
    
        private SpriteRenderer _spriteRenderer;
        private float _rotationSpeed;

        [Header("________________________________________________________________________________")] [Space(10)]
        public bool colorSettings;
        public Color[] colors;
        [Header("________________________________________________________________________________")]
        public bool sizeSettings;
        [Range(1.0f, 10.0f)] public float multiplierMax = 3f;
        private Vector2 _initialScale;
        [Header("________________________________________________________________________________")]
        public bool rotationSettings;
        public float rotationSpeedMin = 3f;
        public float rotationSpeedMax = 35f;
        public bool randomize = true;
        [Header("________________________________________________________________________________")]
        public bool spriteSettings;
        public Sprite[] sprites;

        [Header("________________________________________________________________________________")]
        public bool movementSettings;

        private Transform _transform;
        private Vector2 _transformPos;

        public float minSpeed = 0.2f;
        public float maxSpeed = 0.6f;
        private float _speed;
        private float _startPos;
        private float _finalPos;

        public bool regenerate;

        [Header("________________________________________________________________________________")]
        private float _backgroundSpeed;  
        
        private void SwapMinMax(ref float min ,ref float max)
        {
            if (max < min)
            {
                float tempValue = min;
                min = max;
                max = tempValue;
            }
        }
        
        private void InitializeMovement()
        {
            if (!movementSettings) return;
            _speed = Random.Range(minSpeed, maxSpeed);
        }


        private void ReGenerate()
        {
            ChangeSize();
            ChangeRotation();
            ChangeColor();
            ChangeSprite();
            InitializeMovement();
        }
    
        private void Start()
        {
            _transform = transform;
            _transformPos = _transform.position;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _initialScale = _transform.localScale;
            SwapMinMax(ref minSpeed, ref maxSpeed);
            SwapMinMax(ref rotationSpeedMin, ref rotationSpeedMax);
            InitializeBoundries();
            ReGenerate();
        }

        private void InitializeBoundries()
        {
            Bounds bounds = SpaceManager.Instance.blackGroundBound;
            _startPos = bounds.max.x + 50;
            _finalPos = bounds.min.x - 50;
        }

        private void ChangeSprite()
        {
            if(spriteSettings && sprites.Length > 0){
                _spriteRenderer.sprite = sprites[Random.Range(0, sprites.Length)];
            }
        }

        private void ChangeRotation()
        {
            if (rotationSettings)
            {
                if (randomize)
                {
                    _rotationSpeed = Random.Range(rotationSpeedMin, rotationSpeedMax);
                }
                else
                {
                    _rotationSpeed = rotationSpeedMax;
                }
            }
        }

        private void ChangeSize()
        {
            if (sizeSettings)
            {
                transform.localScale = _initialScale * Random.Range(1, multiplierMax);
            }
        }

        private void ChangeColor()
        {
            if (colorSettings && colors.Length > 0)
            {
                _spriteRenderer.color = colors[Random.Range(0, colors.Length)];
            }
        }
    

        private void Update()
        {
            UpdateBackgroundSpeed();
            
            if (rotationSettings)
            {
                transform.Rotate(0f, 0f, _backgroundSpeed * _rotationSpeed * Time.deltaTime);
            }

            if (movementSettings)
            {
                _transformPos = transform.position;
                
                if (transform.position.x < _finalPos && regenerate)
                {
                    transform.position = new Vector2(_startPos, _transformPos.y);
                    ReGenerate();
                }
            
                transform.Translate( -_backgroundSpeed  *_speed * Time.deltaTime,0,0, Space.World );
            }
        }

        private void OnBecameInvisible()
        {
            if(!regenerate) gameObject.SetActive(false);
        }

        private void UpdateBackgroundSpeed()
        {
            if (rotationSettings || movementSettings)
            {
                _backgroundSpeed = SpaceManager.Instance.gameBackgroundSpeed;
            }
        }
    }
}