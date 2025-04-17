using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 8f;//탄이동속력
    private Rigidbody bulletRigidbody;

    void Start()
    {
        //이스크립트가 붙어있는 오브젝트의 리지드바디 컴포넌트 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //
        bulletRigidbody.linearVelocity = transform.forward * speed;
    }
    // 트리거 충돌 시 자동으로 실행되는 메서드
    private void OnTriggerEnter(Collider other)
    {
        //충돌한 상대 오브젝트의 태그가 player라면..
        if(other.tag=="Player")//==> .tag 태그이름
        {
            //상대방 Gameobject에서 PlayerController 컴포넌트(스크립트) 가져오기
            PlayerController playerController =
                other.GetComponent<PlayerController>();//other는 다른 오브젝트에 붙은 컴포넌트 가져오기때문 자신거는 그냥 getcomponent ,<>안에는 타입이름
            //스크립트를 가져오는데 성공했다면
            if(playerController!=null)
            {
                //Die()호출해서 플레이어 비활성화 시키기
                playerController.Die();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
