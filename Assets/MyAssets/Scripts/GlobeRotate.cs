using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    public class GlobeRotate : MonoBehaviour, IInputHandler, ISourceStateHandler
    {
        [SerializeField]
        GameObject map;

        [SerializeField]
        float modifier = 5f;

        private bool isRotatingEnabled;
        private IInputSource currentInputSource;
        private uint currentInputSourceId;
        private Vector3 defaultHandPosition;
        private Vector3 newHandPosition;
        private float dot;
        
        
        void Update()
        {
            if (isRotatingEnabled) {
                UpdateRotation();
            }
        }

        public void OnInputUp(InputEventData eventData)
        {
            StopRotation();
        }

        public void OnInputDown(InputEventData eventData)
        {

            currentInputSource = eventData.InputSource;
            currentInputSourceId = eventData.SourceId;
            currentInputSource.TryGetPointerPosition(currentInputSourceId, out defaultHandPosition);
            isRotatingEnabled = true;
        }

        public void OnSourceDetected(SourceStateEventData eventData)
        {

        }

        public void OnSourceLost(SourceStateEventData eventData)
        {
            StopRotation();
        }

        void UpdateRotation()
        {
            currentInputSource.TryGetPointerPosition(currentInputSourceId, out newHandPosition);

            dot = Vector3.Dot(defaultHandPosition - newHandPosition, Camera.main.transform.right);

            map.transform.RotateAround(map.transform.position, map.transform.up, dot * modifier);

        }

        void StopRotation()
        {
            isRotatingEnabled = false;
            currentInputSource = null;
        }
    }
}
