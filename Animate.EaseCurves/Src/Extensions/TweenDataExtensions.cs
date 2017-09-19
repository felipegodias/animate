using Animate.Core.Interfaces;

namespace Animate.EaseCurves.Extensions {

    /// <summary>
    /// </summary>
    public static class TweenDataExtensions {

        /// <summary>
        /// </summary>
        /// <param name="tweenData"></param>
        /// <param name="easeCurveName"></param>
        /// <returns></returns>
        public static ITweenData SetEaseCurve(this ITweenData tweenData, string easeCurveName) {
            IEaseCurve easeCurve = EaseCurvesLibrary.GetEaseCurve(easeCurveName);
            return tweenData.SetEaseCurve(easeCurve);
        }

    }

}