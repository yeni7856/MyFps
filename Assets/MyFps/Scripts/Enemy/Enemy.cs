using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static Unity.Burst.Intrinsics.X86;

namespace MyFps
{
    public enum EnemyState
    {
        E_Idel,                 
        E_Walk,             //걷기 - 적 디텍팅 하지 못한 경우
        E_Attack,           //스매시 공격
        E_Death,
        E_Chase             //추격(걸으면서) - 적을 디텍팅한 경우
    }
    public class Enemy : MonoBehaviour, IDamageable
    {
        #region Variables
        private Transform thePlayer;
        private Animator animator;
        private NavMeshAgent agent;

        //로봇상태
        private EnemyState currentState;
        //로봇 이전 상태
        private EnemyState beforeState;

        //체력
        [SerializeField] private float maxHp = 20;
        private float currentHp;
        private bool isDeath = false;

        //이동
        //[SerializeField] private float moveSpeed = 5f;

        //공격
        [SerializeField] private float attackRange = 1.5f;  //공격가능 범위
        [SerializeField] private float attackDmg = 5f;      //공격 데미지

        //패트롤 
        public Transform[] wayPoints;
        private int nowWayPoint = 0;
        private Vector3 startPosition;  //시작위치

        //적 감지
        private bool isAiming = false;
        public bool IsAiming
        {
            get { return isAiming; }
            set { isAiming = value; }
        }
        [SerializeField] private float detectDistance = 15f;
        #endregion

        void Start ()
        {
            thePlayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            
            //초기화
            currentHp = maxHp;
            startPosition = transform.position;
            nowWayPoint = 0;

            if (wayPoints.Length > 0) //0보다 크면 wayPoints가 등록이 되어있음
            {
                SetState(EnemyState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(EnemyState.E_Idel);
            }
            
        }
        void Update ()
        {
            if (isDeath) return;
            //타겟 지정
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if(detectDistance > 0)
            {
                IsAiming = distance <= detectDistance; //거리가 작거나 같으면 
            }

            if (distance <= attackRange)
            {
                SetState(EnemyState.E_Attack);
                agent.SetDestination(this.transform.position);
            }
            else if (detectDistance > 0)            //벗어나면 
            {
                if(IsAiming)       //거리안에 들어온것 
                {
                    SetState(EnemyState.E_Chase);
                }
            }

            switch (currentState)
            {
                case EnemyState.E_Idel:
                    break;
                case EnemyState.E_Walk:
                    //도착 판정
                   if(agent.remainingDistance <= 0.2f)
                    {
                        if(wayPoints.Length > 0)
                        {
                            GoNextPoint();
                        }
                        else
                        {
                            SetState(EnemyState.E_Idel);
                        }
                    }
                    break;
                case EnemyState.E_Attack:
                    transform.LookAt(thePlayer.position);
                    if (distance >= attackRange)
                    {
                        SetState(EnemyState.E_Chase);   
                    }
                    break;
                case EnemyState.E_Death:
                    break;
                case EnemyState.E_Chase:
                    if(detectDistance > 0 && !IsAiming)
                    {
                        GoStartPoint();
                        return;
                    }
                    agent.SetDestination(thePlayer.position);   //플레이어 위치 업데이트
                    break;
            }
        }

        //적의 상태 변경
        public void SetState(EnemyState newstate)
        {
            if (isDeath) return;
            //현재 상태 체크
            if (currentState == newstate) return;

            //이전 상태 저장
            beforeState = currentState;

            //상태 변경
            currentState = newstate;

            //상태 변경에 따른 구현 내용 
            if(currentState == EnemyState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);           //애니메이션 걷기 동작
                animator.SetLayerWeight(1, 1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)newstate);
                animator.SetLayerWeight(1, 0f);
            }
            //Agent 초기화 (목표지점 없애기)
            agent.ResetPath();
        }

        void Attack()
        {
            Debug.Log("플레이어한테 공격");
            IDamageable damageable = thePlayer.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.TakeDamage(attackDmg);
            }
        }
        public void TakeDamage(float dmg)
        {
            currentHp -= dmg;
            Debug.Log(currentHp);

            if (currentHp <= 0 && !isDeath)
            {
                Die();
            }
        }
        void Die()
        {
            SetState(EnemyState.E_Death);
            isDeath = true;
            Debug.Log("Enemy Death!!");
            //충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 2f);
        }

        //다음 목표 지점으로 이동
        void GoNextPoint()
        {
            nowWayPoint++;
            if(nowWayPoint >= wayPoints.Length)
            {
                nowWayPoint = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoint].position);
        }
        public void GoStartPoint()
        {
            if (isDeath) return;
            SetState(EnemyState.E_Walk);
            //nowWayPoint = 0;
            agent.SetDestination(startPosition);
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectDistance);
        }
    }
}
