using MyFps;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MyFps
{
    public class PickUpPuzzleItem : Interactive
    {
        #region Variables
        public GameObject puzzleUI;
        public Image itemImage;
        public TextMeshProUGUI puzzleText;

        public GameObject puzzleItemGp;

        [SerializeField] private PuzzleKey puzzleKey;

        public Sprite itemSprite;                                                   //획득한 아이템 아이콘
        [SerializeField] private string puzzleStr = "Puzzle Text";   //아이템 획득 안내문구
        #endregion
        protected override void DoAction()
        {
            // 현재 게임 오브젝트가 활성화된 상태인지 확인하고 코루틴을 실행
            // 오브젝트 일시적으로 활성화
            gameObject.SetActive(true);
            StartCoroutine(GainPuzzleItem());
            Debug.Log("DoAction이 호출되었습니다.");
        }
        protected IEnumerator GainPuzzleItem()
        {
            PlayerStats.Instance.AcquireItme(puzzleKey);
            //UI 연출
            if (puzzleUI != null)
            {
                //아이템 트리거 비활성
                this.GetComponent<BoxCollider>().enabled = false;
                puzzleItemGp.SetActive(false);

                puzzleUI.SetActive(true);
                itemImage.sprite = itemSprite;
                puzzleText.text = puzzleStr;

                yield return new WaitForSeconds(2f);
                puzzleUI.SetActive(false);
                Debug.Log("UI 비활성ㅇ화");
            }

            Destroy(gameObject);
        }
    }
}