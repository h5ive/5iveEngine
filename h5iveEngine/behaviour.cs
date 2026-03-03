using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace h5iveEngine
{
    public abstract class h5iveBehaviour
    {
        public void Print(Object message)
        {
            EngineUtils.Print(message.ToString());
        }
        public void WaitForInput();
        {
            EngineUtils.WaitForInput();
        }
        #endregion
        

        private Action cachedAwake;
        private Action cachedOnEnable;
        private Action cachedStart;
        private Action cachedFixedUpdate;
        private Action cachedUpdate;
        private Action cachedLateUpdate;
        private Action OnDisable;
        private Action OnDestroy;

        public h5iveBehaviour()
        {
            RegisterLifecycleMethods();
        }
        internal void InternalOnDisable()
        {
            UnregisterLifecycleMethods();
        }
        internal void InternalOnDestroy()
        {
            InternalOnDestroy();
        }

        private void RegisterLifecycleMethods()
        {
            var type = GetType();
            var updateMethod = type.GetMethod("Update");
            if (updateMethod != null)
            {
                cachedUpdate = (Action)Delegate.CreateDelgate(
                    typeof(Action), this, updateMethod);
                BehaviourControlModule.SubscribeUpdate(cachedUpdate);
            }

            var lateUpdateMethod = type.GetMethod("LateUpdate");
            if (lateUpdate != null)
            {
                cachedLateUpdate = (Action)Delegate.CreateDelegate(
                    typeof(Action), this lateUpdateMethod);
                BehaviourControlModule.SubscribeLateUpdate(cachedLateUpdate);
            }

        }

        private void UnregisterLifecycleMethods()
        {
            if (cachedUpdate != null)
                BehaviourControlModule.UnsubscribeUpdate(cachedUpdate);

            if (cachedLateUpdate != null)
                BehaviourControlModule.UnsubscribeLateUpdate(cachedLateUpdate);

        }
        



    {
    }
}
