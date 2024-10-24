using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DoorExit : Interactive
    {
        #region Variables
        private Animator animator;
        private Collider colliderDoor;
        public TextMeshProUGUI textBox;
       
        //[SerializeField] private string openText = "Open Door";
        [SerializeField] private string notKeyText = "You don't have the required key.";
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            colliderDoor = GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            if (PlayerStats.Instance.HasItem(PuzzleKey.ROOM01_KEY))
            {
                OpenDoor();
                return;
            }
            else
            {
                StartCoroutine(LockedDoor());
            }
        }

        void OpenDoor()
        {
            //textBox.text = openText;
            SoundManager.Instance.Play("DoorOpen");
            animator.SetBool("IsOpen", true);
            colliderDoor.enabled = false;
        }

        IEnumerator LockedDoor()
        {
            unInteractive = true;           //인터렉티브 기능 정지 
            SoundManager.Instance.Play("DoorLocked");

            yield return new WaitForSeconds(1f); 
            //colliderDoor.enabled = true;

            textBox.gameObject.SetActive(true);
            textBox.text = notKeyText;

            yield return new WaitForSeconds(2f);

            textBox.gameObject.SetActive(false);
            textBox.text = "";

            unInteractive = false;
        }
    }
}