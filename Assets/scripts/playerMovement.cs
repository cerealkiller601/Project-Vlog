using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    Rigidbody rb;
    public Vector3 Inputi;
    public float speed;
    public float sprintboost;
    public Animator anim;
    public Camera mainCam;

    [Header("AnimationPlayGround")]
    public float animSprintSpeed;
    public float animWalkSpeed;

    [Header("misc")]
    private float timer = 2.4f;
    public TextMeshProUGUI accessibilityTxt;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //moveAround = InputSystem.actions.FindAction("Move");
        anim = GetComponent<Animator>();
        //lookAround = InputSystem.actions.FindAction("lookAround");
        timer = Time.deltaTime;
    }

    void Start()
    {

    }

    void Update()
    {

        //Accessibility
        if(timer<=0)
        {
            accessibilityTxt.text = " ";
        }




        //Accessibility
        Inputi = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Inputi.x != 0 || Inputi.z != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Keyboard.current.leftShiftKey.wasPressedThisFrame)
        {
            speed += sprintboost;
            anim.SetFloat("speed", animSprintSpeed);
        }

        else if(Keyboard.current.leftShiftKey.wasReleasedThisFrame)
        {
            speed -= sprintboost;
            anim.SetFloat("speed", animWalkSpeed);
        }

        Debug.Log(timer);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Inputi*speed);
    }
}