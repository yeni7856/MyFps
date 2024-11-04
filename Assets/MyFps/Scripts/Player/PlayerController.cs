using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        #region Variables
        //체력
        [SerializeField] private float maxHp = 20;
        private float currentHp;
        private bool isDeath = false;

        //데미지 효과
        public GameObject damageFlash;
        //데미지 사운드
        public AudioSource hurt01;
        public AudioSource hurt02;
        public AudioSource hurt03;

        //게임오버 씬
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOver";

        //무기 
        public GameObject realPistol;
        #endregion

        void Start ()
        {
            //초기화
            currentHp = maxHp;
            //무기획득
            if (PlayerStats.Instance.HasGun)
            {
                realPistol.SetActive(true);
            }
        }
        /*public void TakeDmg(float dmg)
        {
            if (isDeath) return;
            currentHp -= dmg;
            Debug.Log($"player : {currentHp}");

            //데미지 효과
            StartCoroutine(DamageEffect());

            if (currentHp <= 0 && !isDeath)
            {
                Die();
            }
        }*/
        public void TakeDamage(float damage)
        {
            //if (isDeath) return;
            currentHp -= damage;
            Debug.Log($"player : {currentHp}");

            //데미지 효과
            StartCoroutine(DamageEffect());

            if (currentHp <= 0 && !isDeath)
            {
                Die();
            }
        }
        public void Die()
        {
            //isDeath = true;
            fader.FadeTo(loadToScene);

        }
        //데미지효과
        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            //카매라 흔들림 
            CinemachineShake.Instance.ShakeCamera(1f, 1f);

            int randNumber = Random.Range(1, 4);
            if(randNumber == 1 )
            {
                hurt01.Play();
            }
            else if (randNumber == 2 )
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }
            yield return new WaitForSeconds(1f);
            damageFlash.SetActive(false);  
        }

        
    }
}
