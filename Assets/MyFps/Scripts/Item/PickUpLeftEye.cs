using MyFps;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyFps
{
    public class PickUpLeftEye : Interactive
    {
        #region Variables
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGp;

        public Sprite itemSprite;                                                   //획득한 아이템 아이콘
        [SerializeField] private string puzzleStr = "Puzzle Text";   //아이템 획득 안내문구
        #endregion

        protected override void DoAction()
        {
           StartCoroutine(GainPuzzleItem());
        }

        IEnumerator GainPuzzleItem()
        {
            PlayerStats.Instance.AcquireItme(PuzzleKey.LEFTEYE_KEY);        //아이템 획득

            //UI 연출
            if(puzzleUI != null)
            {
                //아이템 트리거 비활성
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);

                puzzleUI.SetActive(false);
            }

            Destroy(gameObject);
        }
    }
}
