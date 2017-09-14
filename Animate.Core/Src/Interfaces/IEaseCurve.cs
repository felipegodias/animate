namespace Animate.Core.Interfaces {

    /// <summary>
    /// </summary>
    public interface IEaseCurve {

        /// <summary>
        /// </summary>
        /// <param name="progress"></param>
        /// <returns></returns>
        float Evaluate(float progress);

    }

}