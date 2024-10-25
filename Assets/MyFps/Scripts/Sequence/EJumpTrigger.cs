using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class EJumpTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        /*public TextMeshProUGUI textBox;
        [SerializeField]
        private string sequence = "Looks like a weapon on that table.";*/
        public GameObject flyCup;
        public GameObject ActivityObj;
        #endregion

        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(JumpTrigger());
        }
        IEnumerator JumpTrigger()
        {
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            ActivityObj.SetActive(true);
            //SoundManager.Instance.Play("CupFall");
            yield return new WaitForSeconds(2f);
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
            yield return new WaitForSeconds(1f);

            Destroy(ActivityObj);
            Destroy(flyCup);
        }
    }
}
