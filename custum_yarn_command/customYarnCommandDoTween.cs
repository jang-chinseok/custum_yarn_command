using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using DG.Tweening;

public class customYarnCommandDoTween : MonoBehaviour
{
    public DialogueRunner DR;
 
    void Start()
    {
        Vector2 center = new Vector2(Screen.width*0.5f,Screen.height*0.5f);
        GameObject.Find("center").transform.position=center;
        Vector2 left = new Vector2(Screen.width*0.25f,Screen.height*0.5f);
        GameObject.Find("left").transform.position=left;
        Vector2 right = new Vector2(Screen.width*0.75f,Screen.height*0.5f);
        GameObject.Find("right").transform.position=right;
        
        // 현재 이 함수들은 모두 스프라이트 렌더러를 조작하는 방식을 취하고 있음. 따라서, 배치-호출 되는 오브젝트는 모두 스프라이트 렌더러를가진 스프라이트여야만 함.
        DR.AddCommandHandler<GameObject,float,float,float>("move", move);
        DR.AddCommandHandler<GameObject,float,float,float,float>("rotate", rotate);
        DR.AddCommandHandler<string,string>("ObjectActive", ObjectActive);
        DR.AddCommandHandler<GameObject,float,float>("fade", fade);
        DR.AddCommandHandler<GameObject,Color,float>("changeColor", changeColor);
        DR.AddCommandHandler<string,string, GameObject>("createPrefab", createPrefab);
        DR.AddCommandHandler<GameObject>("destroyObject ", destroyObject );
        DR.AddCommandHandler<string>("displayImg",displayImg);
        DR.AddCommandHandler<string>("efect", efect);
        // DR.AddCommandHandler<string,float,float>("moveDown", moveDown);
        // DR.AddCommandHandler<string,float,float,float>("shakeHorizontal", shakeHorizontal);
    }

//===========오브젝트 움직임 관련 함수===========
    void move(GameObject objectName,float xPosition,float yPosition,float moveSpeed){ 
        //UI이미지 기반이 아니기 때문에, z값에 의한 거리변화가 존재함. 즉 z값으로 move하는 경우, 카메라에서부터 멀어짐.
        Vector2 positionNow = objectName.transform.position; // 현재 오브젝트의 좌표
        Vector2 FacingPosition = new Vector2(positionNow[0]+xPosition, positionNow[1]+yPosition); //입력받은 좌표값을 더함.
        objectName.transform.DOMove(FacingPosition, moveSpeed);//입력받은 값 만큼 움직인 좌표로 이동.
    }
    void rotate(GameObject objectName,float xAngle,float yAngle,float zAngle,float rotateSpeed){
        Vector3 angleNow = objectName.transform.position;// 현재 오브젝트의 각도
        Vector3 facingAngle = new Vector3(angleNow[0]+xAngle, angleNow[1]+yAngle, angleNow[2]+zAngle);//입력받은 좌표값을 더함.
        objectName.transform.DORotate(facingAngle, rotateSpeed);//입력받은 값 만큼 회전 이동.
    }
//=============오브젝트 조작 관련 함수==========
    void changeColor (GameObject objectName,Color color,float changeSpeed){ // 색 fade 함수.
        SpriteRenderer objectColor = objectName.GetComponent<SpriteRenderer>();
        objectColor.DOColor(color, changeSpeed);
    }
    void fade (GameObject objectName,float alpha,float fadeSpeed){ //알파값 fade 함수.
        SpriteRenderer objectColor = objectName.GetComponent<SpriteRenderer>();
        objectColor.DOFade(alpha, fadeSpeed);
    }
//==============오브젝트 엑티브 함수==============
    void ObjectActive(string objectName, string setMode){
        var objectis = GameObject.Find("Ilustration_System").transform.Find(objectName);
        if (setMode=="false") 
        {
            objectis.gameObject.SetActive(false);
            Debug.Log($"{setMode} is flase");
        }
        else if(setMode=="true")
        {
            objectis.gameObject.SetActive(true);
            Debug.Log($"{setMode} is ture");
        }
        else
            Debug.Log($"{setMode} is incorrect, it can be only True or False");
    }
//=============오브젝트 생성-삭제 함수=============
    void createPrefab(string prefabName, string position, GameObject gameObjectName=null){
        if (gameObjectName==null)
            gameObjectName = GameObject.Find("Ilustration_System");

        GameObject prefabGameObject =  Resources.Load<GameObject>($"prefab/{prefabName}");
        switch(position){
            case "left": 
                        Instantiate(prefabGameObject, gameObjectName.transform.Find("left").transform);
                        break;
            case "right": 
                        Instantiate(prefabGameObject, gameObjectName.transform.Find("right").transform);
                        break;
            case "center":
                        Instantiate(prefabGameObject, gameObjectName.transform.Find("center").transform);
                        break;
        }
    }
    void destroyObject  (GameObject gameObjectName){
        Destroy(gameObjectName,0);
    }
//==========이미지 조작 관련 함수===========
    void displayImg(string ImageName){
         // 일러스트 작은 사이즈로 생성. 
         // 일러스트 사이즈 점점 크게만들기.
         // 일러스트 알파값 페이드 인 하기.

    }
    // 일러스트 제거 커멘트 제작 필요.
    void efect(string EfectName){

    }
  
    void Update()
    {
        
    }










}
