using System;

namespace GameDrones.Core
{
    /// <summary>
    /// Base class which implements the mechanism for releasing unmanaged resources.
    /// </summary>
    public abstract class Disposable : IDisposable
    {
        #region Fields

        private bool _disposeValue; // to detect redundant calls

        #endregion

        #region IDisposable Support

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposeValue) return;

            if (disposing)
            {
                DisposeCore();
            }

            _disposeValue = true;
        }

        /// <summary>
        /// Finalize function to release unmanaged resources and performs other cleanup
        /// operations before the <see cref="Disposable"/> class is reclaimed by garbage collection.
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Ovveride this to dispose custom objects.
        /// </summary>
        protected abstract void DisposeCore();

        #endregion
    }
}