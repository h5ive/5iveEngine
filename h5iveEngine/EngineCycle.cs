using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h5iveEngine
{
    internal enum EngineCycle
    {
        Awake,
        OnEnable,
        Reset,
        Start,
        FixedUpdate,
        InternalPhysicsUpdate,
        InternalAnimationUpdate,
        OnTriggerEnter,
        OnTriggerStay,
        OnTriggerExit,
        OnCollisionEnter,
        OnCollisionStay,
        OnCollisionExit,
        YieWaitForFixedUpdate,
        AwaitedFixedUpdateAsync,
        OnInputEvents,
        Update,
        YieldNull,
        YieldWaitForSeconds,
        YieldWWW,
        YieldStartCoroutine,
        AsyncTaskContinuation,
        AwaitableNextFrameAsync,
        LateInternalAnimamtionUpdate,
        lateUpdate,
        OnPreCull,
        OnBecameInvisible,
        OnWillRenderObject,
        OnPreRender,
        OnRenderObject,
        OnPostRender,
        OnRenderImage,
        OnDrawGizmos,
        YieldWaitForEndOfFrame,
        AwaitableEndOfFrameAsync,
        OnApplicationpause,
        OnApplicationQuit,
        OnDisable,
        OnDestroy

    }
}
