using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;//이동에 사용할 rigidbody컴포넌트
    public float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()//스크립트가 실행될 때 처음 딱 한번 실행되는 것(초기화함수)
    {
        //컴포넌트정보를 얻어옴+주어가없는것은 붙어있는 스크립트가 주어이기때문에 생략
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input Manager에있는 Horizontal에서 방향을 얻어옴(1,-1)
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        //방향*속도
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        //생성방법 new키워드
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);//생성자호출
        playerRigidbody.linearVelocity = newVelocity;//실체 이동구현 velocity speed값만큼만 이동

        /*
        if (Input.GetKey(KeyCode.UpArrow)==true)
        {
            //위쪽 방향키 입력이 감지되면 Z방향에 힘주기 AddForce는 가속
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            //아래쪽 방향키 입력이 감지되면 Z방향에 힘주기 
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            //오른쪽 방향키 입력이 감지되면 X방향에 힘주기 
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            //왼쪽 방향키 입력이 감지되면 X방향에 힘주기
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        */
    }
    public void Die()//플레이어가 죽으면 호출되는 함수
    {
         //this: 해당클래스를 가리키는 객체
        gameObject.SetActive(false);  //gameObject해당 스크립트가 적용되어있는 오브젝트 (지금은 player)
        GameManager gameManager=FindFirstObjectByType<GameManager>();//GameMangaer스크립트(컴포넌트취급)에서 GameManager형인 첫번째오브젝트를 받아와
        //gameManager 변수에 할당  
        gameManager.EndGame();//Gamemanager의endgamce함수 호출
        
    }
}
