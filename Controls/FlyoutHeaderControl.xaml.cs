namespace SkoleIT.Controls;

public partial class FlyoutHeaderControl : StackLayout
{
	public FlyoutHeaderControl()
	{
		InitializeComponent();

        if (App.UserDetails != null)
        {
            lblUserName.Text = App.UserDetails.FullName;
            lblUserEmail.Text = "";
            lblUserRole.Text = "";
            UserPic.Source = App.UserDetails.UserImage;
        }
    }
}