namespace Animate.Core.Interfaces {

    /// <summary>
    /// </summary>
    public interface IAnimation {

        /// <summary>
        /// </summary>
        /// <param name="tweenRuntime"></param>
        void OnTweenBegin(ITweenRuntime tweenRuntime);

        /// <summary>
        /// </summary>
        /// <param name="tweenRuntime"></param>
        void OnTweenLoopBegin(ITweenRuntime tweenRuntime);

        /// <summary>
        /// </summary>
        /// <param name="tweenRuntime"></param>
        void OnTweenUpdate(ITweenRuntime tweenRuntime);

        /// <summary>
        /// </summary>
        /// <param name="tweenRuntime"></param>
        void OnTweenLoopEnd(ITweenRuntime tweenRuntime);

        /// <summary>
        /// </summary>
        /// <param name="tweenRuntime"></param>
        void OnTweenEnd(ITweenRuntime tweenRuntime);

    }

}