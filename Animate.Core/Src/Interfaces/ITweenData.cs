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
        float StartDelay { get; }

        /// <summary>
        /// </summary>
        float LoopDelay { get; }

        /// <summary>
        /// </summary>
        uint LoopCount { get; }

        LoopType LoopType { get; }

        /// <summary>
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        ITweenData SetTime(float time);

        /// <summary>
        /// </summary>
        /// <param name="startDelay"></param>
        /// <returns></returns>
        ITweenData SetStartDelay(float startDelay);

        /// <summary>
        /// </summary>
        /// <param name="loopDelay"></param>
        /// <returns></returns>
        ITweenData SetLoopDelay(float loopDelay);

        /// <summary>
        /// </summary>
        /// <param name="loopCount"></param>
        /// <returns></returns>
        ITweenData SetLoopCount(uint loopCount);

        /// <summary>
        /// </summary>
        /// <param name="loopType"></param>
        /// <returns></returns>
        ITweenData SetLoopType(LoopType loopType);

        /// <summary>
        /// </summary>
        /// <param name="onTweenBegin"></param>
        /// <returns></returns>
        ITweenData AddOnTweenBegin(AnimateEvent onTweenBegin);

        /// <summary>
        /// </summary>
        /// <param name="onTweenLoopBegin"></param>
        /// <returns></returns>
        ITweenData AddOnTweenLoopBegin(AnimateEvent onTweenLoopBegin);

        /// <summary>
        /// </summary>
        /// <param name="onTweenUpdate"></param>
        /// <returns></returns>
        ITweenData AddOnTweenUpdate(AnimateEvent onTweenUpdate);

        /// <summary>
        /// </summary>
        /// <param name="onTweenLoopEnd"></param>
        /// <returns></returns>
        ITweenData AddOnTweenLoopEnd(AnimateEvent onTweenLoopEnd);

        /// <summary>
        /// </summary>
        /// <param name="onTweenEnd"></param>
        /// <returns></returns>
        ITweenData AddOnTweenEnd(AnimateEvent onTweenEnd);

        /// <summary>
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        ITweenData AddAnimation(IAnimation animation);

    }

}