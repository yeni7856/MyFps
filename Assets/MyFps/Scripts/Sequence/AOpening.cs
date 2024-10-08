using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class AOpening : MonoBehaviour
    {

        #region Variables
        public GameObject Player;
        public SceneFader fader;

        //Sequence UI
        //public GameObject SequenceUI;
        public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "I need get out of here...";
        #endregion

        void Start ()
        {
            StartCoroutine(PlaySequence());
        }

        //오프닝  시퀀스
        IEnumerator PlaySequence()
        {
            //0. 플레이어 비활성
            Player.SetActive(false);

            //1. 페이드인 효과(1초 대기후 페이드인 효과)_
            //yield return new WaitForSeconds(1f);
            fader.FromFade(1f); //2초 동안 페이드 효과

            //2. 화면 하단에 시나리오 텍스트 화면 출력(3초)
            //I need get out of here
            textBox.gameObject.SetActive(true);
            textBox.text = sequence;

            //3. 3초후에 시나리오 텍스트 없어진다
            yield return new WaitForSeconds(3f);
            textBox.gameObject.SetActive(false); //오브젝트 비활성하던가
            //textBox.text = "";  //텍스트 없애기

            //4. 플레이 캐릭터 활성화
            Player.SetActive(true); 

        }
    }

}