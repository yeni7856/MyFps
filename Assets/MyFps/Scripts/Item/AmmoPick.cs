using UnityEngine;

namespace MyFps
{
    public class AmmoPick : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float verticalBobFrequency = 10f;       //이동속도
        [SerializeField] private float bobingAmount = 1f;                  //이동 거리
        [SerializeField] private float rotateSpeed = 360f;                  //회전 속도

        private Vector3 startPosition;
        #endregion

        void Start ()
        {
            //포지션초기화
            startPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            //위아래 흔들림 
            float bobingAnimationPhase = Mathf.Sin(Time.time * verticalBobFrequency) * bobingAmount; 
            transform.position = startPosition + Vector3.up * bobingAnimationPhase; //+1에서 -1로 이동 
            
            //회전
            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }
        private void OnTriggerEnter(Collider other)
        {
            //플레이어 체크
            if(other.tag == "Player")
            {   
                //아이템 성공 했을때 
                if(OnPickup() == true)
                {
                    //획득 성공 효과, 사운드, 이펙트 등등
                    //킬
                    Destroy(gameObject);
                }
            }
        }
        //아이템 획득 성공, 실패 반환
        protected virtual bool OnPickup()
        {
            //상속해주기
            return true;    
        }
    }
}
