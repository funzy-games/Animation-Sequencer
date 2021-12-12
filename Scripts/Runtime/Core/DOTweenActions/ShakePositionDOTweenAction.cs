﻿using System;
using DG.Tweening;
using UnityEngine;

namespace BrunoMikoski.AnimationSequencer
{
    [Serializable]
    public sealed class ShakePositionDOTweenAction : DOTweenActionBase
    {
        public override Type TargetComponentType => typeof(Transform);
        public override string DisplayName => "Shake Position";

        [SerializeField]
        private Vector3 strength;
        [SerializeField]
        private int vibrato = 10;
        [SerializeField]
        private float randomness = 90;
        [SerializeField]
        private bool snapping;
        [SerializeField]
        private bool fadeout = true;

        private Transform previousTarget;
        private Vector3 previousPosition;

        protected override Tweener GenerateTween_Internal(GameObject target, float duration)
        {
            previousTarget = target.transform;
            previousPosition = previousTarget.position;
            Tweener tween = target.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeout);

            return tween;
        }

        public override void ResetToInitialState()
        {
            if (previousTarget == null)
                return;
            
            previousTarget.position = previousPosition;
        }
    }
}
