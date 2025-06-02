using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField]
    private InputAction thrust;
    [SerializeField]
    private InputAction rotation;

    [Header("Thruster Settings")]
    [SerializeField]
    private float thrustAmount = 0f;

    [Header("Rotation Settings")]
    [SerializeField]
    private float rotationAmount = 0f;

    [Header("Audio Settings")]
    [SerializeField]
    private AudioSource RockeyAudioSource;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }

    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * thrustAmount * Time.fixedDeltaTime, ForceMode.Force);

            if (!RockeyAudioSource.isPlaying)
                RockeyAudioSource.Play(0);
        }
        else
        {
            RockeyAudioSource.Stop();
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput != 0)
        {
            rb.freezeRotation = true;
            transform.Rotate(Vector3.forward * -rotationInput * rotationAmount * Time.fixedDeltaTime);
            //rb.freezeRotation = false;
        }
        else
        {
            rb.freezeRotation = false;
            //you can use freezeRotation in else or you can use in the above one, either is good. But use only one, don't use both.
        }
    }
}
