using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class GEnemyZoneInTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        public GameObject enemyZonOut;
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if(other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            //아웃 트리거 활성 
            if (other.tag == "Player")
            {
                gunMan.GetComponent<Enemy>().SetState(EnemyState.E_Chase);
                //gunMan 제자리로 
                this.gameObject.SetActive(false);
                enemyZonOut.SetActive(true);
            }
        }
    }
}