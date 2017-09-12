using Animate.Core.Events;

namespace Animate.Core.Interfaces {

    /// <summary>
    /// </summary>
    public interface ITweenData : ITween {

        /// <summary>
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        ITweenData SetTime(float time);

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