using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
// using DG.Tweening;

public class custumYarnCommands : MonoBehaviour
{
    public DialogueRunner DR;
// ============= Yarn command defining  ===========
private void Awake() {
                
        // DR.AddCommandHandler<string, float,float,float>("palceIlustraion", palceIlustraion);
        DR.AddCommandHandler<string,float,float,float,float>("moveIlustration", moveIlustration);
        DR.AddCommandHandler<string,float,float,float,float>("rotateIlustration", rotateIlustration);
        DR.AddCommandHandler<string,string>("obejctActive", obejctActive);
        DR.AddCommandHandler<string,float,float>("fade", fade);
        DR.AddCommandHandler<string,float,float>("moveDown", moveDown);
        DR.AddCommandHandler<string,float,float,float>("shakeHorizontal", shakeHorizontal);

}               
// =========== yet making object Instantiate createing ===============
public void palceIlustraion(string ilustration, float xPoition = 0F ,float yPosition = 0, float zPosition=0F)
                                //배치시킬 오브젝트 이름 , 배치시킬 x축 위치,   배치시킬 y축 위치,     배치시킬 Y축 위치.
{
        // 일러스트 경로를 입력받고 입력받은 일러스트를 배치시키기.
        // GameObject ilustrationOBG = GameObject.Find (ilustration);
        // Instantiate(ilustrationOBG); 
        // rectTransform = GetComponent<ilustrationOBG.RectTransform>();
        // ilustrationOBG.transform.position = (xPoition ,yPosition, zPosition);
    
}   

// ========  moveIlustration(오브젝트 움직임) code, moveing Ilustration or object ========
float moveTimeInvok;
GameObject ilustrationOBG;
Vector3 startPosition;
Vector3 moveDir;
float timestart;
void move ()
{
        float deltaTime = Time.time - timestart;

        if (deltaTime < moveTimeInvok) {
            Debug.Log($" {ilustrationOBG.transform.position}, {moveDir}is moveing!");
            ilustrationOBG.transform.position = Vector3.Lerp (startPosition, moveDir, deltaTime/moveTimeInvok);
        } else {
            ilustrationOBG.transform.position = moveDir;
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
            startPosition = ilustrationOBG.transform.position;
            timestart = Time.time;
            InvokeRepeating("move",0,0.016f);
            
        }

 }

// ============ rotateIlustration(오브젝트 각도움직임.) code
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
    
// ========= object activate code =============
public void obejctActive(string objectName, string setMode)
{
    var objectis = GameObject.Find("Ilustration_System").transform.Find(objectName);
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

// ========== fade in/out code ===============
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




//=============================Animation cection=================================
//========= moveDown then move origin========
public void moveDown(string ilustration,float moveDapth=100,float moveTime=5)
{
           Debug.Log($"{name} is  satrt to move!");
        // 일러스트에 대한 움직임. 템플릿 상하이동 1회. 
        if (ilustration==null||GameObject.Find(ilustration)==null )
            Debug.Log("없는데요?");
        else
        {
            moveTimeInvok = moveTime;
            ilustrationOBG = GameObject.Find(ilustration);
            moveDir = new Vector3(ilustrationOBG.transform.position[0],ilustrationOBG.transform.position[1] - moveDapth, ilustrationOBG.transform.position[2]);
            timestart = Time.time;
            startPosition = ilustrationOBG.transform.position;
            Debug.Log($"{startPosition},{moveDir} is  satrt to move!");
            InvokeRepeating("move",0,0.016f);
            StartCoroutine("moveDownReverse");
            
        }
}
IEnumerator moveDownReverse()
{
    yield return new WaitForSeconds(moveTimeInvok);
    moveDir = startPosition;
    startPosition = ilustrationOBG.transform.position;
    timestart = Time.time;
    InvokeRepeating("move",0,0.016f);
    yield break;
}


//============== move horizontal fast repeating ==============

Vector3 moveDirLeft,moveDirRight;
float shakeHorizontalActive, activateTime;
public void shakeHorizontal(string ilustration, float moveRange, float moveTime, float activeTime)
{
               Debug.Log($"{name} is  satrt to move!");
       
        if (ilustration==null||GameObject.Find(ilustration)==null )
            Debug.Log("없는데요?");
        else
        {   activateTime = Time.time;
            shakeHorizontalActive = activeTime;
            moveTimeInvok = moveTime;
            ilustrationOBG = GameObject.Find(ilustration);
            moveDirLeft = new Vector3(ilustrationOBG.transform.position[0] - moveRange, ilustrationOBG.transform.position[1], ilustrationOBG.transform.position[2]);
            moveDirRight = new Vector3(ilustrationOBG.transform.position[0]  + moveRange, ilustrationOBG.transform.position[1], ilustrationOBG.transform.position[2]);
            Debug.Log($"{moveDirLeft},{moveDirRight} is  satrt to move!");
            StartCoroutine("shakeHorizontalReverse");
            
        }
}
IEnumerator shakeHorizontalReverse()
{
    float deltaTime=0;
    while (deltaTime<shakeHorizontalActive){
    deltaTime = Time.time - activateTime;
    timestart = Time.time;
    startPosition = ilustrationOBG.transform.position;
    moveDir = moveDirLeft;
    Debug.Log($"{startPosition},{moveDir}{deltaTime} is  satrt to move!");
    InvokeRepeating("move",0,0.016f);
    yield return new WaitForSeconds(moveTimeInvok);
    moveDir = moveDirRight;
    Debug.Log($"{startPosition},{moveDir} is  satrt to move!");
    startPosition = ilustrationOBG.transform.position;
    timestart = Time.time;
    InvokeRepeating("move",0,0.016f);
    yield return new WaitForSeconds(moveTimeInvok);
    }
    StopCoroutine("moveDownReverse");
    deltaTime = 0;
    
}






















}



