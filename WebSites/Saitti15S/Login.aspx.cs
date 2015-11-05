using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //Jos sivu ok, niin kirjoitetaan käyttäjänimi sessioon ja siirrytään index-sivulle.
        if(Page.IsValid)
        {
            Session["user"] = txtName.Text;
            Server.Transfer("IndexMP.aspx");
        }
    }
}