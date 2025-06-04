using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotation;

    [Header("Thruster Settings")]
    [SerializeField] private float thrustAmount = 0f;
    [SerializeField] private ParticleSystem ThrustParticle;
    [SerializeField] private ParticleSystem LeftThrustParticle;
    [SerializeField] private ParticleSystem RightThrustParticle;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationAmount = 0f;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource RockeyAudioSource;
    [SerializeField] private AudioClip MainEngineSoundClip;

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
                RockeyAudioSource.PlayOneShot(MainEngineSoundClip);

            if (!ThrustParticle.isPlaying)
                ThrustParticle.Play();
        }
        else
        {
            RockeyAudioSource.Stop();
            ThrustParticle.Stop();
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

            if (rotationInput < 0 && !LeftThrustParticle.isPlaying)
            {
                RightThrustParticle.Stop();
                LeftThrustParticle.Play();
            }
            else if (rotationInput > 0 && !RightThrustParticle.isPlaying)
            {
                LeftThrustParticle.Stop();
                RightThrustParticle.Play();
            }
        }
        else
        {
            rb.freezeRotation = false;
            LeftThrustParticle.Stop();
            RightThrustParticle.Stop();
            //you can use freezeRotation in else or you can use in the above one, either is good. But use only one, don't use both.
        }
    }

    void OnDisable()
    {
        RockeyAudioSource.Stop();

        ThrustParticle.Stop();
        LeftThrustParticle.Stop();
        RightThrustParticle.Stop();
    }
}
