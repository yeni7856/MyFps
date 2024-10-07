using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

namespace MyFps
{
    public class DoorCellOpen : MonoBehaviour
    {
        #region Variables
        public GameObject ActionUI;
        [SerializeField] private TextMeshProUGUI actionTextUI;
        private string actionText = "Open The Door";

        private float theDistance;

        private Animator doorAnim;
        private Collider colliderDoor;

        public AudioSource audioSource;
        #endregion
        private void Start()
        {
            doorAnim = GetComponent<Animator>();
            colliderDoor = GetComponent<Collider>();
        }
        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        //마우스를 가져가면 액션 UI를 보여주기
        void OnMouseOver()
        {
            if(theDistance <= 2f)
            {
                //PlayerCasting.distanceFromTarget
                ActionUI.SetActive(true);
                actionTextUI.text = actionText;

                if (Input.GetButton("Action"))
                {
                    HideActionUI();

                    doorAnim.SetBool("IsOpen", true);
                    colliderDoor.enabled = false;
                    audioSource.Play();
                }
            }
            else
            {
                HideActionUI();
            }
        }
        //마우스가 벗어나면 액션 UI를 숨긴다.
        private void OnMouseExit()
        {
            HideActionUI();
        }
        void HideActionUI()
        {
            ActionUI.SetActive(false);
            actionTextUI.text = "";
        }
    }

}
