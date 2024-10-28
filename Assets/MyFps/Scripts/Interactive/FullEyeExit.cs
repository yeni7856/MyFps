using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class FullEyeExit : Interactive
    {
        #region Variables
        //public GameObject fakeWall;
        public Animator exitWallAim;
        public GameObject emptyPicture;
        public GameObject fullPicture;
        //private bool IsFullEye = false;
        public GameObject exitTrigger;
        public TextMeshProUGUI textBox;
        [SerializeField] private string notKeyText = "You have the required puzzle.";
        #endregion
        protected override void DoAction()
        {
            if (PlayerStats.Instance.HasItem(PuzzleKey.RIGHTEYE_KEY) 
                && PlayerStats.Instance.HasItem(PuzzleKey.LEFTEYE_KEY))
            {
                StartCoroutine(Exit());
            }
            else
            {
               StartCoroutine(LockExit());
            }
        }
        IEnumerator Exit()
        {
            unInteractive = true;
            emptyPicture.SetActive(false);
            yield return new WaitForSeconds(0.23f);
            fullPicture.SetActive(true);

            //fakeWall.SetActive(false);
            //exitWall.SetActive(true);

            exitWallAim.SetBool("IsOpen", true);

            yield return new WaitForSeconds(0.25f);

            //exit 트리거 활성화
            exitTrigger.SetActive(true);    
        }
        IEnumerator LockExit()
        {
            unInteractive = true;          //인터렉티브 기능 막기
            yield return new WaitForSeconds(1f);
            textBox.gameObject.SetActive(true);
            textBox.text = notKeyText;
            unInteractive = false;          //인터렉티브 기능 복원
            yield return new WaitForSeconds(1f);
            textBox.gameObject.SetActive(false);
            textBox.text = "";
        }
    }

}
