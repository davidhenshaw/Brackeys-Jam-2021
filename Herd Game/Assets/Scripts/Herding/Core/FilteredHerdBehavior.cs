using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace metakazz{
    public abstract class FilteredHerdBehavior : HerdBehavior
    {
        public ContextFilter filter;
    }
}