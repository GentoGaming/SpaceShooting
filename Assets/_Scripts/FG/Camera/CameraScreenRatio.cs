using _Scripts.FG.Managers_Scripts;
using UnityEngine;

namespace _Scripts.FG.Camera
{
    public class CameraScreenRatio : MonoBehaviour
    {
        public GameObject blackBorderX;
        public GameObject blackBorderY;
        public GameObject screenEdges;
        private Bounds _backGroundBound;

        private SpriteRenderer _spriteRendererX;

        private SpriteRenderer _spriteRendererY;
        // Start is called before the first frame update
        void Start()
        {
            _backGroundBound = SpaceManager.Instance.BlackGroundBound;
            _spriteRendererX = blackBorderX.GetComponent<SpriteRenderer>();
            _spriteRendererY = blackBorderX.GetComponent<SpriteRenderer>();
            FixCameraOrthoSize();
            CreateBlackBorders();
        }

        private void CreateBlackBorders()
        {
            GameObject border = Instantiate(blackBorderX, screenEdges.transform);

            float rightPosition =
                _spriteRendererX.bounds.size.x / 2 - _backGroundBound.min.x;
            border.transform.position = new Vector2(rightPosition, 0);

            border = Instantiate(blackBorderX, screenEdges.transform);
            float leftPosition =
                -_spriteRendererX.bounds.size.x / 2 + _backGroundBound.min.x;
            border.transform.position = new Vector2(leftPosition, 0);

            
            
            border = Instantiate(blackBorderY, screenEdges.transform);
            
            float botPosition = -_spriteRendererY.bounds.size.y / 2 + _backGroundBound.min.y;
            border.transform.position = new Vector2(0, botPosition);

            border = Instantiate(blackBorderY, screenEdges.transform);
            float topPosition = _spriteRendererY.bounds.size.y / 2 - _backGroundBound.min.y;
            border.transform.position = new Vector2(0, topPosition);
        }

        private void FixCameraOrthoSize()
        {
            UnityEngine.Camera mainCamera = GetComponent<UnityEngine.Camera>();

            float screenRatio = (float) Screen.width / Screen.height;
            float targetRatio = _backGroundBound.size.x / _backGroundBound.size.y;

            if (screenRatio >= targetRatio)
            {
                mainCamera.orthographicSize = _backGroundBound.size.y / 2;
            }
            else
            {
                float differenceInSize = targetRatio / screenRatio;
                mainCamera.orthographicSize = _backGroundBound.size.y / 2 * differenceInSize;
            }
        }
    }
}