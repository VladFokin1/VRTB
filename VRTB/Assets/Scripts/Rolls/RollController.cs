using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class RollController : MonoBehaviour
{
    [SerializeField] private bool _isBroken = false;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private Axis _rotateAround;
    private AudioSource _audio;
    [SerializeField] private XRSocketInteractor _socket1;
    [SerializeField] private XRSocketInteractor _socket2;
    [SerializeField] private TaskManager _taskManager;

    //[SerializeField] private 

    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        if (!gameObject.name.Contains("BigRoll"))
        {
            _socket1.selectEntered.AddListener(FlagPlaced);
            _socket1.selectExited.AddListener(FlagRemoved);
            _socket2.selectEntered.AddListener(FlagPlaced);
            _socket2.selectExited.AddListener(FlagRemoved);
        }
        
    }

    private void FlagPlaced(SelectEnterEventArgs args)
    {
        // args.interactableObject - это объект, который вставили в сокет
        GameObject placedObject = args.interactableObject.transform.gameObject;
        Debug.Log($"В сокет вставлен объект: {placedObject.name}");
        if (_isBroken)
        {
            _taskManager.MarkTask(2, true);
        }
    }
    private void FlagRemoved(SelectExitEventArgs args)
    {
        if (_isBroken)
        {
            _taskManager.MarkTask(2, false);
        }
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
        if (_isBroken)
        {
            if (!_audio.isPlaying)
                _audio.Play();
        }
        
    }

    public enum Axis {
        X, Y, Z,
        negativeX, negativeY, negativeZ
    }
}
