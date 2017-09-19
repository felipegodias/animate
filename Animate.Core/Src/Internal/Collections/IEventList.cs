using System.Collections.Generic;
using Animate.Core.Events;
using Animate.Core.Interfaces;

namespace Animate.Core.Internal.Collections {

    internal interface IEventList : IEnumerable<AnimateEvent> {

        void Add(AnimateEvent item);

        void Invoke(ITweenRuntime tweenRuntime);

    }

}