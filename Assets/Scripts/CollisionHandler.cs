using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float delayTimeReloadScene = 2f;

    [Header("Audio Settings")]
    [SerializeField] private AudioClip CrashSoundClip;
    [SerializeField] private AudioClip SuccessSoundClip;

    [Header("FX Settings")]
    [SerializeField] private ParticleSystem ExplorosionParticle;
    [SerializeField] private ParticleSystem SuccessParticle;

    private AudioSource _audioSource;
    private bool isControllable = true;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isControllable) return;

        switch (collision.gameObject.tag)
        {
            case ("Friendly"):
                break;
            case ("Finish"):
                _audioSource.Stop();
                StartLoadNextSceneSequence();
                _audioSource.PlayOneShot(SuccessSoundClip);
                SuccessParticle.Play();
                break;
            default: //collide with something bad
                _audioSource.Stop();
                StartCrashSequence();
                _audioSource.PlayOneShot(CrashSoundClip);
                ContactPoint contactPoint = collision.GetContact(0);
                ExplorosionParticle.transform.position = contactPoint.point;
                ExplorosionParticle.Play();
                break;
        }
    }

    private void StartCrashSequence()
    {
        GetComponent<Movement>().enabled = false;
        isControllable = false;
        InvokeMethod("ReloadScene");
    }

    private void StartLoadNextSceneSequence()
    {
        GetComponent<Movement>().enabled = false;
        isControllable = false;
        InvokeMethod("LoadNextScene");
    }

    private void InvokeMethod(string methodName)
    {
        Invoke(methodName, delayTimeReloadScene);
    }

    private void ReloadScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.LogWarning($"Current Scene {currentScene}");
        SceneManager.LoadScene(currentScene);
    }

    private void LoadNextScene()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.LogWarning($"Next Scene {nextScene}");
        if (nextScene == SceneManager.sceneCountInBuildSettings)
        {
            nextScene = 0;
        }

        SceneManager.LoadScene(nextScene);
    }
}
