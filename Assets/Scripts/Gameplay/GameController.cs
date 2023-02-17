using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Gameplay
{
    [DefaultExecutionOrder(-1)]
    public class GameController : MonoBehaviour
    {

        [SerializeField] private GameModel _gameModel;

        private void Start()
        {
            Schedule.SetModel<GameModel>(_gameModel);
        }


        void Update()
        {
            Schedule.Tick();
        }
    }
}

