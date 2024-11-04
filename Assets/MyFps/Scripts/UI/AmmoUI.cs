using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class AmmoUI : MonoBehaviour
    {
        #region Variables
        public GameObject ammoUI;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            ShowAmmo();
        }
        void ShowAmmo()
        {
            ammoUI.SetActive(PlayerStats.Instance.HasGun);
        }
    }
}
