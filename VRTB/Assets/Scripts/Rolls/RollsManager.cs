using UnityEngine;

public class RollsManager : MonoBehaviour
{
    [SerializeField] private RollController[] _rolls;
    [SerializeField] private Animator _beltAnim;
    [SerializeField] private bool _isEnabled = false;

    private void Awake()
    {
        int randNumber = Random.Range(1, 3);
        for (int i = 0; i < randNumber; i++)
        {
            int randIndex = Random.Range(0, _rolls.Length);
            Debug.Log(randIndex);
            _rolls[i].Break();
        }
    }

    public void Enable()
    {
        _isEnabled = true;
        _beltAnim.SetBool("Enabled", true);
    }
    public void Disable()
    {
        _isEnabled = false;
        _beltAnim.SetBool("Enabled", false);
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
