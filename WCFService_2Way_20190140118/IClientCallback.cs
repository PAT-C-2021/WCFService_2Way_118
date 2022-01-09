using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFService_2Way_20190140118
{
    [ServiceContract]
    interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void pesamKirim(string user, string pesan);
    }
}
