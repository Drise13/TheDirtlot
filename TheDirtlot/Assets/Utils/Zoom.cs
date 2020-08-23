namespace Assets.Utils
{
    using UnityEngine;

    public class Zoom : MonoBehaviour
    {
        public float fovMax;
        public float fovMin;
        private Camera myCamera;
        public float orthographicSizeMax = 10;
        public float orthographicSizeMin = 1;

        public float zoomSpeed;

        // Use this for initialization
        private void Start()
        {
            myCamera = GetComponent<Camera>();
        }

        private void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
        {
            // Calculate how much we will have to move towards the zoomTowards position
            var multiplier = 1.0f / myCamera.orthographicSize * amount;

            // Move camera
            transform.position += (zoomTowards - transform.position) * multiplier;

            // Zoom camera
            myCamera.orthographicSize -= amount;

            // Limit zoom
            myCamera.orthographicSize =
                Mathf.Clamp(myCamera.orthographicSize, orthographicSizeMin, orthographicSizeMax);
        }

        // Update is called once per frame
        private void Update()
        {
            if (Input.GetAxis("Mouse ScrollWheel") > 0 && myCamera.orthographicSize > orthographicSizeMin)
            {
                ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), 1);
            }

            // Scoll back
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && myCamera.orthographicSize < orthographicSizeMax)
            {
                ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), -1);
            }
        }
    }
}