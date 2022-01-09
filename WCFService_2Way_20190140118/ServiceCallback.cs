using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService_2Way_20190140118
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public class ServiceCallback : IServiceCallback
    {
        Dictionary<IClientCallback, string> userList = new Dictionary<IClientCallback, string>();
        public void gabung(string username)
        {
            IClientCallback koneksiGabung = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            userList[koneksiGabung] = username;
        }

        public void kirimPesan(string pesan)
        {
            IClientCallback koneksiPesan = OperationContext.Current.GetCallbackChannel<IClientCallback>();
            string user;    
            if (!userList.TryGetValue(koneksiPesan, out user))
            {
                return;
            }
            foreach (IClientCallback other in userList.Keys)
            {
                other.pesamKirim(user, pesan);
            }
        }
    }
}
