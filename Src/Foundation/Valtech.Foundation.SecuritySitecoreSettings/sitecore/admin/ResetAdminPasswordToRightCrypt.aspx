﻿<%@ Page Language="C#" AutoEventWireup="true" %>


<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
			/*
                Set ThisIsChangedFromServer = true; to work
            */
			bool ThisIsChangedFromServer = false;
			if(!ThisIsChangedFromServer)
			{
				Response.Write("<h2>You have to activate this on the server.</h2>");
				return;
			}
	
            MembershipUser user = Membership.GetUser(@"sitecore\admin", false);
            /*
            ResetPassword calls the MembershipProvider.ResetPassword method of the membership provider referenced by the ProviderName
            property to reset the password for the membership user to a new, automatically generated password. 
            The new password is then returned to the caller.
            */
            string pwd = user.ResetPassword();  
     
            Response.Write("<h2>Password reset to <i>" + pwd + "</i></h2>");
    }
</script>