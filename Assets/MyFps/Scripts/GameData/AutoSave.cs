using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    public class AutoSave : MonoBehaviour
    {
        private void Start()
        {
            //씬번호 저장
            AutoSaveData();
        }
        void AutoSaveData()
        {
            //현재 씬 저장
            //int sceneNumber = PlayerPrefs.GetInt("PlayScene", 0);
            int sceneNumber = PlayerStats.Instance.SceneNumber;
            Debug.Log($"로드씬 {sceneNumber}");
            int playScene = SceneManager.GetActiveScene().buildIndex;

            //새로 플레이하는 씬인가?
            if(playScene > sceneNumber)
            {
                Debug.Log($"새로프레이씬 {playScene}");
                //PlayerPrefs.SetInt("PlayScene", playScene);
                PlayerStats.Instance.SceneNumber = playScene;
                SaveLoad.SaveData();
            }
        }
    }
}
