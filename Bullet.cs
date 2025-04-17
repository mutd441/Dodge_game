using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 8f;//ź�̵��ӷ�
    private Rigidbody bulletRigidbody;

    void Start()
    {
        //�̽�ũ��Ʈ�� �پ��ִ� ������Ʈ�� ������ٵ� ������Ʈ �Ҵ�
        bulletRigidbody = GetComponent<Rigidbody>();
        //
        bulletRigidbody.linearVelocity = transform.forward * speed;
    }
    // Ʈ���� �浹 �� �ڵ����� ����Ǵ� �޼���
    private void OnTriggerEnter(Collider other)
    {
        //�浹�� ��� ������Ʈ�� �±װ� player���..
        if(other.tag=="Player")//==> .tag �±��̸�
        {
            //���� Gameobject���� PlayerController ������Ʈ(��ũ��Ʈ) ��������
            PlayerController playerController =
                other.GetComponent<PlayerController>();//other�� �ٸ� ������Ʈ�� ���� ������Ʈ �������⶧�� �ڽŰŴ� �׳� getcomponent ,<>�ȿ��� Ÿ���̸�
            //��ũ��Ʈ�� �������µ� �����ߴٸ�
            if(playerController!=null)
            {
                //Die()ȣ���ؼ� �÷��̾� ��Ȱ��ȭ ��Ű��
                playerController.Die();
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
