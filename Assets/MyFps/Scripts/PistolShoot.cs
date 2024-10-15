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
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        void Shoot()
        {
            Debug.Log("Shooooot");
        }
    }

}
