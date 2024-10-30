using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace MyFps
{
    public class HEnemyZoneOutTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        public GameObject enemyZonIn;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //적 제자리로 돌아가라 
            if(other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().GoStartPoint();
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            //인트리거 활성화
            if (other.tag == "Player")
            {
                gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                this.gameObject.SetActive(false);
                enemyZonIn.SetActive(true);
            }
        }
    }
}