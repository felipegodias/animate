namespace Animate.Core.Interfaces {

    /// <summary>
    /// </summary>
    public interface IAnimation {

        /// <summary>
        /// </summary>
        /// <param name="tween"></param>
        void OnTweenBegin(ITween tween);

        /// <summary>
        /// </summary>
        /// <param name="tween"></param>
        void OnTweenLoopBegin(ITween tween);

        /// <summary>
        /// </summary>
        /// <param name="tween"></param>
        void OnTweenUpdate(ITween tween);

        /// <summary>
        /// </summary>
        /// <param name="tween"></param>
        void OnTweenLoopEnd(ITween tween);

        /// <summary>
        /// </summary>
        /// <param name="tween"></param>
        void OnTweenEnd(ITween tween);

    }

}