using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Gameplay
{
    public class GameController : MonoBehaviour
    {
        void Update()
        {
            Schedule.Tick();
        }
    }
}

