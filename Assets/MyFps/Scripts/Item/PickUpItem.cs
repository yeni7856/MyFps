using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickUpItem : AmmoPick
    {
        #region Variables
        [SerializeField] private int giveAmmo = 7;
        #endregion
        protected override bool OnPickup()
        {
            Debug.Log("7개 아이템1 지급");
            PlayerStats.Instance.AddAmmoCount(giveAmmo);
            return true;
        }
    }
}
