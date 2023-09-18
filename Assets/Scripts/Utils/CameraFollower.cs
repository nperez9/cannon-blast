using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Utils { 
    public class CameraFollower : MonoBehaviour
    {
        [SerializeField] private Transform target = null;
        [SerializeField] private bool followX = false;
        [SerializeField] private bool followY = false;

        private float speed = 8f;
        private Vector2 targetPostion = Vector2.zero;

        private void Start()
        {
            targetPostion = transform.position;
        }

        void Update()
        {
            targetPostion.x = (followX) ? target.position.x : targetPostion.x;
            targetPostion.y = (followY) ? target.position.y : transform.position.y;

            transform.position = Vector2.Lerp(transform.position, targetPostion, Time.deltaTime * speed);
        }
    }
}

/** 
 * <iframe frameborder="0" src="https://itch.io/embed/1474485?linkback=true&amp;border_width=0&amp;bg_color=000000&amp;fg_color=ffffff&amp;link_color=f43a3a&amp;border_color=000000" width="550" height="165"><a href="https://nperez9.itch.io/super-cannon-blast">Super Cannon blast! by Nicolas Agustin</a></iframe>
 * 
 * **/