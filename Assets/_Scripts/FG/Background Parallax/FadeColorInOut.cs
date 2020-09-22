using UnityEngine;

namespace _Scripts.FG.Background_Parallax
{
    public class FadeColorInOut : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private bool _fadeout = true;
        private float _alphaColor = 0.3f;

        public float speedOfFading = 200;

        // Start is called before the first frame update
        void Start()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_fadeout)
            {
                _alphaColor -= speedOfFading * Time.deltaTime;
                if (_alphaColor < 0.4f)
                {
                    _fadeout = !_fadeout;
                }
            }
            else
            {
                _alphaColor += speedOfFading * Time.deltaTime;
                if (_alphaColor > 0.9f)
                {
                    _fadeout = !_fadeout;
                }
            }

            _spriteRenderer.color = new Color(255, 0, 249, _alphaColor);
        }
    }
}