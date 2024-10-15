using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        private Animator m_Animator;
        public ParticleSystem muzzle;
        public AudioSource pistolShoot;

        //
        public Transform firPoint;

        //연사 딜레이
        [SerializeField] private float fireDelay = 0.5f;
        private bool isFire = false;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            m_Animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            //슟
            if (Input.GetButtonDown("Fire1") && !isFire)
            {
                StartCoroutine(Shoot());
            }
        }
        IEnumerator Shoot()
        {
            isFire = true;

            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firPoint.position, firPoint.TransformDirection(Vector3.forward), out hit, maxDistance);
            if (isHit)
            {
                Gizmos.DrawLine(firPoint.position, firPoint.forward * hit.distance);
                Debug.Log("적에게 대미지를준다");
            }

            m_Animator.SetTrigger("Fire");
            pistolShoot.Play();
            muzzle.gameObject.SetActive(true);
            muzzle.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firPoint.position, firPoint.TransformDirection(Vector3.forward), out hit);
            if (isHit)
            {
                Gizmos.DrawLine(firPoint.position, firPoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firPoint.position, firPoint.forward * maxDistance);
            }
        }
    }
}
