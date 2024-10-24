using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickUpKey : Interactive
    {
        #region Variables
        
        #endregion

        protected override void DoAction()
        {
            //키저장
            PlayerStats.Instance.AcquireItme(PuzzleKey.ROOM01_KEY);
            //킬
            Destroy(gameObject);
        }
    }
}
