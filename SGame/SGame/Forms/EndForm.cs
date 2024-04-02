using SGame.AboutUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGame.Forms;

public partial class EndForm : Form
{
    List<ConnectedUser> connectedUsersOwn = new List<ConnectedUser>();

    public EndForm(List<ConnectedUser> connectedUsers)
    {
        connectedUsersOwn = connectedUsers;
        connectedUsersOwn.Sort(comp);
        InitializeComponent();
    }

    private int comp(ConnectedUser x, ConnectedUser y)
    {
        if (x.User?.Scores > y.User?.Scores) return 1;
        else return 0;
    }
}
