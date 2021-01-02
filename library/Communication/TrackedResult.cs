using System;
using System.Collections.Generic;
using Interfaces.Model;

namespace Library.Communication
{
    public class TrackedResult<T> : ITrackedResult<T>
    {
        private readonly ITrackedArray<T> _trackedArray;
        private readonly ITrackedObject<T> _trackedObject;

        public TrackedResult(ITrackedObject<T> trackedObject)
        {
            _trackedObject = trackedObject;
        }

        public TrackedResult(ITrackedArray<T> trackedArray)
        {
            _trackedArray = trackedArray;
        }

        public IEnumerable<T> Get()
        {
            if (_trackedArray != null)
            {
                return _trackedArray.__Array__;
            }

            if (_trackedObject != null)
            {
                return new[]
                {
                    _trackedObject.__Object__
                };
            }

            return Array.Empty<T>();
        }
    }
}