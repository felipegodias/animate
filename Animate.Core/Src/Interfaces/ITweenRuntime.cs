namespace Animate.Core.Interfaces {

    /// <summary>
    /// </summary>
    public interface ITweenRuntime {

        /// <summary>
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// </summary>
        /// <param name="deltaTime"></param>
        void Update(float deltaTime);

    }

}