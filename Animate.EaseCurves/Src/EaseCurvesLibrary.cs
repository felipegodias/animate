using System.Collections.Generic;
using Animate.Core.Interfaces;
using Animate.EaseCurves.Data;
using UnityEngine;

namespace Animate.EaseCurves {

    /// <summary>
    /// </summary>
    [CreateAssetMenu(fileName = nameof(EaseCurvesLibrary), menuName = nameof(Animate) + "/" + nameof(EaseCurvesLibrary))]
    public class EaseCurvesLibrary : ScriptableObject {

        private static EaseCurvesLibrary easeCurvesLibrary;

        private static IDictionary<string, IEaseCurve> easeCurvesInCache;

        [SerializeField]
        private EaseCurve[] easeCurves;

        private static EaseCurvesLibrary Instance {
            get {
                if (easeCurvesLibrary != null) {
                    return easeCurvesLibrary;
                }

                easeCurvesLibrary = Resources.Load<EaseCurvesLibrary>(nameof(EaseCurvesLibrary));
                return easeCurvesLibrary;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="easeCurveName"></param>
        /// <returns></returns>
        public static IEaseCurve GetEaseCurve(string easeCurveName) {
            if (easeCurvesInCache != null) {
                return !easeCurvesInCache.ContainsKey(easeCurveName) ? null : easeCurvesInCache[easeCurveName];
            }

            easeCurvesInCache = new Dictionary<string, IEaseCurve>();
            EaseCurve[] easeCurves = Instance.easeCurves;
            foreach (EaseCurve easeCurve in easeCurves) {
                easeCurvesInCache.Add(easeCurve.Name, easeCurve);
            }

            return !easeCurvesInCache.ContainsKey(easeCurveName) ? null : easeCurvesInCache[easeCurveName];
        }

    }

}