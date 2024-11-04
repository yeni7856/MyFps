using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MyFps;
using Cinemachine;

public class CinemachineShake : Singleton<CinemachineShake>
{
    #region Variables
    private CinemachineVirtualCamera cvCamera;
    private CinemachineBasicMultiChannelPerlin channelPerlin;

    //[SerializeField] private float amplitued = 1f;  //흔들림의 ㅣ크기
    [SerializeField] private float frequency = 1f;  //흔들림의 속도
    private bool isShake = false;                        //흔들고있는지 아닌지   
    #endregion

    protected override void Awake()
    {
        base.Awake();
        cvCamera = this.GetComponent<CinemachineVirtualCamera>();
        channelPerlin = cvCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    private void Update()
    {
      /*  if(Input.GetKeyDown(KeyCode.G))
        {
            ShakeCamera(1f, 1f);
        }*/
    }
    //카메라 흔들기
    //amplitued 흔들림 세기 크기 shakeTime : 흔들리는 시간
    public void ShakeCamera(float amplitued, float shakeTime)
    {
        if (isShake) return;
        StartCoroutine(StartShake(amplitued, shakeTime));
    }
    IEnumerator StartShake(float amplitued, float shakeTime)
    {
        isShake = true;
        channelPerlin.m_AmplitudeGain = amplitued;
        channelPerlin.m_AmplitudeGain = frequency;          //속도
       
        yield return new WaitForSeconds(shakeTime);
        channelPerlin.m_FrequencyGain = 0f;
        channelPerlin.m_FrequencyGain = 0f;
        isShake = false;
    }

}

