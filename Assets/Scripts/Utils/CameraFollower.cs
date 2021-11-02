using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utils { 
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] Transform target = null;
        [SerializeField] private bool followX = false;
        [SerializeField] private bool followY = false;
        [SerializeField] private float speed = 1.0f;

        private Vector3 targetPostion = Vector3.zero;

        void Update()
        {
            targetPostion.x = (followX) ? target.position.x : transform.position.x;
            targetPostion.y = (followY) ? target.position.y : transform.position.y;
            targetPostion.z = transform.position.z;


            transform.position = Vector2.MoveTowards(transform.position, targetPostion, Time.deltaTime * speed);
        }
    }
}

