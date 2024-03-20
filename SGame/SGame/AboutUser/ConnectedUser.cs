using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGame.AboutUser;

internal class ConnectedUser
{
    public TcpClient? Client { get; set; }
    public User? User { get; set; }
    public bool isOtv = true;
    public ConnectedUser(TcpClient? client, User user)
    {
        Client = client;
        User = user;
    }
}
