using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
// using DG.Tweening;

public class comds : MonoBehaviour
{


    public DialogueRunner DR;

private void Awake() {
                
                // DR.AddCommandHandler<string, float,float,float>("palceIlustraion", palceIlustraion);
                DR.AddCommandHandler<string,float,float,float,float>("moveIlustration", moveIlustration);
                DR.AddCommandHandler<string,float,float,float,float>("rotateIlustration", rotateIlustration);
                DR.AddCommandHandler<string,string>("obejctActive", obejctActive);
                DR.AddCommandHandler<string,float,float>("fade", fade);
    }
   // 일러스트 배치 커멘드
public void palceIlustraion(string ilustration, float xPoition = 0F ,float yPosition = 0, float zPosition=0F)
                                //배치시킬 오브젝트 이름 , 배치시킬 x축 위치,   배치시킬 y축 위치,     배치시킬 Y축 위치.
    {
        // 일러스트 경로를 입력받고 입력받은 일러스트를 배치시키기.
        // GameObject ilustrationOBG = GameObject.Find (ilustration);
        // Instantiate(ilustrationOBG); 
        // rectTransform = GetComponent<ilustrationOBG.RectTransform>();
        // ilustrationOBG.transform.position = (xPoition ,yPosition, zPosition);
    
    }   

 // 일러스트 움직임 조작 커맨드
float moveTimeInvok;
GameObject ilustrationOBG;
Vector3 moveDir;
float timestart;
void move ()
    {
        float deltaTime = Time.time - timestart;

        if (deltaTime < moveTimeInvok) {
            Debug.Log(" is moveing!");
            ilustrationOBG.transform.position = Vector3.Lerp (ilustrationOBG.transform.position, moveDir, deltaTime / moveTimeInvok);
        } else {
            this.transform.position = moveDir;
            CancelInvoke ("move"); // 애니메이션이 종료되면 invoke repeater 종료
        }
    }
    public void moveIlustration(
        string ilustration,
        float xposition,
        float yposition,
        float zposition,
        float moveTime
        )
    {   
       Debug.Log($"{name} is  satrt to move!");
        // 일러스트에 대한 움직임. 
        // var ilustrationRT = ilustrationOBG.GetComponent<RectTransform>();
        if (ilustration==null||GameObject.Find(ilustration)==null )
            Debug.Log("없는데요?");
        else
        {
            moveTimeInvok = moveTime;
            ilustrationOBG = GameObject.Find(ilustration);
            moveDir = new Vector3(xposition, yposition, zposition);
            timestart = Time.time;
            InvokeRepeating("move",0,0.016f);
            
        }

    }

Vector3 moveAngle;
float rotatetimeInvoke;
void rotate ()
{
        float deltaTime = Time.time - timestart;

        if (deltaTime < rotatetimeInvoke) {

            Debug.Log($"{ilustrationOBG.transform.rotation}, {Quaternion.Euler(moveAngle)}, {moveAngle},{deltaTime} is rotateing!");
            ilustrationOBG.transform.rotation = Quaternion.Lerp(ilustrationOBG.transform.rotation, Quaternion.Euler(moveAngle), deltaTime / rotatetimeInvoke);
        } else {
            ilustrationOBG.transform.rotation = Quaternion.Euler(moveAngle);
            CancelInvoke ("rotate"); // 애니메이션이 종료되면 invoke repeater 종료
        }
}
public void rotateIlustration(
        string ilustration,
        float xrotates,
        float yrotates,
        float zrotates,
        float rotateSppeed )
{
        ilustrationOBG = GameObject.Find(ilustration);
        moveAngle = new Vector3(xrotates,yrotates,zrotates);
        Debug.Log($"{ilustration} {moveAngle} is rotateing!");
        rotatetimeInvoke = rotateSppeed;
        timestart = Time.time;
        InvokeRepeating("rotate",0,0.016f);
}
    

public void obejctActive(string objectName, string setMode)
{
    var objectis = GameObject.Find("Ilustration_System").transform.FindChild(objectName);
    if (setMode=="False") 
    {
        objectis.gameObject.SetActive(false);
        Debug.Log($"{setMode} is flase");
    }
    else if(setMode=="True")
    {
        objectis.gameObject.SetActive(true);
        Debug.Log($"{setMode} is ture");
    }
    else
        Debug.Log($"{setMode} is incorrect, it can be only True or False");
}

float fadeRespect;
float fadeTime;
float repeatEndTime = 0;
float fadeObjectAlpah;
Image fadeObject;
float fadeGap;
void doFade ()
{
    float deltaTime = Time.time - timestart;
    float deltaRepeatTime = Time.time - repeatEndTime;
    Color imgageColor = fadeObject.color;
    if (deltaTime < fadeTime)
    {
        
        if (0 < fadeGap) {
            imgageColor.a = fadeObjectAlpah + fadeGap*(deltaTime/fadeTime);
            fadeObject.color = imgageColor;
        } 
        else if(fadeGap < 0){
            imgageColor.a = fadeObjectAlpah + fadeGap*(deltaTime/fadeTime);
            fadeObject.color = imgageColor;
        }
        Debug.Log($"{deltaTime} {imgageColor.a}현재값, {deltaTime/fadeTime}함수실행 후 지난시간/함수 실행 기대시간");
        
    }
    else {
            imgageColor.a = fadeRespect;
            fadeObject.color = imgageColor;
            CancelInvoke ("rotate"); // 애니메이션이 종료되면 invoke repeater 종료
        }
    repeatEndTime = Time.time;
}
public void fade (string fadeObjectName, float value, float chaingeTime)
{
    fadeRespect = value;
    fadeTime = chaingeTime;
    fadeObject = GameObject.Find(fadeObjectName).GetComponent<Image>();
    fadeObjectAlpah = fadeObject.color.a;
    fadeGap = value - fadeObject.color.a;
    Debug.Log($"{fadeObjectAlpah} 실험중임, 현재 알파값, {fadeGap}현재 갭 값");
    InvokeRepeating("doFade",0,0.016f);
}
































}



