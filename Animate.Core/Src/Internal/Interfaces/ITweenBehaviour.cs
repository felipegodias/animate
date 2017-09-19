namespace Animate.Core.Internal.Interfaces {

    /// <summary>
    /// </summary>
    internal interface ITweenBehaviour {

        /// <summary>
        /// </summary>
        bool DestroyFlag { get; }

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