using UnityEngine;

public class RollController : MonoBehaviour
{
    [SerializeField] private bool _isBroken = false;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private Axis _rotateAround;
    private AudioSource _audio;

    //[SerializeField] private 

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void Break()
    {
        _isBroken = true;
    }

    public void Rotate()
    {
        switch (_rotateAround)
        {
            case Axis.X:
                transform.Rotate(_rotationSpeed * Time.deltaTime, 0, 0);
                break;
            case Axis.Y:
                transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
                break;
            case Axis.Z:
                transform.Rotate(0, 0, _rotationSpeed * Time.deltaTime);
                break;
            case Axis.negativeX:
                transform.Rotate(-_rotationSpeed * Time.deltaTime, 0, 0);
                break;
            case Axis.negativeY:
                transform.Rotate(0, -_rotationSpeed * Time.deltaTime, 0);
                break;
            case Axis.negativeZ:
                transform.Rotate(0, 0, -_rotationSpeed * Time.deltaTime);
                break;

        }
        PlayAudio();
        
    }

    public void PlayAudio()
    {
        if (_isBroken) _audio.Play();
    }

    public enum Axis {
        X, Y, Z,
        negativeX, negativeY, negativeZ
    }
}
