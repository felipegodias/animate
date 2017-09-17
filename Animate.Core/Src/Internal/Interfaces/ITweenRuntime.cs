namespace Animate.Core.Internal.Interfaces {

    /// <summary>
    /// </summary>
    internal interface ITweenRuntime {

        /// <summary>
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// </summary>
        void StartUpdate();

        /// <summary>
        /// </summary>
        void FinishUpdate();

        /// <summary>
        /// </summary>
        /// <param name="deltaTime"></param>
        void Update(float deltaTime);

    }

}