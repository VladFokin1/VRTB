using UnityEngine;

public class RollsManager : MonoBehaviour
{
    [SerializeField] private RollController[] _rolls;
    [SerializeField] private Animator _beltAnim;
    [SerializeField] private AudioSource _beltAudio;
    [SerializeField] public bool _isEnabled = false;
    [SerializeField] public TaskManager _taskManager;
    public AudioSource errorSound;

    

    private void Awake()
    {
            int randIndex = Random.Range(0, 4);
            Debug.Log(randIndex);
            _rolls[randIndex].Break();
    }


    public void Enable()
    {
        if (_taskManager.CheckThirdAllowed())
        {
            if (!_isEnabled)
            {
                _isEnabled = true;
                _beltAnim.SetTrigger("Enable");
                _beltAudio.Play();
            }

        }
        else
        {
            errorSound.Play();
        }
    }
    public void Disable()
    {
        if (_isEnabled)
        {
            _isEnabled = false;
            _beltAnim.SetTrigger("Disable");
            _beltAudio.Stop();
        }
    }

    private void Update()
    {
        if (_isEnabled)
        {
            foreach (RollController roll in _rolls)
            {
                roll.Rotate();
            }
        }
    }
}
