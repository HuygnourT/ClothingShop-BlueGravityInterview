using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Gameplay
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private ConversationScript[] conversations;

        GameModel mGameModel;

        void Start()
        {
            mGameModel = Schedule.GetModel<GameModel>();
        }


        public void OnCollisionEnter2D(Collision2D collision)
        {
            var conversation = GetConversation();

            if (conversation != null)
            {
                var ev = Schedule.Add<Events.ShowConversation>();
                ev.conversation = conversation;
                ev.npc = this;
                ev.gameObject = gameObject;
                ev.conversationItemKey = "";
            }
        }


        ConversationScript GetConversation()
        {
            return conversations[0];
        }
    }
}