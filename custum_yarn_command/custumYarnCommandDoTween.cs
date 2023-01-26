using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using DG.Tweening;

public class custumYarnCommandDoTween : MonoBehaviour
{

    public DialogueRunner DR;
    // Start is called before the first frame update
    void Start()
    {

        // 현재 이 함수들은 모두 스프라이트 렌더러를 조작하는 방식을 취하고 있음. 따라서, 배치-호출 되는 오브젝트는 모두 스프라이트 렌더러를가진 스프라이트여야만 함.
        DR.AddCommandHandler<GameObject,float,float,float,float>("move", move);
        DR.AddCommandHandler<GameObject,float,float,float,float>("rotate", rotate);
        DR.AddCommandHandler<string,string>("obejctActive", obejctActive);
        DR.AddCommandHandler<GameObject,float,float>("fade", fade);
        DR.AddCommandHandler<GameObject,Color,float>("changeColor", changeColor);
        DR.AddCommandHandler<string, GameObject>("createPrefeb", createPrefeb);
        DR.AddCommandHandler<GameObject>("distroyPrefab", distroyPrefab);
        // DR.AddCommandHandler<string,float,float>("moveDown", moveDown);
        // DR.AddCommandHandler<string,float,float,float>("shakeHorizontal", shakeHorizontal);

    }

    // Update is called once per frame
    void move(GameObject objectName,float xPosition,float yPosition,float zPosition,float moveSpeed){ 
        //UI이미지 기반이 아니기 때문에, z값에 의한 거리변화가 존재함. 즉 z값으로 move하는 경우, 
        Vector3 positionNow = objectName.transform.position; // 현재 오브젝트의 좌표
        Vector3 FacingPosition = new Vector3(positionNow[0]+xPosition, positionNow[1]+yPosition, positionNow[2]+zPosition); //입력받은 좌표값을 더함.
        objectName.transform.DOMove(FacingPosition, moveSpeed);//입력받은 값 만큼 움직인 좌표로 이동.
    }
    void rotate(GameObject objectName,float xAngle,float yAngle,float zAngle,float rotateSpeed){
        Vector3 angleNow = objectName.transform.position;// 현재 오브젝트의 각도
        Vector3 facingAngle = new Vector3(angleNow[0]+xAngle, angleNow[1]+yAngle, angleNow[2]+zAngle);//입력받은 좌표값을 더함.
        objectName.transform.DORotate(facingAngle, rotateSpeed);//입력받은 값 만큼 회전 이동.
    }
    void changeColor (GameObject objectName,Color color,float changeSpeed){ // 색 fade 함수.
        SpriteRenderer objectColor = objectName.GetComponent<SpriteRenderer>();
        objectColor.DOColor(color, changeSpeed);
    }
    void fade (GameObject objectName,float alpah,float fadeSpeed){ //알파값 fade 함수.
        SpriteRenderer objectColor = objectName.GetComponent<SpriteRenderer>();
        objectColor.DOFade(alpah, fadeSpeed);
    }
    // 오브젝트 엑티브 함수
    void obejctActive(string objectName, string setMode){
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

    void createPrefeb(string prefabName, GameObject gameObjectName=null){
        if (gameObjectName==null)
            gameObjectName = GameObject.Find("Ilustration_System");
        GameObject prefabGameObject =  Resources.Load<GameObject>("Prefeb/amber");
        Instantiate(prefabGameObject, gameObjectName.transform);
    }
    void distroyPrefab (GameObject gameObjectName){

        Destroy(gameObjectName,0);
    }



    
    
    void Update()
    {
        
    }










}
