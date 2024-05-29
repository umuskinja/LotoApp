using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace LotoApp
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface IPlayer
    {
        [OperationContract(IsOneWay = true)]
        void NewTicket(string name, Ticket ticket);
    }

    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void MessageRecieved(string message);
    }
}
