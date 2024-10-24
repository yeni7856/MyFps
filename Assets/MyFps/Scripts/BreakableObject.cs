using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class BreakableObject : MonoBehaviour, IDamageable
    {
        //총을 맞으면 
        //페이크오브젝트 -> 브레이크오브젝트로 바뀌어야한다
        //깨지는 사운드 재생
        #region Variables
        public GameObject fakeObj;          //오브젝트
        public GameObject breakObj;         //깨진 오브젝트
        public GameObject effectObj;        //깨지는 움직임 효과 오브젝트

        //숨겨진 아이템
        public GameObject hiddenItem;

        private bool isBreak = false;
        [SerializeField] private bool unBreakable = false;       //트루면 깨지지않음
        #endregion

        public void TakeDamage(float damage)
        {
            //깨진 여부체크
            if (unBreakable)
            {
                return;
            }
            //1 shot 1 kill 
            if (!isBreak)
            {
                StartCoroutine(BreakObj());
            }
        }

        IEnumerator BreakObj()
        {
            isBreak = true;
            this.GetComponent<BoxCollider>().enabled = false;

            fakeObj.SetActive(false);
            yield return new WaitForSeconds(0.05f);

            SoundManager.Instance.Play("PotterySmash");
            breakObj.SetActive(true);

            if (effectObj != null)
            {
                effectObj.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                effectObj.SetActive(false);
            }
            //숨겨진 아이템 있으면 아이템 보여주기
            if(hiddenItem != null)
            {
                hiddenItem.SetActive(true);
            }
        }
    }

}
