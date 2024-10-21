using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class MainMenuUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadScene = "MainScene01";
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            fader.FromFade();
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void NewGame()
        {
            fader.FadeTo(loadScene);
            Debug.Log("NewGame");
        }
        public void LoadGame()
        {
            Debug.Log("LoadGame");
        }
        public void Options()
        {
            Debug.Log("Options");
        }
        public void Credits()
        {
            Debug.Log("Credits");
        }
        public void QuitGame()
        {
            Debug.Log("QuitGame");
        }
    }
}
