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


            transform.position = Vector2.MoveTowards(transform.position, targetPostion + offset, Time.deltaTime * speed * 100);
        }
    }
}

/** 
 * <iframe frameborder="0" src="https://itch.io/embed/1474485?linkback=true&amp;border_width=0&amp;bg_color=000000&amp;fg_color=ffffff&amp;link_color=f43a3a&amp;border_color=000000" width="550" height="165"><a href="https://nperez9.itch.io/super-cannon-blast">Super Cannon blast! by Nicolas Agustin</a></iframe>
 * 
 * **/