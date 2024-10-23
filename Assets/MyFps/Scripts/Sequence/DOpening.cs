using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;

namespace MyFps
{
    public class DOpening : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        public GameObject Player;
        public TextMeshProUGUI textBox;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = false;
            StartCoroutine(Sequence());
        }
        IEnumerator Sequence()
        {
            Player.GetComponent<FirstPersonController>().enabled = false;
            SoundManager.Instance.PlayBgm("PlayBgm");
            textBox.text = "";
            yield return new WaitForSeconds(1f);
            fader.FromFade();
            Player.GetComponent<FirstPersonController>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
