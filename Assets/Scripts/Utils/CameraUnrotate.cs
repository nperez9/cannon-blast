using UnityEngine;

namespace Utils { 
    public class CameraUnrotate : MonoBehaviour
    {
        private Transform transform = null;
        private Quaternion originalRotation;
        private void Awake()
        {
            transform = GetComponent<Transform>();
            originalRotation = transform.rotation;
        }

        void Update()
        {
            transform.rotation = originalRotation;
        }
    }
}
