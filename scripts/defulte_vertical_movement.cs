using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class defulte_vertical_movement : MonoBehaviour
{
    public float moveScale = 100; // 상하 이동 범위 외부에서 수정 가능한 테스트 숫자. 조정후 fix된 값이 생기면 그 값으로 고정 예정.
    public float moveTime = 3; // 상하 이동 속도
    Vector3 startLocation; // 오브젝트의 이동 시작 위치
    bool moveDiraction = true; // 오브젝트가 움직이는 방향
    Vector3 moveDir;  // 오브젝트가 이동할 좌표
    public GameObject objcet; // 오브젝트 저장용 전역함수
    float DeltaTime = 0;
    void Start()
    {
        startLocation = this.transform.position; //게임 시작시의 오브젝트의 위치.
        // 오브젝트가 이동할 방향좌표설정. (오브젝트의 현재, x, z좌표는 고정, Y좌표만이 지정된 길이만큼 멀리 설정)
        moveDir = new Vector3(this.transform.position[0],this.transform.position[1]+moveScale, this.transform.position[2]);
        
    }

    // Update is called once per frame
    void Update()
    {   
        
        Vector3 vector3Now =  this.transform.position; // 오브젝트의 현재 위치 업데이트
        if (moveDiraction == true){ // 정방향이동
            DeltaTime += Time.deltaTime;
            this.transform.position = Vector3.Lerp (startLocation, moveDir, DeltaTime/moveTime);
            Debug.Log($"{moveDir[1]- vector3Now[1]}현재 값");
            
            if(DeltaTime>moveTime){ //거의 다 도착하면 역방향이동으로 전환
                DeltaTime = 0;
                Vector3 nextMovePosition = startLocation;
                startLocation = moveDir;
                moveDir = nextMovePosition;
                moveDiraction = false;    //거의 다 도착하면 역방향이동으로 전환
            }
        }
        else { // 역방향 이동.
            DeltaTime += Time.deltaTime;
            this.transform.position = Vector3.Lerp (startLocation, moveDir, DeltaTime/moveTime);
            Debug.Log($"{DeltaTime}현재 값");
            if(DeltaTime>moveTime){  //거의 다 도착하면 정방향 이동으로 전환
                Debug.Log($"{moveDir[1]- vector3Now[1]}현재 값");
                DeltaTime =0;
                Vector3 nextMovePosition = startLocation;
                startLocation = moveDir;
                moveDir = nextMovePosition;
                moveDiraction = true;  // 정방향이동
            }
        }
        Debug.Log($"{moveDiraction}현재 움직이는 방향");
        
    }

   
}
