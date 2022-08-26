using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prefabs { 
    public class Cannon : MonoBehaviour
    {
        [SerializeField] float speedX = 1.0f;
        [SerializeField] float speedY = 1.0f;
        [SerializeField] float speed = 1.0f;

        [SerializeField] float force = 1.0f;

        [SerializeField] bool moveInX = false;
        [SerializeField] bool moveInY = false;
        [SerializeField] bool isStatic = false;

        [SerializeField] int dirX = 1;
        [SerializeField] int dirY = 1;

        [SerializeField] Vector2 moveFrom = new Vector2(0, 0);
        [SerializeField] Vector2 moveTo = new Vector2(0, 0);
        [SerializeField] Transform firePoint = null;
        [SerializeField] Transform shotPoint = null;

        [SerializeField] bool isRotate = false;
        [SerializeField] float rotateSpeed = 200.0f;
        [SerializeField] int rotateDirection = 1;
        [SerializeField] float fromRotation = 0;
        [SerializeField] float toRotation = 370;
        [SerializeField] SpriteRenderer topCannon = null;

        CannonManager cannonManager = null;
        BoxCollider2D boxCollider = null;
        Animator animator = null;

        public float getForce()
        {
            return force;
        }

        /**
         * Returns the direction where the bullet is gonna be fired.
         * it's in base of the Shotpoint GO position
         */
        public Vector2 getShotDirection()
        {
            // TODO: mmabye add an opposite fire cannon (the inverted cannon)
            Vector2 newDir = shotPoint.position - firePoint.position;
            return newDir.normalized;
        }

        public Transform getFirePoint()
        {
            return firePoint;
        }

        public void SetCannonManager(CannonManager cm)
        {
            cannonManager = cm;
        }

        public void Explode() 
        {
            boxCollider.enabled = false;
            isStatic = true;
            animator.SetBool("explote", true);
        }

        private void Awake()
        {
            boxCollider = GetComponent<BoxCollider2D>();
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if (isStatic)
            {
                return;
            }

            MoveCannon();

            if (isRotate)
            {
                RotateCannon();
            }
        }

        private void RotateCannon()
        {
            float newRotation = transform.rotation.eulerAngles.z;
            newRotation = newRotation + (rotateSpeed * Time.deltaTime) * rotateDirection;

            if (newRotation > toRotation)
            {
                newRotation = toRotation;
                rotateDirection = -1;
            } 
            else if (newRotation < fromRotation)
            {
                newRotation = fromRotation;
                rotateDirection = 1;
            }

            Quaternion targetPositon = Quaternion.Euler(transform.rotation.x, transform.rotation.y, newRotation);
            transform.rotation = targetPositon;
        }

        private void MoveCannon()
        {
            Vector3 nextMovement = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            
            if (moveInX)
            {
                nextMovement.x = MoveInX(moveFrom.x, moveTo.x);
            }
            if (moveInY)
            {
                nextMovement.y = MoveInY(moveFrom.y, moveTo.y);
            }

            transform.position = Vector3.MoveTowards(transform.position, nextMovement, speed * Time.deltaTime);
        }

        /**
         * Moves the cannon in X
         */
        private float MoveInX(float from, float to)
        {
            float deltaSpeed = speedX * Time.deltaTime * dirX;
            float nextPosition = transform.position.x + deltaSpeed;

            if (nextPosition >= to)
            {
                dirX = -1;
                nextPosition = to - 0.1f;
            }
            else if (nextPosition <= from)
            {
                dirX = 1;
                nextPosition = from + 0.1f;
            }

            return nextPosition;
        }

        /** 
         * Moves cannon in Y
         */
        private float MoveInY(float from, float to)
        {
            float deltaSpeed = speedY * Time.deltaTime * dirY;
            float nextPosition = transform.position.y + deltaSpeed;

            if (nextPosition >= to)
            {
                dirY = -1;
                nextPosition = to - 0.1f;
            }
            else if (nextPosition <= from)
            {
                dirY = 1;
                nextPosition = from + 0.1f;
            }

            return nextPosition;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            cannonManager.CannonCollision(collision, this);
        }
    }
}
