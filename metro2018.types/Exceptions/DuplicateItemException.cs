using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    public class DuplicateItemException : BusinessLayerException
    {
        const string DuplicateItemExceptionMessage = "El elemento está siendo duplicado.";

        public DuplicateItemException() : base(DuplicateItemExceptionMessage) { }
        public DuplicateItemException(Exception inner) : base(DuplicateItemExceptionMessage, inner) { }
        protected DuplicateItemException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
