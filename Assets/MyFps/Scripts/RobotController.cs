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

        private void Start()
        {
            Animator = GetComponent<Animator>();

            SetState(RobotState.R_Idle);
        }

        //로봇의 상태 변경
        void SetState(RobotState newstate)
        {
            currentState = newstate;
            Animator.SetInteger("RobotState", (int)newstate);
        }
    }
}