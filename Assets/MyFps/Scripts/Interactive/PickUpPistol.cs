using UnityEngine;

namespace MyFps
{
    public class PickUpPistol : Interactive
    {
        //Action
        public GameObject realPistol;
        public GameObject arrow;

        public GameObject enemyTrigger;

        public GameObject ammoBox;
        public GameObject ammoUI;

        protected override void DoAction()
        {
            arrow.SetActive(false);

            ammoBox.SetActive(true);

            enemyTrigger.SetActive(true);

            //무기획득
            PlayerStats.Instance.SetHasGun(true);
            ammoUI.SetActive(true);
            realPistol.SetActive(true);

            Destroy(gameObject);
        }
    }
}
