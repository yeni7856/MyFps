using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyFps
{
    public class FExitTrigger : MonoBehaviour
    {   
        //메인 2번씬 클리어
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainMenu";
        /*private float speed = 1.0f;
        private float count = 0;*/
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            //Invoke("PlaySequence", 1f);
            PlaySequence();
        }
        void PlaySequence()
        {
            //씬클리어 처리
            //배경음 종료
            SoundManager.Instance.StopBgm();

            //씬 클리어 보상, 데이터 등등 클리어 할수있음

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //메인메뉴이동
            fader.FadeTo(loadToScene);
        }
    }
}
