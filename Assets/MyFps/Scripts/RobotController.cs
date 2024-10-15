using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //로봇상태
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }
    //로봇 Enemy 관리 클래스
    public class RobotController : MonoBehaviour
    {
        private Animator Animator;

        //로봇상태
        private RobotState currentState;
        //로봇 이전 상태
        private RobotState beforeState;

        //체력
        [SerializeField] private float startHp = 20;

        private void Start()
        {
            Animator = GetComponent<Animator>();

            SetState(RobotState.R_Idle);
        }

        //로봇의 상태 변경
        void SetState(RobotState newstate)
        {
            //현재 상태 체크
            if(currentState == newstate) return;

            //이전 상태 저장
            beforeState =currentState;

            //상태 변경
            currentState = newstate;

            //상태 변경에 따른 구현 내용 
            Animator.SetInteger("RobotState", (int)newstate);
        }
    }
}