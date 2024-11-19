using DatingApp.Logic.DataContext;

namespace DatingApp.Logic.Controllers
{
    public class ServiceObject : IDisposable
    {
        public readonly bool contextOwner;

        internal ProjectDbContext? Context { get; private set; }

    #region Dispose pattern
        public bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if(!disposedValue)
            {
                if(disposing)
                {
                    if(contextOwner)
                    {
                        Context?.Dispose();
                    }
                    Context = null;
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    #endregion Dispose pattern
    }
}