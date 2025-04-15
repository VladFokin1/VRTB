using UnityEngine;

public class RollsManager : MonoBehaviour
{
    [SerializeField] private RollController[] _rolls;
    [SerializeField] private Animator _beltAnim;
    [SerializeField] private AudioSource _beltAudio;
    [SerializeField] private bool _isEnabled = false;

    

    private void Awake()
    {


            int randIndex = Random.Range(0, 4);
            Debug.Log(randIndex);
            _rolls[randIndex].Break();
  
    }

    private void Start()
    {
        _beltAnim.SetTrigger("Enable");
    }

    public void Enable()
    {
        _isEnabled = true;
        _beltAnim.SetTrigger("Enable");
        _beltAudio.Play();
    }
    public void Disable()
    {
        _isEnabled = false;
        _beltAnim.SetTrigger("Disable");
        _beltAudio.Stop();

    }

    private void Update()
    {
        if (_isEnabled)
        {
            #region Delete later
            

            if (!_beltAudio.isPlaying)
            {
                _beltAudio.Play();
            }
            #endregion
            foreach (RollController roll in _rolls)
            {
                roll.Rotate();
            }
        }
    }
}
