using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    //아이템 획득 여부
    public enum PuzzleKey           //이넘
    {
        ROOM01_KEY,
        ROOM02_KEY,
        LEFTEYE_KEY,
        RIGHTEYE_KEY,
        MAX_KEY                             //퍼즐 아이탬 갯수
    }

    //플레이어의 속성 데이터 값을 관리하는 클래스 (싱글톤, DontDestory) 클래스...ammoCount
    public class PlayerStats : PersistentSingleton<PlayerStats> //제네릭
    {
        #region Variables
        //SceneNumber 저장된
        private int sceneNumber;
        public int SceneNumber
        {
            get {  return sceneNumber; }
            set { sceneNumber = value; }    
        }
        //현재 SceneNumber 
        private int nowSceneNumber;
        public int NowSceneNumber
        {
            get { return nowSceneNumber; }
            set { nowSceneNumber = value; }
        }

        //탄환갯수
        [SerializeField] private int ammoCount;
        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }

        //무기 소지 여부
        private bool hasGun;
        public bool HasGun
        {
            get { return hasGun; }
            set { hasGun = value; }
        }

        //게임 퍼즐 아이템 키
        private bool[] puzzleKeys;
        #endregion

        private void Start()
        {
            //초기화 
            //AmmoCount = 0;
            //초기화 
            puzzleKeys = new bool[(int)PuzzleKey.MAX_KEY];
        }

        public void PlayerStatInit(PlayData playData)
        {
            if(playData != null)
            {
                SceneNumber = playData.scenNumber;
                AmmoCount = playData.ammoCount;
                hasGun = playData.hasGun;

            }
            else //저장된 데이터가 없을때
            {
                SceneNumber = 0;
                AmmoCount = 0;
                hasGun = false;
            }
        }

        public void AddAmmoCount(int ammo)
        {
            AmmoCount += ammo;
        }
        public bool UseAmmo(int ammo) //사용결과 bool 형으로 
        {
            //소지 갯수 체크
            if(AmmoCount < ammo)
            {
                Debug.Log("You need to reload!!");
                return false;   
            }
            AmmoCount -= ammo;  
            return true;
        }
        //아이템 획득
        public void AcquireItme(PuzzleKey key)
        {
            puzzleKeys[(int)key] = true;
        }
        //아이템 소지여부
        public bool HasItem(PuzzleKey key)
        {
            return puzzleKeys[(int)key];
        }
        //무기 소지
        public void SetHasGun(bool value)
        {
            HasGun = value; 
        }
        
    }
}
