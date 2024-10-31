using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CreditUI : MonoBehaviour
    {
        #region Variables
        public GameObject mainMenuUI;
        public GameObject creditUI;
        #endregion
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                HideCredits();
            }

        }
        void HideCredits()
        {
            mainMenuUI.SetActive(true);
            creditUI.SetActive(false);
        }
    }
}
