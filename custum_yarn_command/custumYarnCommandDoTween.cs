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
        DR.AddCommandHandler<GameObject,float,float,float,float>("move", move);
        DR.AddCommandHandler<GameObject,float,float,float,float>("rotate", rotate);
        // DR.AddCommandHandler<string,string>("obejctActive", obejctActive);
        DR.AddCommandHandler<GameObject,float,float>("fade", fade);
        DR.AddCommandHandler<GameObject,Color,float>("changeColor", changeColor);
        // DR.AddCommandHandler<string,float,float>("moveDown", moveDown);
        // DR.AddCommandHandler<string,float,float,float>("shakeHorizontal", shakeHorizontal);
        // DR.AddCommandHandler<string, float>("testAnimation", testAnimation);
    }

    // Update is called once per frame
    void move(GameObject objectName,float xPosition,float yPosition,float zPosition,float moveSpeed){
        objectName.transform.DOMove(new Vector3(xPosition, yPosition,zPosition), moveSpeed);
    }
    void rotate(GameObject objectName,float xAngle,float yAngle,float zAngle,float rotateSpeed){
        objectName.transform.DORotate(new Vector3(xAngle, yAngle,zAngle), rotateSpeed);
    }
    void changeColor (GameObject objectName,Color color,float changeSpeed){
        SpriteRenderer objectColor = objectName.GetComponent<SpriteRenderer>();
        objectColor.DOColor(color, changeSpeed);
    }
    void fade (GameObject objectName,float alpah,float fadeSpeed){
        SpriteRenderer objectColor = objectName.GetComponent<SpriteRenderer>();
        objectColor.DOFade(alpah, fadeSpeed);
    }





    
    
    void Update()
    {
        
    }










}
