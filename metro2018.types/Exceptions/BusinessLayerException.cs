using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metro2018.Types
{
    [Serializable]
    public class BusinessLayerException : Exception
    {
        public BusinessLayerException() { }
        public BusinessLayerException(string message) : base(message) { }
        public BusinessLayerException(string message, Exception inner) : base(message, inner) { }
        protected BusinessLayerException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
