using System;
using Person;
using UnityEngine;

namespace Weapon
{
    public class Weapon : MonoBehaviour
    {
        public float aimOffsetZ;

        public GameObject ammo;

        public Transform shotDirection;

        public float delay;

        private IShotLogic _shotLogic;

        private float _timeShot;

        private AudioSource _shotAudio;

        public Weapon()
        {
            // _shotLogic = new RaycastShotLogic();
            _shotLogic = new CollideShotLogic();
        }

        private void Start()
        {
            _shotAudio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            var position = transform.position;

            var difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - position;
            var rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + aimOffsetZ);

            ShotOnLeftClick(position, difference);

            //Method to draw the ray in scene for debug purpose
            Debug.DrawRay(position, difference, Color.red);
        }

        private void ShotOnLeftClick(Vector3 position, Vector3 difference)
        {
            if (_timeShot <= 0 && Input.GetMouseButtonDown(0))
            {
                _timeShot = delay;

                _shotAudio.PlayOneShot(_shotAudio.clip);
                _shotLogic.Shot(ammo, position, difference, shotDirection);
            }
            else
            {
                _timeShot -= Time.deltaTime;
            }
        }
    }
}
