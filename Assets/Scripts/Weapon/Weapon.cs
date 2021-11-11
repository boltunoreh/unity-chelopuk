using Person;
using UnityEngine;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        public float aimOffsetZ;

        public GameObject shortWeb;

        public GameObject longWeb;

        public Transform shotDirection;

        public float delay;

        private float _timeShot;

        // Update is called once per frame
        void Update()
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + aimOffsetZ);
            Quaternion webRotation = Quaternion.Euler(0f, 0f, rotateZ);

            //Length of the ray
            float laserLength = 50f;
        
            int layerMask = LayerMask.GetMask("Enemies", "Ground");

            //Get the first object hit by the ray
            RaycastHit2D hit = Physics2D.Raycast(transform.position, difference, laserLength, layerMask);

            ShotOnLeftClick(webRotation, hit);

            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(transform.position, difference, Color.red);
        }

        private void ShotOnLeftClick(Quaternion webRotation, RaycastHit2D hit)
        {
            if (_timeShot <= 0 && Input.GetMouseButtonDown(0))
            {
                GameObject web = Instantiate(shortWeb, shotDirection.position, webRotation);
                _timeShot = delay;

                if (hit.collider != null)
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();

                    if (enemy != null)
                    {
                        enemy.TakeDamage(1);
                        Debug.Log(enemy.name + ": " + enemy.health + " hp left");
                    }
                }
            }
            else
            {
                _timeShot -= Time.deltaTime;
            }
        }
    }
}
