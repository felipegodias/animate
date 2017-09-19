namespace Animate.Core.Interfaces {

    /// <summary>
    /// </summary>
    public interface ITween {

        /// <summary>
        /// </summary>
        bool IsPlaying { get; }

        /// <summary>
        /// </summary>
        bool IsPaused { get; }

        /// <summary>
        /// </summary>
        void Play();

        /// <summary>
        /// </summary>
        void Pause();

        /// <summary>
        /// </summary>
        void Stop();

        /// <summary>
        /// </summary>
        void Restart();

        /// <summary>
        /// </summary>
        void Cancel();

    }

}