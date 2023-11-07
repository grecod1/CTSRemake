using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpline.Repository.Interfaces
{
    interface IErrorRepository
    {
        void LogError(string errorType, string task, string message, string userName);
    }
}
