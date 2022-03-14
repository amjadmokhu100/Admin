using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaperHelp.Models
{
    public enum EmployeeKind
    {
        writer= 1,
        Profreader= 2,
        Admins = 3
    }

    public enum OrderStatus
    {
        WaitPayment = 1,
        PindingAdmin = 2,
        InProgress = 3,
        Finished = 4,
        Reviewing = 5
    }
}