namespace Animate.Core.Internal.Interfaces {

    /// <summary>
    /// </summary>
    internal interface ITweenRuntime {

        /// <summary>
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// </summary>
        void Lock();

        /// <summary>
        /// </summary>
        void Unlock();

        /// <summary>
        /// </summary>
        /// <param name="deltaTime"></param>
        void Update(float deltaTime);

    }

}