// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using Yarn.Unity;

// public class custum_yarn_command : MonoBehaviour
// {



//     private void Awake() {
        
//     }
//     [YarnCommand("palceIlustraion")]// 일러스트 배치 커멘드
//     public void palceIlustraion(string ilustration, float xPoition = 0F ,float yPosition = 0, float zPosition=0F)
//                                 //배치시킬 오브젝트 이름 , 배치시킬 x축 위치,   배치시킬 y축 위치,     배치시킬 Y축 위치.
//     {
//         // 일러스트 경로를 입력받고 입력받은 일러스트를 배치시키기.
//         // GameObject ilustrationOBG = GameObject.Find (ilustration);
//         // Instantiate(ilustrationOBG); 
//         // rectTransform = GetComponent<ilustrationOBG.RectTransform>();
//         // ilustrationOBG.transform.position = (xPoition ,yPosition, zPosition);
    
//     }   

//     [YarnCommand("moveIlustration")] // 일러스트 움직임 조작 커맨드
//     public void moveIlustration(
//         float xRatation = 0F ,   //회전할일 축 각도
//         float yRotation = 0F , 
//         float zRotation = 0F, 
//         float rotateSpeed = 1F,   // 회전속도
//         float xMove = 0F,     // 움직일 축 길이
//         float yMove = 0F,
//         float zMove = 0F,
//         float moveSpeed = 0F   // 움직임 속도
//         )
//     {   
//        Debug.Log($"{name} is leaping!");
//         // 일러스트에 대한 움직임. 
//         Vector3 moveDir = new Vector3(xMove, yMove, zMove);
//         Vector3 moveAngle = new Vector3(xRatation,yRotation,zRotation);
//         transform.rotation = Quaternion.Euler(moveAngle);
//         transform.Translate(moveDir);
//     }

// }




