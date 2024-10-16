using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class CEnemyTrigger : MonoBehaviour
    {
        #region
        public GameObject theDoor;      //문
        public AudioSource doorBang;    //문 열기 사운드
        public AudioSource jumpScare;   //적 등장 사운드
        public GameObject theRobot;     //적
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySequence());
            //Debug.Log("Triggered by: " + other.gameObject.name);
        }
        IEnumerator PlaySequence()
        {
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;

            //문 사운드
            doorBang.Play();
            //Enemy 활성화
            theRobot.SetActive(true);
            yield return new WaitForSeconds(1f);
            //Enemy 등장 사운드
            jumpScare.Play();

            //Enemy 타겟을 향해 걷기
            RobotController robot = theRobot.GetComponent<RobotController>();
            if(robot != null )
            {
                robot.SetState(RobotState.R_Walk);
            }

           //트리거 킬
            Destroy(this.gameObject);
        }
    }
}
