using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//오디오를 관리하는 클래스
namespace MyFps
{
    public class SoundManager : PersistentSingleton<SoundManager>
    {
        #region Variables
        public Sound[] sounds;
        private string bgmSound = "";       //현재 플레이 되는 배경음 이름
        public string BgmSound
        {
            get { return bgmSound; }
        }
        #endregion

        protected override void Awake()
        {
            base.Awake(); //싱글톤 구현부

            //오디오 매니저 초기화
            foreach (var sound in sounds)
            {
                sound.audioSource = this.gameObject.AddComponent<AudioSource>();  
                
                sound.audioSource.clip = sound.clip;
                sound.audioSource.volume = sound.volume;
                sound.audioSource.pitch = sound.pitch;
                sound.audioSource.loop = sound.loop;
                Debug.Log($"Loaded sound: {sound.name}");  // 사운드 이름 출력
            }
        }

       public void Play(string name)
        {
            Sound sound = null;

            //목록가져오기 //이런이름을 가진 같은놈이있음 플레이하소
            //매개변수 이름과 같은 클립
            foreach(var s in sounds)
            {
                if(s.name == name)
                {
                    sound = s;
                    break;
                }
            }
            //매개변수 이름과 같은 클립없으면
            if(sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }
            sound.audioSource?.Play();
        }

        public void Stop(string name)
        {
            Sound sound = null;

            //매개변수 이름과 같은 클립
            foreach (var s in sounds)
            {
                if (s.name == name)
                {
                    sound = s;

                    //초기화 
                    if(s.name == bgmSound)
                        bgmSound = "";

                    break;
                }
            }
            //매개변수 이름과 같은 클립없으면
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }
            sound.audioSource?.Stop();
        }

        //Bgm 배경음 재생
        public void PlayBgm(string name)
        {
            //배경음 이름 체크 
            if(bgmSound == name)
            {
                return;
            }
            //배경음 스탑
            StopBgm();

            Sound sound = null;

            foreach(var s in sounds)
            {
                if(s.name == name)
                {
                    bgmSound = s.name;      //현재 플레이되고 있는 배경음저장 
                    sound= s;
                    break;
                }
            }
            //매개변수 이름과 같은 클립없으면
            if (sound == null)
            {
                Debug.Log($"Cannot Find {name}");
                return;
            }
            sound.audioSource?.Play();
            foreach (var s in sounds)
            {
                Debug.Log($"Available Sound: {s.name}");
            }
        }
        public void StopBgm()
        {
            Stop(bgmSound);
        }
    }
}
