using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class PickUpPistol : Interactive
    {
        //Action
        public GameObject realPistol;
        public GameObject arrow;

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);
            Destroy(gameObject);
        }

    }
}
