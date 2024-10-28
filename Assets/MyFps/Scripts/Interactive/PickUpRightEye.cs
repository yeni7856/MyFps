using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickUpRightEye : PickUpPuzzleItem
    {
        public GameObject fakeWall;
        public GameObject exitWall;
        protected override void DoAction()
        {
            StartCoroutine(GainPuzzleItem());
            ShowExit();
            
        }
        void ShowExit()
        {
            if(PlayerStats.Instance.HasItem(PuzzleKey.RIGHTEYE_KEY) && PlayerStats.Instance.HasItem(PuzzleKey.LEFTEYE_KEY))
            {
                fakeWall.SetActive(false);
                exitWall.SetActive(true);
            }
        }
    }
}
