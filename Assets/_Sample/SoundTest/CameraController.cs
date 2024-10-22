using UnityEngine;

namespace MySample
{
    public class CameraController : MonoBehaviour
    {
        #region Variables
        public Transform thePlayer;
        [SerializeField] private Vector3 offset;
        #endregion


        // Update is called once per frame
        void LateUpdate()
        {
            this.transform.position = thePlayer.position + offset;
        }
    }
}
