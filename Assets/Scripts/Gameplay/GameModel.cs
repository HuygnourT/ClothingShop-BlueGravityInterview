using System;
using System.Collections.Generic;
using UnityEngine;
using RPG.UI;


namespace RPG.Gameplay
{
    [System.Serializable]
    public class GameModel
    {
        public CharacterController Player;
        public InputController Input;
        public DialogUIController Dialog;

        Dictionary<GameObject, HashSet<string>> conversations = new Dictionary<GameObject, HashSet<string>>();

        public void RegisterConversation(GameObject owner, string id)
        {
            if (!conversations.TryGetValue(owner, out HashSet<string> ids))
                conversations[owner] = ids = new HashSet<string>();
            ids.Add(id);
        }
    }
}