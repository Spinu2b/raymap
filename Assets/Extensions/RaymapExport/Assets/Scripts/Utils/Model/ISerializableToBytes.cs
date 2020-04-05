using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Extensions.RaymapExport.Assets.Scripts.Utils.Model
{
    public interface ISerializableToBytes
    {
        byte[] SerializeToBytes();
    }
}
