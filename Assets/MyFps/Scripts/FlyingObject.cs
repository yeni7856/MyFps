using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class FlyingObject : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float velocity = 1f;
        private Rigidbody rb;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = transform.forward * velocity; 
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.relativeVelocity.magnitude > 2)       //상대속도
            {
                //오브젝트나 바닥에 부딪히는 사운드 재생
                SoundManager.Instance.Play("CupFall");
            }
                
        }
    }
}
