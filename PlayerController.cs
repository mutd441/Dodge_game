using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;//�̵��� ����� rigidbody������Ʈ
    public float speed = 8f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()//��ũ��Ʈ�� ����� �� ó�� �� �ѹ� ����Ǵ� ��(�ʱ�ȭ�Լ�)
    {
        //������Ʈ������ ����+�־���°��� �پ��ִ� ��ũ��Ʈ�� �־��̱⶧���� ����
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Input Manager���ִ� Horizontal���� ������ ����(1,-1)
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        //����*�ӵ�
        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;
        //������� newŰ����
        Vector3 newVelocity = new Vector3(xSpeed, 0f, zSpeed);//������ȣ��
        playerRigidbody.linearVelocity = newVelocity;//��ü �̵����� velocity speed����ŭ�� �̵�

        /*
        if (Input.GetKey(KeyCode.UpArrow)==true)
        {
            //���� ����Ű �Է��� �����Ǹ� Z���⿡ ���ֱ� AddForce�� ����
            playerRigidbody.AddForce(0f, 0f, speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) == true)
        {
            //�Ʒ��� ����Ű �Է��� �����Ǹ� Z���⿡ ���ֱ� 
            playerRigidbody.AddForce(0f, 0f, -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            //������ ����Ű �Է��� �����Ǹ� X���⿡ ���ֱ� 
            playerRigidbody.AddForce(speed, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            //���� ����Ű �Է��� �����Ǹ� X���⿡ ���ֱ�
            playerRigidbody.AddForce(-speed, 0f, 0f);
        }
        */
    }
    public void Die()//�÷��̾ ������ ȣ��Ǵ� �Լ�
    {
         //this: �ش�Ŭ������ ����Ű�� ��ü
        gameObject.SetActive(false);  //gameObject�ش� ��ũ��Ʈ�� ����Ǿ��ִ� ������Ʈ (������ player)
        GameManager gameManager=FindFirstObjectByType<GameManager>();//GameMangaer��ũ��Ʈ(������Ʈ���)���� GameManager���� ù��°������Ʈ�� �޾ƿ�
        //gameManager ������ �Ҵ�  
        gameManager.EndGame();//Gamemanager��endgamce�Լ� ȣ��
        
    }
}
