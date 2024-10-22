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

        private SoundManager soundManager;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //씬페이더
            fader.FromFade();

            //참조
            soundManager = SoundManager.Instance;

            //Bgm 플레이
            soundManager.PlayBgm("MenuBgm");
        }

        // Update is called once per frame
        void Update()
        {

        }
        public void NewGame()
        {
            soundManager.Stop(soundManager.BgmSound);
            soundManager.Play("MenuButton");
            fader.FadeTo(loadScene);
            Debug.Log("NewGame");
        }
        public void LoadGame()
        {
            Debug.Log("LoadGame");
        }
        public void Options()
        {
            soundManager.PlayBgm("PlayBgm");
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
