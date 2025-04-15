using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    private Dictionary<int, bool> _tasks;
    [SerializeField] private Toggle[] _taskCheckboxes = new Toggle[3];

    private void Start()
    {
        _tasks = new Dictionary<int, bool>();
        for (int i = 0; i < 3; i++)
        {
            _tasks.Add(i, false);
        }
    }
    

    public void MarkTask(int number, bool isCompleted)
    {
        _tasks[number] = isCompleted;
        _taskCheckboxes[number].isOn = isCompleted;
    }

}
