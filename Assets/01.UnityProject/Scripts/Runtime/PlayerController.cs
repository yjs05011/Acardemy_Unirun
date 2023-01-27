using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float PLAYER_STEP_ON_Y_ANGLE_MIN = 0.7f;  //!< 45�� ����

    public AudioClip deathSound = default;
    public float jumpForce = default;

    private int jumpCount = default;
    private bool isGrounded = false;
    private bool isDead = false;


    #region Player's component
    private Rigidbody2D playerRigid = default;
    private Animator playerAni = default;
    private AudioSource playerAudio = default;
    #endregion      // Player's component

    // Start is called before the first frame update
    void Start()
    {
        // Set player's components
        playerRigid = gameObject.GetComponentMust<Rigidbody2D>();
        playerAni = gameObject.GetComponentMust<Animator>();
        playerAudio = gameObject.GetComponentMust<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Return. If player dead
        if(isDead == true) { return; }

        // { �÷��̾� ���� ���� ����
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            jumpCount++;
            // ����Ű ������ ���� �������� ������ ����
            playerRigid.velocity = Vector2.zero;

            playerRigid.AddForce(new Vector2(0, jumpForce));

            playerAudio.Play();
        }       // if: �÷��̾ ������ ��
        else if(Input.GetMouseButtonDown(0) && 0 < playerRigid.velocity.y)
        {
            playerRigid.velocity = playerRigid.velocity * 0.5f;
        }       // if: �÷��̾ ���߿� �� ���� ��

        playerAni.SetBool("Grounded", isGrounded);
        // } �÷��̾� ���� ���� ����

        // ���� ���� �ƴ� �� �׶��忡�� ����ϴ� ����
    }       // Update()

    //! Player die
    private void Die()
    {
        playerAni.SetTrigger("Die");

        playerAudio.clip = deathSound;
        playerAudio.Play();

        playerRigid.velocity = Vector2.zero;
        isDead = true;

        GameManager.instance.OnPlayerDead();
    }       // Die()

    //! Ʈ���� �浹 ���� ó���� ���� �Լ�
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("DeadZone") && isDead == false)
        {
            Die();
        }
    }

    //! �ٴڿ� ��Ҵ��� üũ�ϴ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (PLAYER_STEP_ON_Y_ANGLE_MIN < collision.contacts[0].normal.y)
        {
            isGrounded = true;
            jumpCount = 0;
        }       // if: 45�� ���� �ϸ��� ���� ���� ���
    }       // OnCollisionEnter2D()

    //! �ٴڿ��� ������� üũ�ϴ� �Լ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }       // OnCollisionExit2D()
}
