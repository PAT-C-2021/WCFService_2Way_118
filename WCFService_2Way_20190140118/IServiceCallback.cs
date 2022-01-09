﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService_2Way_20190140118
{
   
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void gabung(string username);

        [OperationContract(IsOneWay = true)]
        void kirimPesan(string pesan);

    }
}
