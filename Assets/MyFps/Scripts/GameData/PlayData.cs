using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //파일에 저장할 게임 플레이 데이터 목록
    [System.Serializable] //직렬화 꼭 필요 이진화 가능
    public class PlayData
    {
        public int scenNumber;
        public int ammoCount;
        public bool hasGun;

        //.....Health or...

        //생성자 - 플레이어 스텟에 있는 데이터로 초기화
        public PlayData()
        {
            scenNumber = PlayerStats.Instance.SceneNumber;
            ammoCount = PlayerStats.Instance.AmmoCount;
            hasGun = PlayerStats.Instance.HasGun;
        }
    }
}
