using UnityEngine;

namespace MySample
{
    public class SoundTest : MonoBehaviour
    {
        #region Variables
        private AudioSource audioSource;

        public AudioClip clip;         //재생할 오디오 클립

        [SerializeField] private float volume = 1.0f;    //볼륨크기
        [SerializeField] private float pitch = 1.0f;        //피치 재생속도
        [SerializeField] private bool loop = false;         //루핑
        //[SerializeField] private bool playOnAwake = false;      //플레이온어웨이크
        #endregion

        // Start is called before the first frame update
        void Start()
        {
            audioSource = GetComponent<AudioSource>();
            SoundPlay();
            SoundInShot();
        }
        void SoundPlay()
        {
            audioSource.clip = clip;
            audioSource.volume = volume;
            audioSource.pitch = pitch;
            audioSource.loop = loop;
            //audioSource.playOnAwake = playOnAwake;
            audioSource.Play();
        }

        void SoundInShot()
        {
            audioSource.PlayOneShot(clip,1f);
        }
    }
}
