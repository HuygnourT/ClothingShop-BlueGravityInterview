using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Gameplay
{
    [System.Serializable]
    public struct ConversationPiece
    {
        public string id;
        [Multiline]
        public string text;
        public Sprite image;
        public AudioClip audio;
        public List<ConversationOption> options;
    }
}