using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utils { 
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private bool followX = false;
        [SerializeField] private bool followY = false;
        [SerializeField] private float speed = 1.0f;
        [SerializeField] private float offsetX = 0f;
        [SerializeField] private float offsetY = 0f;
        [SerializeField] private Vector2 offset = Vector2.zero;

        private Vector2 targetPostion = Vector2.zero;

        void Update()
        {
            targetPostion.x = (followX) ? target.position.x : transform.position.x;
            targetPostion.y = (followY) ? target.position.y : transform.position.y;


            transform.position = Vector2.MoveTowards(transform.position, targetPostion + offset, Time.deltaTime * 100);
        }
    }
}

