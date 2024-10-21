using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class Title : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";

        private bool isAnyKey = false;
        public GameObject anykeyUI;
        #endregion

        private void Start()
        {
            fader.FromFade();
            //초기화
            isAnyKey =false;

            StartCoroutine(TitleProcess());
        }
        //3초뒤에 anykey Show, 10초 뒤에 자동 넘김


        private void Update()
        {
            
            if (Input.anyKey && isAnyKey)
            {
                GoToMenu();
            }
        }

        IEnumerator TitleProcess()
        {
            yield return new WaitForSeconds(4f);
            isAnyKey = true;
            anykeyUI.SetActive(true);

            yield return new WaitForSeconds(10f);
            GoToMenu();
        }

        void GoToMenu()
        {
            StopCoroutine(TitleProcess()); //코루틴 멈춤
            fader.FadeTo(loadToScene);
        }
    }
}
