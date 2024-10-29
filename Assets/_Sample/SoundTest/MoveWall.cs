using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MySample
{
    public class MoveWall : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float moveTime = 1f;
        private float count = 0f;

        //이동방향 좌/우
        [SerializeField] private float dir = 1f;
        #endregion

        void Start ()
        {
            count = moveTime;
        }

        private void Update()
        {
            //좌우 이동 타이머
            if(count <= 0f)
            {
                //타이머 액션
                dir *= -1;
                //초기화
                count = moveTime;
            }
            count -= Time.deltaTime;
            transform.Translate(Vector3.right * dir * moveSpeed * Time.deltaTime, Space.World); //방향
        }
    }
}
