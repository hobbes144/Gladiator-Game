using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();


    //-----------------ALTERED------------------

    [Header("Headbob")]
    [SerializeField] private Camera fpsCamera;
    [SerializeField] private GroundCheck groundCheck;
    [SerializeField] private float walkBobSpeed = 14.0f;
    [SerializeField] private float walkBobAmount = 0.5f;
    [SerializeField] private float sprintBobSpeed = 14.0f;
    [SerializeField] private float sprintBobAmount = 0.5f;
    private float defaultYPos = 0;
    private float timer = 0;
    //private GroundCheck gCheck;

    private float targetMovingSpeed = 0f;

    //------------------------------------------


    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }
       

        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        defaultYPos = (float)(gameObject.transform.position.y + 1.488); 

        handleBob();
    }

    //-----------------ALTERED------------------

    public void buffSpeed(float speedBuff)
    {
        speed += speedBuff;
        runSpeed += speedBuff;
    }

    void handleBob()
    {
        if (groundCheck.isGrounded && (rigidbody.velocity.x != 0 || rigidbody.velocity.z != 0))
        {
            timer += Time.deltaTime * (IsRunning ? sprintBobSpeed : walkBobSpeed);
            fpsCamera.transform.localPosition = new Vector3(
                fpsCamera.transform.localPosition.x,
                defaultYPos + Mathf.Sin(timer) * (IsRunning ? sprintBobAmount : walkBobAmount),
                fpsCamera.transform.localPosition.z
                );
        }
    }
}