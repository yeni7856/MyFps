using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace MyFps
{
    public class MainMenuUI : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadScene = "IntroScene";

        private SoundManager soundManager;
        public GameObject mainMenuUI;
        public GameObject optionUI;
        public GameObject creditUI;
        public GameObject loadGame;

        //Audio
        public AudioMixer audioMixer;
        public Slider bgmSlider;
        public Slider sfxSlider;

        //저장되어 있는 씬번호
        private int sceneNumber;
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            //게임 데이터 초기화
            InitGameData();

            //sceneNumber = PlayerPrefs.GetInt("PlayScene", 0); //저장값이 없을때.
            Debug.Log($"저장된 {PlayerStats.Instance.SceneNumber}");
            //저장된 씬이 있으면
            if(PlayerStats.Instance.SceneNumber > 1)
            {
                loadGame.SetActive(true);
            }

            //씬페이더
            fader.FromFade();

            //참조
            soundManager = SoundManager.Instance;

            //Bgm 플레이
            //soundManager.PlayBgm("MenuBgm");
        }
        void InitGameData()
        {
            //게임 설정값, 저장데이터, 저장된, 옵션값 로드 
            LoadOptions();

            //게임플레이 데이터 로드
            PlayData playData = SaveLoad.LoadData();
            PlayerStats.Instance.PlayerStatInit(playData); 

        }
        // Update is called once per frame
        void Update()
        {
           /* if (Input.GetKeyDown(KeyCode.Escape) && creditUI.activeSelf)
            {
                HideCredits();
            }*/
        }

        public void NewGame()
        {
            soundManager.Stop(soundManager.BgmSound);
            soundManager.Play("MenuButton");

            fader.FadeTo(loadScene);
        }
        public void LoadGame()
        {
            //Debug.Log($" GoTo LoadGame {sceneNumber}");
            soundManager.Stop(soundManager.BgmSound);
            soundManager.Play("MenuButton");

            fader.FadeTo(PlayerStats.Instance.SceneNumber);
        }
        public void Options()
        {
            soundManager.PlayBgm("PlayBgm");
            optionUI.SetActive(true);
            mainMenuUI.SetActive(false);
        }
        public void OptionExit()
        {
            //바뀐 오디오 값 저장
            SaveOptions();

            optionUI.SetActive(false);
            mainMenuUI.SetActive(true);
        }
        public void Credits()
        {
            creditUI.SetActive(true);
            mainMenuUI.SetActive(false);
        }

        public void QuitGame()
        {
            //Cheating
            PlayerPrefs.DeleteAll();
            SaveLoad.DeleteFile();
            Debug.Log("QuitGame");
            Application.Quit(); 
        }

        //오디오 믹서
        public void SetBgmVolume(float value)
        { 
            audioMixer.SetFloat("BgmVolume", value);
        }
        public void SetSfxVolume(float value)
        {
            audioMixer.SetFloat("SfxVolume", value);
        }
        //옵션값 저장하기
        private void SaveOptions()
        {
             PlayerPrefs.SetFloat("BgmVolume", bgmSlider.value);
             PlayerPrefs.SetFloat("SfxVolume", sfxSlider.value);
        }
        //옵션값 로드하기
        private void LoadOptions()
        {
            //배경음 볼륨
            float bgmVolume = PlayerPrefs.GetFloat("BgmVolume", 0);
            SetBgmVolume(bgmVolume);    //사운드 볼륨 조절
            bgmSlider.value = bgmVolume;

            //효과음 볼륨
            float sfxVolume = PlayerPrefs.GetFloat("SfxVolume", 0);
            SetSfxVolume(sfxVolume);    //사운드 볼륨 조절
            sfxSlider.value = sfxVolume;

        }
    }
}
