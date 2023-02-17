using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using RPG.Gameplay;


namespace RPG.Events
{
    public class ShowConversation : Event<ShowConversation>
    {
        public NPCController npc;
        public GameObject gameObject;
        public ConversationScript conversation;
        public string conversationItemKey;

        public override void Execute()
        {
            ConversationPiece ci;
            //default to first conversation item if no key is specified, else find the right conversation item.
            if (string.IsNullOrEmpty(conversationItemKey))
                ci = conversation.items[0];
            else
                ci = conversation.Get(conversationItemKey);


            //calculate a position above the player's sprite.
            var position = gameObject.transform.position;
            var sr = gameObject.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                position += new Vector3(0, 2 * sr.size.y + (ci.options.Count == 0 ? 0.1f : 0.2f), 0);
            }

            //show the dialog
            model.Dialog.Show(position, ci.text);
            var animator = gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Talk", true);
                var ev = Schedule.Add<StopTalking>(2);
                //ev.animator = animator;
            }


            //if this conversation item has an id, register it in the model.
            if (!string.IsNullOrEmpty(ci.id))
                model.RegisterConversation(gameObject, ci.id);

            //setup conversation choices, if any.
            if (ci.options.Count == 0)
            {
                //do nothing
            }
            else
            {
                //Create option buttons below the dialog.
                for (var i = 0; i < ci.options.Count; i++)
                {
                    model.Dialog.SetButton(i, ci.options[i].text);
                }

                //if user pickes this option, schedule an event to show the new option.
                model.Dialog.onButton += (index) =>
                {
                    //hide the old text, so we can display the new.
                    model.Dialog.Hide();

                    //This is the id of the next conversation piece.
                    var next = ci.options[index].targetId;

                    //Make sure it actually exists!
                    if (conversation.ContainsKey(next))
                    {
                        //find the conversation piece object and setup a new event with correct parameters.
                        var c = conversation.Get(next);
                        var ev = Schedule.Add<ShowConversation>(0.25f);
                        ev.conversation = conversation;
                        ev.gameObject = gameObject;
                        ev.conversationItemKey = next;
                    }
                    else
                    {
                        Debug.LogError($"No conversation with ID:{next}");
                    }
                };

            }

            model.Dialog.SetIcon(ci.image);
        }
    }
}

