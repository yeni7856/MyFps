using UnityEngine;

namespace MyFps
{
    public class PickUpPistol : Interactive
    {
        //Action
        public GameObject realPistol;
        public GameObject arrow;

        public GameObject enemyTrigger;

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);
            enemyTrigger.SetActive(true);
            Destroy(gameObject);
        }
    }
}
