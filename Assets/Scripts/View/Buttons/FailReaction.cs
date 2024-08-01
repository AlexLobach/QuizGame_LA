using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using View;

namespace View
{
    [RequireComponent(typeof(Button))]
    public class FailReaction : MonoBehaviour, IButtonEffect
    {
        [SerializeField] private bool use = true;
        private float durationEffect = 0.8f;
        private float   durationPause = 0.3f;        
        private Tween currentTween;
        private Vector3 punchPosition;

        void Awake()
        {
            punchPosition = new Vector3 (20,0,0) ;
        }
        
        public void Notify(bool correct)
        {
            if (!use || correct)
            {
                return;
            }    

            currentTween?.Kill();
            currentTween = DOTween.Sequence()            
            .AppendInterval(durationPause)
            .Append(transform.DOPunchPosition(punchPosition, durationEffect, 10, 3));
        }
    }
}
