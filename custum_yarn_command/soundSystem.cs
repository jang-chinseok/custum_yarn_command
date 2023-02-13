using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class yarnSoundSystem : MonoBehaviour
{
    public DialogueRunner DR;
    public GameObject BGMPlyer;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = BGMPlyer.GetComponent<AudioSource>();
        DR.AddCommandHandler<string>("BGMPlay",BGMPlay);
        DR.AddCommandHandler<string>("soundPlay", soundPlay);
    }
//==========소리 조작 관련 함수 ============
    void soundPlay(string playFile){
        // audioSource.Play(playFile);
        // BGM외의 사운드 재생 커멘드
    } 
    void BGMPlay(string playFile){

        stringAudio BGMPlaySound = audioSource.GetComponent<backGroundSound>().BGMList;
        audioSource.clip = BGMPlaySound[playFile];
        audioSource.Play();
        Debug.Log($"실행중{BGMPlaySound[playFile]}");
    } 
}
