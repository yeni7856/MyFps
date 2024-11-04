using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;   //이진화저장시 필요함

namespace MyFps
{
    //게임 데이터 파일 저장/가져오기 구현 - 이진화 저장
    public static class SaveLoad
    {
       public static void SaveData()
        {
            //파일이름, 경로 지정
            //파일 저장시 이경로로 
            //확장명 아무거나 사용가능
            string path = Application.persistentDataPath + "/playData.arr"; 
            
            //저장할 데이터를 이진화 준비
            BinaryFormatter formatter = new BinaryFormatter();
            
            //파일접근 - 존재하면 파일 가져오기, 존재하지않으면 새로만들기
            FileStream fs = new FileStream(path, FileMode.Create);

            //저장할 데이터 셋팅
            PlayData playData = new PlayData();
            Debug.Log(playData.scenNumber);

            //준비한 데이터를 이진화 저장
            formatter.Serialize(fs, playData);

            //파일클로즈
            fs.Close();
        }

        //플레이어 데이타에 반환하는
        public static PlayData LoadData()
        {
            PlayData playData;

            //파일이름, 경로 지정
            string path = Application.persistentDataPath + "/playData.arr";

            //지정된 경로에 저장된 파일이 있는지 없는지 체크
            if(File.Exists(path) == true)
            {
                //파일이 있음
                //저장할 데이터를 이진화 준비
                BinaryFormatter formatter = new BinaryFormatter();

                //파일접근
                FileStream fs = new FileStream(path, FileMode.Open);

                //파일에 이진화로 저장된 데이터 역 이진화 해서 가져오기
                //플레이데이타로 역진화한걸 읽어서 저장
                playData = formatter.Deserialize(fs) as PlayData; 
                Debug.Log(playData.scenNumber);

                //파일클로즈 //항상 파일 클로즈 
                fs.Close();
            }
            else
            {
                //파일이 없는것 
                Debug.Log("No Found Load File");
                playData = null;
            }

            return playData;
        }
    }
}
