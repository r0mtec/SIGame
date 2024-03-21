using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SGame.AboutUser;

internal class ConnectedUser
{
    [JsonIgnore] // This property will be ignored during serialization
    public TcpClient? Client { get; set; }
    public User? User { get; set; }
    public bool isOtv = false;
    public ConnectedUser(TcpClient? client, User user)
    {
        Client = client;
        User = user;
    }
}
