using LifecyclesExample.Interfaces;

namespace LifecyclesExample
{
    public class OperationServices : ITransientService, ISingeltonService, IScopedService
    {
        Guid _id;
        public OperationServices()
        {
            _id = Guid.NewGuid();
        }

        public Guid GetId()
        {
            return _id;
        }
    }
}
