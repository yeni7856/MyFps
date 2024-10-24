using TMPro;
using UnityEngine;

namespace MyFps
{
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        private  float theDistance;

        public GameObject ActionUI;
        public TextMeshProUGUI actionTextUI;
        [SerializeField] private string actionText = "Action Text";
        public GameObject extraCross;

        //트루면 인터랙티브 안됨 기능 정지
        protected bool unInteractive = false;
        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        private void OnMouseOver()
        {
            if (theDistance <= 2f && !unInteractive)
            {
                //PlayerCasting.distanceFromTarget
                ShowActionUI();

                if (Input.GetButton("Action"))
                {
                    HideActionUI();

                    //Action
                    DoAction();
                }
            }
            else
            {
                HideActionUI();
            }
        }
        void OnMouseExit()
        {
            HideActionUI();
        }
         void ShowActionUI()
        {
            ActionUI.SetActive(true);
            actionTextUI.text = actionText;
            extraCross.SetActive(true);
        }
       void HideActionUI()
        {
            ActionUI.SetActive(false);
            actionTextUI.text = "";
            extraCross.SetActive(false);
        }
    }
}
