using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //사운드 목록관리
    [System.Serializable]
    public class Sound
    {
        #region Variables
        public string name;                             //재생할 이름
        public AudioClip clip;                          //재생할 음원
        [Range(0f,1f)] public float volume;
        [Range(0.1f, 3f)] public float pitch;       //재생속도
        public bool loop;

        [HideInInspector] //이스펙터창엥서 안보이는데 처리할수있음
        public AudioSource audioSource;       //음악을 재생할 오디오
        #endregion
        
    }

}
