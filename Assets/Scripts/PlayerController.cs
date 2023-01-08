using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float moveSpeed;
    public float rotationSpeed;
    public float jumpForce;
    public float gravityScale;

    [HideInInspector]
    public Vector3 moveDirection;

    [HideInInspector]
    public CharacterController charController;
    private PlayerHealthController playerHealth;

    public Camera cam;

    public GameObject playerModel;
    private Animator anim;

    public GameObject jumpEffect;
    private bool canDoubleJump;
    private bool DoubleJump;

    public GameObject runEffect;
    private float runEffectTime = 0.2f;
    private float runEffectCounter;

    public bool isKnocking;
    public float knockBackLenght = .5f;
    private float knockBakcCounter;
    public Vector2 knockBackPower;

    public GameObject[] playerPieces;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        cam = Camera.main;

        charController = GetComponent<CharacterController>();
        playerHealth = GetComponent<PlayerHealthController>();
        anim = playerModel.GetComponent<Animator>();
    }

    void Update()
    {
        if (playerHealth.curHealth > 0)
        {
            if (!isKnocking)
            {
                float yStore = moveDirection.y;
                //moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
                moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
                moveDirection.Normalize();
                moveDirection = moveDirection * moveSpeed;
                moveDirection.y = yStore;

                if (charController.isGrounded)
                {
                    moveDirection.y = 0;
                    canDoubleJump = false;
                    DoubleJump = false;

                    if (Input.GetButtonDown("Jump") && !canDoubleJump)
                    {
                        moveDirection.y = jumpForce;
                        Instantiate(jumpEffect, transform.position, Quaternion.Euler(-90, 0, 0));
                        canDoubleJump = true;
                    }
                }

                if(!charController.isGrounded)
                {
                    if (Input.GetButtonDown("Jump") && canDoubleJump)
                    {
                        DoubleJump = true;
                        moveDirection.y = jumpForce;
                        Instantiate(jumpEffect, transform.position, Quaternion.Euler(-90, 0, 0));
                        canDoubleJump = false;
                    }
                }

                moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;

                //transform.position = transform.position + (moveDirection * moveSpeed * Time.deltaTime);

                charController.Move(moveDirection * Time.deltaTime);

                if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
                {
                    transform.rotation = Quaternion.Euler(0, cam.transform.rotation.eulerAngles.y, 0);
                    Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0, moveDirection.z));

                    //playerModel.transform.rotation = newRotation;
                    playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotationSpeed * Time.deltaTime);

                    if (charController.isGrounded)
                    {
                        RunEffect();
                    }
                }
            }

            if (isKnocking)
            {
                knockBakcCounter -= Time.deltaTime;

                float yStore = moveDirection.y;
                moveDirection = playerModel.transform.forward * -knockBackPower.x;
                moveDirection.y = yStore;

                if(charController.isGrounded)
                {
                    moveDirection.y = 0f;
                }

                charController.Move(moveDirection * Time.deltaTime);

                if (knockBakcCounter <= 0)
                {
                    isKnocking = false;
                }
            }
        }

        anim.SetBool("DoubleJump", DoubleJump);
        anim.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        anim.SetBool("Grounded", charController.isGrounded);
    }

    public void Knockback()
    {
        isKnocking = true;
        knockBakcCounter = knockBackLenght;
        moveDirection.y = knockBackPower.y;
        moveDirection.y += Physics.gravity.y * Time.deltaTime * gravityScale;
        charController.Move(moveDirection * Time.deltaTime);
    }

    private void RunEffect()
    {
        runEffectCounter -= Time.deltaTime;
        if(runEffectCounter <= 0)
        {
            Instantiate(runEffect, transform.position, Quaternion.Euler(-180, playerModel.transform.rotation.eulerAngles.y, 0));
            runEffectCounter = runEffectTime;
        }
    }
}
