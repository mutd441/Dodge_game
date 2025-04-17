using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRigidbody; // 이동에 사용할 리지드바디 컴포넌트
    public float speed = 8f; // 이동 속력

    //Dash스킬
    float dashDistance = 2f;
    bool isCool = false;//쿨타임 상태 아님(대쉬 사용가능)
    float dashCoolTime = 5f;//쿨타임이 몇초인지
    float dashCoolTimer = 0f;//대쉬 사용 후 얼마나 지났는지
    void Start() {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 playerRigidbody에 할당
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        // 수평과 수직 축 입력 값을 감지하여 저장
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
       


        // 실제 이동 속도를 입력 값과 이동 속력을 통해 결정
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        //방향키 방향으로 바라보기
        Vector3 moveDirection = new Vector3(xInput, 0f, zInput);
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

        // 스페이스바 누르면 순간 대쉬
        if(!isCool)//쿨타임상태가 아닐 때(대쉬사용가능)
        {
            if (Input.GetKeyDown(KeyCode.Space) && moveDirection != Vector3.zero)
            {
                transform.position += moveDirection.normalized * dashDistance;
                isCool = true;//쿨타임 상태 돌입
                dashCoolTimer = 0f;
                

            }
        }
        else//쿨타임 상태일 때 (대쉬사용 불가능)
        {
            dashCoolTimer += Time.deltaTime;//타이머 시간증가
            switch (dashCoolTimer)
            {
                case 1:
                    Debug.Log("스킬사용까지 4초");
                    break;

                case 2:
                    Debug.Log("스킬사용까지 3초");
                    break;

                case 3:
                    Debug.Log("스킬사용까지 2초");
                    break;

                case 4:
                    Debug.Log("스킬사용까지 1초");
                    break;

            }
            if (dashCoolTimer >= dashCoolTime)
            {
                isCool = false;
                Debug.Log("스킬 준비 완료!");
            }

            if (Input.GetKeyDown(KeyCode.Space) && moveDirection != Vector3.zero)
            {
                Debug.Log("쿨타임 중! 사용 불가");
            }
        }



            // Vector3 속도를 (xSpeed, 0, zSpeed)으로 생성
            Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);
        // 리지드바디의 속도에 newVelocity를 할당
        playerRigidbody.linearVelocity = newVelocity;
    }

    public void Die() {
        // 자신의 게임 오브젝트를 비활성화
        gameObject.SetActive(false);

        // 씬에 존재하는 GameManager 타입의 오브젝트를 찾아서 가져오기
        GameManager gameManager = FindObjectOfType<GameManager>();
        // 가져온 GameManager 오브젝트의 EndGame() 메서드 실행
        gameManager.EndGame();
    }
}