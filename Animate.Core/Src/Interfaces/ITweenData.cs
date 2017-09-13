using Animate.Core.Events;

namespace Animate.Core.Interfaces {

    /// <summary>
    /// </summary>
    public interface ITweenData {

        /// <summary>
        /// </summary>
        float Time { get; }

        /// <summary>
        /// </summary>
        float Delay { get; }

        /// <summary>
        /// </summary>
        uint LoopCount { get; }

        /// <summary>
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        ITweenData SetTime(float time);

        /// <summary>
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        ITweenData SetDelay(float delay);

        /// <summary>
        /// </summary>
        /// <param name="loopCount"></param>
        /// <returns></returns>
        ITweenData SetLoopCount(uint loopCount);

        /// <summary>
        /// </summary>
        /// <param name="onTweenBegin"></param>
        /// <returns></returns>
        ITweenData AddOnTweenBegin(AnimateEvent onTweenBegin);

        /// <summary>
        /// </summary>
        /// <param name="onTweenUpdate"></param>
        /// <returns></returns>
        ITweenData AddOnTweenUpdate(AnimateEvent onTweenUpdate);

        /// <summary>
        /// </summary>
        /// <param name="onTweenEnd"></param>
        /// <returns></returns>
        ITweenData AddOnTweenEnd(AnimateEvent onTweenEnd);

    }

}