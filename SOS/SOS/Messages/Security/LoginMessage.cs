using Prism.Events;
using SOS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismAppExample.Messages.Security
{
    public class LoginMessage : PubSubEvent<User>
    {
    }
}
