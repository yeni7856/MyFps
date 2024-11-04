using UnityEngine;

namespace MySample
{
    public class MoveTest : MonoBehaviour
    {
        #region Variables
        private Rigidbody rbPlayer;

        [SerializeField] private float forwardForce = 10f;
        [SerializeField] private float sideForce = 1f;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            rbPlayer = GetComponent<Rigidbody>();  
        }

        // Update is called once per frame
        void Update()
        {
            float speedX = Input.GetAxis("Horizontal"); //좌우 입력값
            if(speedX < 0f)
            {
                rbPlayer.AddForce(-sideForce, 0f, 0f, ForceMode.Acceleration);
            }
            if (speedX > 0f)
            {
                rbPlayer.AddForce(sideForce, 0f, 0f, ForceMode.Acceleration);
            }
        }

        private void FixedUpdate()
        {
            rbPlayer.AddForce(0f, 0f, forwardForce, ForceMode.Acceleration);
        }
    }
}
