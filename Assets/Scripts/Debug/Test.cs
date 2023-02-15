using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Events;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Schedule.Add<ShowConversation>(0);
        Schedule.Add<StopTalking>(1f);
        Schedule.Add<ShowConversation>(1f);
        Schedule.Add<StopTalking>(1.1f);
    }
}
