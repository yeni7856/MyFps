using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MyFps
{
    public class Intro : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene01";

        //0.08
        public CinemachineDollyCart dollyCart;

        private bool[] isWaypoints;
        [SerializeField] private int wayPotinIndex = 0;     //이동 목표지점 인덱스

        public Animator cameraAnim;
        public GameObject introUI;
        public GameObject shedLight;

        #endregion

        private void Start()
        {
            dollyCart.m_Speed = 0f;
            wayPotinIndex = 0;
            isWaypoints = new bool[5];

            StartCoroutine(StartIntro());
        }
        private void Update()
        {
            //도착판정
            if(dollyCart.m_Position > wayPotinIndex && isWaypoints[wayPotinIndex] == false)
            {
                //연출
                if(wayPotinIndex == isWaypoints.Length - 1)
                {
                    //마지막 지점
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }
            //인트로 스킵 esc키 누르면 인트로 강제 종료하고 씬이동
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GoMainScene();
            }
        }

        IEnumerator StartIntro()
        {
            isWaypoints[wayPotinIndex] = true;
            wayPotinIndex++;

            fader.FromFade();
            SoundManager.Instance.PlayBgm("IntroBgm");
            yield return new WaitForSeconds(1f);

            //카메라 애니메이션
            cameraAnim.SetTrigger("ArroundTrigger");
            yield return new WaitForSeconds(3f);

            //출발
            dollyCart.m_Speed = 0.08f;
        }

        IEnumerator StayIntro()
        {
            isWaypoints[wayPotinIndex] = true;  //위에서 막아주고 시작
            wayPotinIndex++;
            dollyCart.m_Speed = 0f;

            yield return new WaitForSeconds(1f);

            //카메라 애니메이션
            cameraAnim.SetTrigger("ArroundTrigger");

            int nowIndex = wayPotinIndex - 1; //현재 위치 
            switch (nowIndex)
            {
                case 1:
                    introUI.SetActive(true);
                    break;
                case 2:
                    introUI.SetActive(false);
                    break;
                case 3:
                    shedLight.SetActive(true);
                    break ;
            }
            yield return new WaitForSeconds(3f);
            //출발
            dollyCart.m_Speed = 0.08f;
        }
        //씬넘김
        IEnumerator EndIntro()
        {
            isWaypoints[wayPotinIndex] = true;  //위에서 막아주고 시작
            dollyCart.m_Speed = 0f;

            yield return new WaitForSeconds(2f);

            shedLight.SetActive(false);
            yield return new WaitForSeconds(1f);

            SoundManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }
        private void GoMainScene()
        {
            SoundManager.Instance.StopBgm();
            fader.FadeTo(loadToScene);
        }
    }
}
