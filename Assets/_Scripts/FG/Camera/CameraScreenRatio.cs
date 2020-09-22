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

        // Start is called before the first frame update
        void Start()
        {
            _backGroundBound = SpaceManager.Instance.blackGroundBound;
            FixCameraOrthoSize();
            CreateBlackBorders();
        }

        private void CreateBlackBorders()
        {
            GameObject border = Instantiate(blackBorderX, screenEdges.transform);
            Vector2 borderT = border.transform.position;
            float rightPosition =
                blackBorderX.GetComponent<SpriteRenderer>().bounds.size.x / 2 - _backGroundBound.min.x;
            border.transform.position = new Vector2(rightPosition, 0);

            border = Instantiate(blackBorderX, screenEdges.transform);
            float leftPosition =
                -blackBorderX.GetComponent<SpriteRenderer>().bounds.size.x / 2 + _backGroundBound.min.x;
            border.transform.position = new Vector2(leftPosition, 0);

            border = Instantiate(blackBorderY, screenEdges.transform);
            float botPosition = -blackBorderY.GetComponent<SpriteRenderer>().bounds.size.y / 2 + _backGroundBound.min.y;
            border.transform.position = new Vector2(0, botPosition);

            border = Instantiate(blackBorderY, screenEdges.transform);
            float topPosition = blackBorderY.GetComponent<SpriteRenderer>().bounds.size.y / 2 - _backGroundBound.min.y;
            border.transform.position = new Vector2(0, topPosition);
        }

        private void FixCameraOrthoSize()
        {
            UnityEngine.Camera mainCamera = SpaceManager.Instance.mainCamera;

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