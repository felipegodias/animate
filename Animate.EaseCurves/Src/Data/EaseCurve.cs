using System;
using Animate.Core.Interfaces;
using UnityEngine;

namespace Animate.EaseCurves.Data {

    /// <summary>
    /// </summary>
    [Serializable]
    public class EaseCurve : IEaseCurve {

        [SerializeField]
        private string name;

        [SerializeField]
        private AnimationCurve animationCurve;

        /// <summary>
        /// </summary>
        public string Name => this.name;

        #region IEaseCurve Members

        public float Evaluate(float progress) {
            return this.animationCurve.Evaluate(progress);
        }

        #endregion

    }

}